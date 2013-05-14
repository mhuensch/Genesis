using System;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Genesis.Test.Artifacts
{
	public class DesignForComplexClass : IntelligentDesign<ComplexClass>
	{
		public DesignForComplexClass()
		{
			CreateUsing(() => new ComplexClass());

			var data = new[] { DateTime.Now };
			Mutate(cc => cc.Date).UsingRandomDataFrom(data);

			//In a real usage, the following would supply random data.  
			//See Run00.Genesis.SimpleDesigns for more realistic examples.
			Mutate(cc => cc.Date).Using(() => DateTime.Parse("08/13/1977"));
			Mutate(cc => cc.Id).Using(() => Guid.Parse("FBB49DE7-B6C3-4340-8595-45E19817147C"));
			Mutate(cc => cc.Name).Using(() => "My Complex Class");
			Mutate(cc => cc.Number).Using(() => 10);
			Mutate(cc => cc.Ids).Using(() => new List<string>() { "One", "Two", "Three" });
		}
	}
}