using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Run00.Genesis.Mvc
{
	public static class ExtensionsForEnumerableOfActionResultCreator
	{
		public static IActionResultCreator ForActionType(this IEnumerable<IActionResultCreator> source, Type actionType)
		{
			var result = (
				from creator in source
				where creator.ForActionType.IsAssignableFrom(actionType)
				select creator
			).FirstOrDefault();

			return result; 
		}
	}
}
