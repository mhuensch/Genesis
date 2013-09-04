using System;
using System.Collections.Generic;

namespace Run00.Genesis.Test.Artifacts
{
	public class ComplexRecursiveClass
	{
		public int Number { get; set; }
		public ChildClass ChildClass { get; set; }
	}

	public class ChildClass
	{
		public string ChildString { get; set; } 
	}
}
