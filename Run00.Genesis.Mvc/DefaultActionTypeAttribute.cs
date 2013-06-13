using System;

namespace Run00.Genesis.Mvc
{
	public class DefaultActionTypeAttribute : Attribute
	{
		public Type ActionType { get; private set; }
		public Type ModelType { get; private set; }

		public DefaultActionTypeAttribute(Type actionType, Type modelType)
		{
			ActionType = actionType;
			ModelType = modelType;
		}
	}
}
