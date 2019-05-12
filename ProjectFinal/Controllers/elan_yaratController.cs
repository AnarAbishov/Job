using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using ProjectFinal.Filter;

namespace ProjectFinal.Controllers
{
    [Log]
    public class elan_yaratController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: elan_yarat
        public ActionResult Index()
        {
            ViewBag.kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.sheher = db.Sheher.ToList();
            ViewBag.minimum_emek_haqqi = db.Min_maash.ToList();
            ViewBag.maximum_emek_haqqi = db.Max_maash.ToList();
            ViewBag.minimum_yash = db.Min_yashlar.ToList();
            ViewBag.maximum_yash = db.Max_yashlar.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.ish_tecrubesi = db.Ish_tecrubesi.ToList();
            ViewBag.elanin_tarixi = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Elanlar elan)
        {
            elan.Elanin_tarixi = DateTime.Now;
            db.Elanlar.Add(elan);
            db.SaveChanges();
            return RedirectToAction("index","hamisi_elan");
        }
    }
}