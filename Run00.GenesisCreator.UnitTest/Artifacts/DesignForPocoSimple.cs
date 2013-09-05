using Run00.Genesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.GenesisCreator.UnitTest.Artifacts
{
	public class DesignForPocoSimple : IntelligentDesign<PocoSimple>
	{
		public DesignForPocoSimple()
		{
			CreateUsing(() => new PocoSimple());

			Mutate(cc => cc.Id).Using(() => Guid.Parse("{84ED5387-ED1E-425D-8D83-ED9829A3767D}"));
			Mutate(cc => cc.On).Using(() => DateTime.Parse("08/13/1977"));
			Mutate(cc => cc.Value).Using(() => "Some Value");
		}
	}
}
