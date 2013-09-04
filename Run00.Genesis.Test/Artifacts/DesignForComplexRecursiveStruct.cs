using System;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Genesis.Test.Artifacts
{
	public class DesignForComplexRecursiveStruct : StaticDesign<ComplexRecursiveStruct>
	{
		protected override ComplexRecursiveStruct Create()
		{
			return new ComplexRecursiveStruct()
			{
				Number = 10,
				childStruct = MutateChildStruct()
			};
		}

		private ChildStruct MutateChildStruct()
		{
			return new ChildStruct() { childString = "child class string" };
		}
	}
}