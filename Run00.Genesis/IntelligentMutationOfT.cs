using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Run00.Utilities;

namespace Run00.Genesis
{
	public class IntelligentMutation<TResult> : IntelligentMutation
	{
		public void Using(Expression<Func<TResult>> expression)
		{
			base.Using(() => expression.Compile().Invoke());
		}

		public void UsingRandomDataFrom<TResult>(IEnumerable<TResult> data)
		{
			base.Using(() => data.Random());
		}
	}
}
