using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Run00.Genesis
{
	[DebuggerDisplay("Create {ForType.Name} using {GeneratorType.Name}")]
	public class Plan
	{
		public Type ForType { get; internal set; }
		public IEnumerable<PropertyPlan> PropertyPlans { get; set; }

		public Type GeneratorType { get { return Generator == null ? null : Generator.GetType(); } }
		internal IGenerator Generator { get; set; }
	}
}
