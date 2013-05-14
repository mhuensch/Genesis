using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Run00.Genesis
{
	public abstract class IntelligentDesign<T> : IntelligentDesign
	{
		protected IntelligentDesign() : base(typeof(T)) { }

		protected void CreateUsing(Expression<Func<T>> expression)
		{
			base.CreateUsing(() => expression.Compile().Invoke());
		}

		protected IntelligentMutation<TProperty> Mutate<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			Contract.Requires(expression != null);
			Contract.Requires(expression.Body != null);

			var mutation = new IntelligentMutation<TProperty>();
			AddMutation(mutation, expression.Body);
			return mutation;
		}
	}
}
