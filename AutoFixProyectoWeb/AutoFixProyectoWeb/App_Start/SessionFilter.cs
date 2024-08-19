using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoFixProyectoWeb.App_Start
{
    public class SessionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Count == 0)
            {
                var values = new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Home",
                    code = "0"
                });

                filterContext.Result = new RedirectToRouteResult(values);
            }

            this.OnActionExecuting(filterContext);
        }
    }
}