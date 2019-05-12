using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinal.Filter
{
    public class Auth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Loginned"] == null)
            {
                filterContext.Result = new RedirectResult("~/admin/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
