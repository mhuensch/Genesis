using System;

namespace Run00.Genesis.Mvc
{
	public class DefaultActionResultAttribute : Attribute
	{
		public Type ActionResultType { get; private set; }
		public Type ModelType { get; private set; }

		public DefaultActionResultAttribute(Type actionResultType, Type modelType)
		{
			ActionResultType = actionResultType;
			ModelType = modelType;
		}
	}
}
