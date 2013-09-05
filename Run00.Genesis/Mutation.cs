using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Genesis
{
	public class Mutation<TResult>
	{
		internal Func<object> UsingPattern { get { return _usingPattern; } }

		public void Using(Expression<Func<TResult>> expression)
		{
			_usingPattern = () => expression.Compile().Invoke();
		}

		public void UsingRandomDataFrom(IEnumerable<TResult> data)
		{
			_usingPattern = () => data.Random();
		}

		private Func<object> _usingPattern;
	}
}
