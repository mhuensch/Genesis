using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Run00.Genesis.Mvc
{
	public class GenesisFilter : ActionFilterAttribute, IActionFilter
	{
		public GenesisFilter(Creator creator, IEnumerable<IActionResultCreator> actionResultCreators)
		{
			_creator = creator;
			_actionResultCreators = actionResultCreators;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			GenerateData(filterContext);
			base.OnActionExecuted(filterContext);
		}

		private void GenerateData(ActionExecutedContext filterContext)
		{
			var useGenesis = filterContext.RouteData.Values["isGenerate"];
			if (useGenesis == null)
				return;

			if (true.Equals(useGenesis) == false)
				return;

			int count = 0;
			var countValue = filterContext.RouteData.Values["count"];
			if (countValue != null)
				int.TryParse(countValue.ToString(), out count);

			var methodInfo = ((ReflectedActionDescriptor)(filterContext.ActionDescriptor)).MethodInfo;
			var attribute = methodInfo.GetCustomAttributes(typeof(DefaultActionTypeAttribute), false).FirstOrDefault() as DefaultActionTypeAttribute;
			if (attribute == null)
				return;

			var actionCreator = _actionResultCreators.ForActionType(attribute.ActionType);
			if (actionCreator == null)
				return;

			var data = _creator.Create(attribute.ModelType, count);
			var result = actionCreator.CreateResult(data);

			filterContext.Result = result;
			if (filterContext.Exception != null)
				filterContext.ExceptionHandled = true;
		}

		private readonly IEnumerable<IActionResultCreator> _actionResultCreators;
		private readonly Creator _creator;
	}
}