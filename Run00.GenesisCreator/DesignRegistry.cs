using Run00.Genesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.GenesisCreator
{
	public class DesignRegistry : IDesignRegistry
	{
		public DesignRegistry(IEnumerable<IIntelligentDesign> intelligentDesigns)
		{
			_intelligentDesigns = intelligentDesigns;
		}

		Design IDesignRegistry.FindDesign(Type type, string designName)
		{
			if (_designs == null)
				_designs = GenerateDesings();

			return (
				from d in _designs
				let rank = RankDesign(d, type, designName)
				where rank != 0
				orderby rank descending
				select d
			).FirstOrDefault();
		}

		private IEnumerable<Design> GenerateDesings()
		{
			var result = new List<Design>();
			
			foreach (var iDesign in _intelligentDesigns)
			{
				result.Add(new Design() 
				{
					Name = iDesign.GetName(),
					CreateUsing = iDesign.GetCreationPattern(),
					ForType = iDesign.GetDesignType()
				});

				var propertyDesigns = new List<DesignForProperty>();
				var implicitDesigns = new List<DesignForProperty>(iDesign.GetPropertyDesigns());
				var properties = iDesign.GetDesignType().GetProperties();
				foreach (var prop in properties)
				{
					if (prop.CanRead == false || prop.CanWrite == false)
						continue;

					var design = implicitDesigns.Where(p => p.ForProperty == prop).FirstOrDefault();
					if (design != null)
					{
						propertyDesigns.Add(design);
						continue;
					}

					var creationFunction = _intelligentDesigns.Where(p => p.GetDesignType() == prop.PropertyType).Select(d => d.GetCreationPattern()).FirstOrDefault();
					if (creationFunction != null)
						propertyDesigns.Add(new DesignForProperty() { ForProperty = prop, SetUsing = () => creationFunction });
				}
			}

			return result;
		}

		private int RankDesign(Design design, Type type, string designName)
		{
			if (string.IsNullOrWhiteSpace(designName) == false && design.Name.Equals(designName, StringComparison.InvariantCultureIgnoreCase))
				return int.MaxValue;

			if (design.ForType.Equals(type))
				return 2;

			if (design.ForType.IsAssignableFrom(type))
				return 1;

			return 0;
		}

		private IEnumerable<Design> _designs;
		private IEnumerable<IIntelligentDesign> _intelligentDesigns;
	}
}
