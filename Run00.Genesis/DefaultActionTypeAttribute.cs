using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Run00.Genesis
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
