﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;


namespace ProjectFinal.Controllers
{
    public class hamisi_cvController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: hamisi_cv
        public ActionResult Index()
        {
            ViewBag.butun_kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.butun_sheherler = db.Sheher.ToList();
            ViewBag.emek_haqqi = db.Min_maash.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.ish_tecrubesi = db.Ish_tecrubesi.ToList();
            ViewBag.butun_cvler = db.CVler.Where(e => e.Status == true).OrderByDescending(x => x.Id).ToList();
            ViewBag.cvlerin_sayi = db.CVler.Where(e => e.Status == true).Count();



            return View();
        }
    }
}