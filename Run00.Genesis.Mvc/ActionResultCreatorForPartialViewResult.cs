using System;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public class ActionResultCreatorForViewResult : IActionResultCreator
	{
		Type IActionResultCreator.ForActionType { get { return typeof(PartialViewResult); } }

		ActionResult IActionResultCreator.CreateResult(object data)
		{
			var result = new PartialViewResult();
			result.ViewData.Model = data;
			return result;
		}
	}
}
