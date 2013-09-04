using System;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Genesis.Test.Artifacts
{
	public class DesignForComplexRecursiveClass : StaticDesign<ComplexRecursiveClass>
	{
		protected override ComplexRecursiveClass Create()
		{
			return new ComplexRecursiveClass()
			{
				Number = 10,
				ChildClass = MutateChildClass()
			};
		}

		private ChildClass MutateChildClass()
		{
			return new ChildClass() { ChildString = "child class string" };
		}

	}
}