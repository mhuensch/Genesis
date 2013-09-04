using System.Diagnostics;
using System.Reflection;

namespace Run00.Genesis
{
	[DebuggerDisplay("Create {Property.Name} using {Plan.GeneratorForType.GetType().Name}")]
	public class PropertyPlan
	{
		public PropertyInfo Property { get; set; }
		public Plan Plan { get; set; }
	}
}
