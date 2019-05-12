using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    public class sign_inController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: sign_in
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Istifadeci ist)
        {
            Istifadeci loginned = db.Istifadeci.FirstOrDefault(u => ist.Leqeb == ist.Leqeb);
            if (loginned != null)
            {
                if (loginned.Password == ist.Password)
                {
                    Session["Loginned"] = true;
                    Session["userId"] = loginned.Id;
                    return RedirectToAction("index", "home");
                }
            }
            Session["LoginInvalid"] = true;
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Add(Istifadeci ist)
        {

            db.Istifadeci.Add(ist);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}