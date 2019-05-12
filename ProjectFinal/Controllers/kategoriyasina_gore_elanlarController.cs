using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    public class kategoriyasina_gore_elanlarController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: kategoriyasina_gore_elanlar
        public ActionResult Index(int id)
        {
            ViewBag.butun_kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.butun_sheherler = db.Sheher.ToList();
            ViewBag.emek_haqqi = db.Min_maash.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.ish_tecrubesi = db.Ish_tecrubesi.ToList();

            ViewBag.elanlarin_kategoriyasi = db.Kategoriya.FirstOrDefault(p => p.Id == id);
            ViewBag.elanlarin_sayi = db.Elanlar.Where(p => p.KategoriyaId == id).Count();
            ViewBag.elan = db.Elanlar.Where(p => p.KategoriyaId == id);
            return View();
        }
    }
}