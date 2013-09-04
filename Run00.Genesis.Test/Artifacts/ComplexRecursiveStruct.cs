using System;
using System.Collections.Generic;

namespace Run00.Genesis.Test.Artifacts
{
	public class ComplexRecursiveStruct
	{
		public int Number { get; set; }
		public ChildStruct childStruct { get; set; }
	}

	public struct ChildStruct
	{
		public string childString { get; set; } 
	}
}