using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using System.Web.Helpers;

namespace ProjectFinal.Controllers
{
    public class homeController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: home
        public ActionResult Index()
        {
            ViewBag.butun_kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.butun_sheherler = db.Sheher.ToList();
            ViewBag.emek_haqqi = db.Min_maash.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.ish_tecrubesi = db.Ish_tecrubesi.ToList();
            ViewBag.elanlar = db.Elanlar.Where(e => e.Status == true).OrderByDescending(x => x.Id).ToList();

            return View();
        }

        public ActionResult Search(string searching)
        {
            var elans = from e in db.Elanlar
                        select e;
            if (!String.IsNullOrEmpty(searching))
            {
                // elans = elans.Where(e => e.Sheher.Contains(searching));
            }
            return RedirectToAction("index", "hamisi_elan");
        }

        [HttpPost]
        public ActionResult Login(Istifadeci ist)
        {
            Istifadeci loginned = db.Istifadeci.FirstOrDefault(u => ist.Leqeb == ist.Leqeb);
            ViewBag.leqeb = db.Istifadeci.FirstOrDefault(u => ist.Leqeb == ist.Leqeb);
            ViewBag.parol = db.Istifadeci.FirstOrDefault(u => ist.Password == ist.Password);

            if (loginned != null)
            {
                if (loginned.Password == ist.Password)
                {
                    Session["Loginned"] = true;
                    Session["userAd"] = loginned.Ad;
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


        public ActionResult Logout()
        {
            Session["Loginned"] = null;
            return RedirectToAction("index", "home");
        }
    }
}