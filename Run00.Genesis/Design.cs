using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Run00.Core;

namespace Run00.Genesis
{
	public class Design
	{
		protected internal Design(Type forType)
		{
			Contract.Requires(forType != null);

			_forType = forType;
			_steps = new List<DesignStep>();

			RecursiveDepth = 1;
			ListSize = 5;
		}

		protected int RecursiveDepth { get; set; }
		protected int ListSize { get; set; }

		internal Type ForType { get { return _forType; } }
		internal void CreateUsing(Func<object> function) { _createUsing = function; }

		internal virtual void Initialize(IntelligentCreator creator)
		{
			if (_forType.HasPublicParameterlessConstructor())
				CreateUsing(() => Activator.CreateInstance(_forType));

			foreach (var property in _forType.GetProperties())
			{
				if (property.CanWrite == false)
					continue;

				var design = creator.FindDesignFor(property.PropertyType);
				if (design == null)
					continue;

				_steps.Add(new DesignStep(creator, property.Name, design));
			}
		}
		internal virtual object Generate(IntelligentCreator creator, int currentDepth)
		{
			if (currentDepth > RecursiveDepth)
				return null;

			//Setup: Constructor
			Initialize(creator);

			//Create object using specified function
			object result = null;
			if (_createUsing == null)
				return null;
			result = _createUsing.Invoke();

			//Populate each property
			foreach (var step in _steps)
				step.Populate(result, ListSize, currentDepth);

			return result;
		}

		#region private
		private readonly Type _forType;
		private readonly List<DesignStep> _steps;
		private Func<object> _createUsing;
		#endregion
	}
}
