using System;

namespace Run00.Genesis
{
	public class IntelligentMutation : IGenerator
	{
		internal IntelligentMutation() { }

		internal void Using(Func<object> expression)
		{
			_mutateUsing = expression;
		}

		object IGenerator.Generate()
		{
			return _mutateUsing == null ? null : _mutateUsing.Invoke();
		}

		#region private
		private Func<object> _mutateUsing;
		#endregion
	}
}
