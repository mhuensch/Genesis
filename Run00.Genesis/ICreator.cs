using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Genesis
{
	public interface ICreator
	{
		T Create<T>(string designName);
		object Create(Type type, string designName);
	}
}
