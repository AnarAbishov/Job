using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using System.Web.Helpers;

namespace ProjectFinal.Areas.Admin.Controllers
{
    public class homeController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: Admin/home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users usr)
        {
            Users loginned = db.Users.FirstOrDefault(u => u.Email == usr.Email);
            if (loginned != null)
            {
                if (loginned.Password == usr.Password)
                {
                    Session["Loginned"] = true;
                    Session["userId"] = loginned.Id;
                    return RedirectToAction("index", "dashboard");
                }
            }
            Session["LoginInvalid"] = true;
            return RedirectToAction("index");
        }
    }
}