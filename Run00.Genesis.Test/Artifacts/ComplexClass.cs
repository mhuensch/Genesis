using System;
using System.Collections.Generic;

namespace Run00.Genesis.Test.Artifacts
{
	public class ComplexClass
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public DateTime Date { get; set; }

		public IEnumerable<string> Ids { get; set; }
	}
}
