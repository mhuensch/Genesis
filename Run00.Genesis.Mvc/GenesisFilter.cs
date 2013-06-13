using Run00.Genesis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MvcWebRole.Filters
{
	public class GenesisFilter : ActionFilterAttribute, IActionFilter
	{
		public GenesisFilter(Creator creator)
		{
			_creator = creator;
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

			if (typeof(ViewResultBase).IsAssignableFrom(attribute.ActionType) == false)
				return;

			ViewResultBase result;
			try
			{
				result = Activator.CreateInstance(attribute.ActionType) as ViewResultBase;
			}
			catch
			{
				return;
			}

			if (result == null)
				return;

			result.ViewData.Model = _creator.Create(attribute.ModelType, count);

			filterContext.Result = result;
			if (filterContext.Exception != null)
				filterContext.ExceptionHandled = true;
		}

		private readonly Creator _creator;

	}
}