using System;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public class ActionResultCreatorForContentResult : IActionResultCreator
	{
		Type IActionResultCreator.ForActionType { get { return typeof(ContentResult); } }

		ActionResult IActionResultCreator.CreateResult(object data)
		{
			var result = new ContentResult();
			
			if (data == null)
				return result;

			result.Content = data.ToString();
			return result;
		}
	}
}
