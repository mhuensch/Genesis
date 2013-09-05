using System;
using System.Collections.Generic;

namespace Run00.Genesis
{
	public class Design
	{
		public string Name { get; set; }
		public Type ForType { get; set; }
		public Func<object> CreateUsing { get; set; }
		public ICollection<DesignForProperty> PropertyDesigns { get; set; }
	}
}
