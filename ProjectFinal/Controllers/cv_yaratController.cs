using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using System.IO;
using ProjectFinal.Filter;

namespace ProjectFinal.Controllers
{
    [Log]
    public class cv_yaratController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: cv_yarat
        public ActionResult Index()
        {
            ViewBag.cinsler = db.Cinsler.ToList();
            ViewBag.yash = db.Min_yashlar.ToList();
            ViewBag.tehsil = db.Tehsil.ToList();
            ViewBag.is_tecrubesi = db.Ish_tecrubesi.ToList();
            ViewBag.kategoriyalar = db.Kategoriya.ToList();
            ViewBag.vezife = db.Vezife.ToList();
            ViewBag.sheherler = db.Sheher.ToList();
            ViewBag.minimum_emek_haqqi = db.Min_maash.ToList();
            ViewBag.cvnin_tarixi = DateTime.Now;
            

            return View();
        }


        [HttpPost]
        public ActionResult Add(CVler cv, HttpPostedFileBase Shekil)
        {

            if (ModelState.IsValid)
            {
                if (Shekil.ContentType != "image/png" && Shekil.ContentType != "image/jpeg" && Shekil.ContentType != "image/gif")
                {
                    Session["uploadError"] = "Your file must be jpg,png or gif";
                    return RedirectToAction("index","cv_yarat");
                }
                if ((Shekil.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "Your file size must be max 1mb";
                    return RedirectToAction("index", "cv_yarat");
                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + Shekil.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                Shekil.SaveAs(path);
                cv.Shekil = filename;
                cv.Cvnin_tarixi = DateTime.Now;
                db.CVler.Add(cv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("index", "hamisi_elan");
        }


        public JsonResult GetVezifeJson(int id)
        {
            var list = db.Vezife.Where(v => v.KateqoriyaId == id).Select(v => new
            {

                v.Id,
                v.Ad

            }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}