using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinal.Filter
{
    public class Log : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Loginned"] == null)
            {
                filterContext.Result = new RedirectResult("~/sign_in/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}