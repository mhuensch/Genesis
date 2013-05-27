using Run00.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

		public void UsingSequentialDataFrom<TResult>(IEnumerable<TResult> data, TResult previous)
		{
			base.Using(() => data.NextElement(previous));
		}
	}
}
