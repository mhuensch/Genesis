using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Genesis
{
	public class DesignForProperty
	{
		public PropertyInfo ForProperty { get; set; }
		public Func<object> SetUsing { get; set; }
	}
}
