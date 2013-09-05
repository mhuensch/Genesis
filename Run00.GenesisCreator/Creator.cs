using Run00.Genesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.GenesisCreator
{
	public class Creator : ICreator
	{
		public Creator(IDesignRegistry designRegistry)
		{
			_designRegistry = designRegistry;
		}

		T ICreator.Create<T>(string designName)
		{
			return (T)((ICreator)this).Create(typeof(T), designName);
		}

		object ICreator.Create(Type type, string designName)
		{
			var design = _designRegistry.FindDesign(type, designName);
			if (design == null)
				return null;

			var result = design.CreateUsing.Invoke();
			if (result == null || design.PropertyDesigns == null)
				return result;

			foreach (var propPlan in design.PropertyDesigns)
				propPlan.ForProperty.SetValue(result, propPlan.SetUsing.Invoke(), null);

			return result;
		}

		private readonly IDesignRegistry _designRegistry;
	}
}
