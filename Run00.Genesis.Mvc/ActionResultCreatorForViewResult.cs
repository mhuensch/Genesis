using System;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public class ActionResultCreatorForPartialViewResult : IActionResultCreator
	{
		Type IActionResultCreator.ForActionType { get { return typeof(ViewResult); } }

		ActionResult IActionResultCreator.CreateResult(object data)
		{
			var result = new ViewResult();
			result.ViewData.Model = data;
			return result;
		}
	}
}
