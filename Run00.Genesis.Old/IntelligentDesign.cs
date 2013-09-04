using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace Run00.Genesis
{
	public class IntelligentDesign : IGenerator
	{
		internal IntelligentDesign(Type forType)
		{
			Contract.Requires(forType != null);

			_forType = forType;
			_mutations = new Dictionary<string, IntelligentMutation>();
			if (_forType.GetConstructor(Type.EmptyTypes) != null)
				_createUsing = () => Activator.CreateInstance(_forType);
		}

		internal Type ForType { get { return _forType; } }
		internal IntelligentDesign CreateUsing(Func<object> function) { _createUsing = function; return this; }
		internal IntelligentDesign AddMutation(IntelligentMutation mutation, Expression expression)
		{
			var memberExpression = expression as MemberExpression;
			if (memberExpression == null)
				return this;

			return AddMutation(mutation, memberExpression.Member.Name);
		}
		internal IntelligentDesign AddMutation(IntelligentMutation mutation, string propertyName)
		{
			if (_mutations.ContainsKey(propertyName))
				_mutations[propertyName] = mutation;
			else
				_mutations.Add(propertyName, mutation);

			return this;
		}
		internal IntelligentMutation FindMutationFor(PropertyInfo property)
		{
			if (property == null)
				return null;

			return _mutations.ContainsKey(property.Name) ? _mutations[property.Name] : null;
		}

		object IGenerator.Generate()
		{
			return _createUsing == null ? null : _createUsing.Invoke();
		}

		#region private
		private readonly Type _forType;
		private Func<object> _createUsing;
		private readonly Dictionary<string, IntelligentMutation> _mutations;

		[ContractInvariantMethod]
		[ExcludeFromCodeCoverage]
		[SuppressMessage("Microsoft.Performance", "CA1811:MarkMembersAsStatic", Justification = "Required for code contracts.")]
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
		private void ObjectInvariant()
		{
			Contract.Invariant(_forType != null);
			Contract.Invariant(_mutations != null);
		}

		#endregion
	}
}
