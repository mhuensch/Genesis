using Run00.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Run00.Genesis
{
	public class IntelligentMutation<TResult> : IntelligentMutation
	{
		public void Using(Expression<Func<TResult>> expression)
		{
			base.Using(() => expression.Compile().Invoke());
		}

		public void UsingRandomDataFrom(IEnumerable<TResult> data)
		{
			base.Using(() => data.Random());
		}

		public void UsingSequentialDataFrom(IEnumerable<TResult> data, TResult previous, Action<TResult> previousCallback)
		{
			base.Using(() =>
			{
				var next = data.NextElement(previous);
				previousCallback(next);
				return next;
			});
		}
	}
}
