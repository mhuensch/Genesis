using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Genesis
{
	public interface IDesignRegistry
	{
		Design FindDesign(Type type, string designName);
	}
}
