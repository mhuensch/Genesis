using System;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public interface IActionResultCreator
	{
		Type ForActionType { get; }
		ActionResult CreateResult(object data);
	}
}
