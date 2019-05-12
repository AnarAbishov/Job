using ProjectFinal.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Auth]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Loginned"] = null;
            return RedirectToAction("index","home");
        }
    }
}