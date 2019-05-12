using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    public class elanController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: elan
        public ActionResult Index(int id)
        {
            ViewBag.elan = db.Elanlar.FirstOrDefault(p => p.Id == id);
            ViewBag.butun_kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.emek_haqqi = db.Min_maash.ToList();
            ViewBag.butun_sheherler = db.Sheher.ToList();
            ViewBag.min_yash = db.Min_yashlar.ToList();
            ViewBag.max_yash = db.Max_yashlar.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.ish_tecrubesi = db.Ish_tecrubesi.ToList();
            DateTime elanin_tarixi = DateTime.Now;
            
            return View();
        }
    }
}