using System;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public class ActionResultCreatorForJsonResult : IActionResultCreator
	{
		Type IActionResultCreator.ForActionType { get { return typeof(JsonResult); } }

		ActionResult IActionResultCreator.CreateResult(object data)
		{
			var result = new JsonResult();
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			result.Data = data;
			return result;
		}
	}
}
