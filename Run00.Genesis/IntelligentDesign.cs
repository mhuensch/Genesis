using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Genesis
{
	public interface IIntelligentDesign
	{
		string GetName();
		Type GetDesignType();
		Func<object> GetCreationPattern();
		IEnumerable<DesignForProperty> GetPropertyDesigns();
	}

	public abstract class IntelligentDesign<TResult> : IIntelligentDesign
	{
		public IntelligentDesign()
		{
			_mutations = new Dictionary<string, DesignForProperty>();
		}

		protected void CreateUsing(Expression<Func<TResult>> expression)
		{
			_usingPattern = () => expression.Compile().Invoke();
		}

		protected Mutation<TProperty> Mutate<TProperty>(Expression<Func<TResult, TProperty>> expression)
		{
			var mutation = new Mutation<TProperty>();
			_mutations.Add("", new DesignForProperty() {  });

			//AddMutation(mutation, expression.Body);

			//if (_mutations.ContainsKey(propertyName))
			//	_mutations[propertyName] = mutation;
			//else
			//	_mutations.Add(propertyName, mutation);

			//return this;

			return mutation;
		}

		string IIntelligentDesign.GetName()
		{
			return typeof(TResult).FullName;
		}

		Type IIntelligentDesign.GetDesignType()
		{
			return typeof(TResult);
		}
		
		Func<object> IIntelligentDesign.GetCreationPattern()
		{
			return () => _usingPattern.Invoke();
		}

		IEnumerable<DesignForProperty> IIntelligentDesign.GetPropertyDesigns()
		{
			return new DesignForProperty[] { };
		}

		private Func<TResult> _usingPattern;
		private readonly Dictionary<string, DesignForProperty> _mutations;
	}
}
