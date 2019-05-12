using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using System.IO;
using ProjectFinal.Filter;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Auth]
    public class CVlerController : Controller
    {
        private isaxtarEntities db = new isaxtarEntities();

        // GET: Admin/CVler
        public ActionResult Index()
        {
            var cVler = db.CVler.OrderByDescending(c => c.Id).Include(c => c.Cinsler).Include(c => c.Ish_tecrubesi).Include(c => c.Kategoriya).Include(c => c.Min_maash).Include(c => c.Min_yashlar).Include(c => c.Sheher).Include(c => c.Tehsil).Include(c => c.Vezife);
            return View(cVler.ToList());
        }

        // GET: Admin/CVler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVler cVler = db.CVler.Find(id);
            if (cVler == null)
            {
                return HttpNotFound();
            }
            return View(cVler);
        }

        // GET: Admin/CVler/Create
        public ActionResult Create()
        {
            ViewBag.CinsId = new SelectList(db.Cinsler, "Id", "Cins");
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili");
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad");
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg");
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash");
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad");
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi");
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad");
            return View();
        }

        // POST: Admin/CVler/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,Ata_adi,CinsId,Min_yashId,Shekil,TehsilId,Ish_tecrubesiId,VezifeId,SheherId,Min_maashId,Email,Telefon,Elave_melumat,KategoriyaId,Cvnin_tarixi,Bitme_tarixi,Status")] CVler cVler, HttpPostedFileBase Shekil)
        {
            if (ModelState.IsValid)
            {
                if (Shekil == null)
                {
                    Session["uploadError"] = "Your must select your file";
                    return RedirectToAction("create");
                }
                if (Shekil.ContentType != "image/png" && Shekil.ContentType != "image/jpeg" && Shekil.ContentType != "image/gif")
                {
                    Session["uploadError"] = "Your file must be jpg,png or gif";
                    return RedirectToAction("create");
                }
                if ((Shekil.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "Your file size must be max 1mb";
                    return RedirectToAction("create");
                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + Shekil.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                Shekil.SaveAs(path);
                cVler.Shekil = filename;
                db.CVler.Add(cVler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            //if (ModelState.IsValid)
            //{
            //    db.CVler.Add(cVler);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ViewBag.CinsId = new SelectList(db.Cinsler, "Id", "Cins", cVler.CinsId);
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", cVler.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", cVler.KategoriyaId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", cVler.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", cVler.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", cVler.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", cVler.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", cVler.VezifeId);
            return View(cVler);
        }

        // GET: Admin/CVler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVler cVler = db.CVler.Find(id);
            if (cVler == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinsId = new SelectList(db.Cinsler, "Id", "Cins", cVler.CinsId);
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", cVler.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", cVler.KategoriyaId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", cVler.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", cVler.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", cVler.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", cVler.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", cVler.VezifeId);
            return View(cVler);
        }

        // POST: Admin/CVler/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,Ata_adi,CinsId,Min_yashId,Shekil,TehsilId,Ish_tecrubesiId,VezifeId,SheherId,Min_maashId,Email,Telefon,Elave_melumat,KategoriyaId,Cvnin_tarixi,Bitme_tarixi,Status")] CVler cVler, HttpPostedFileBase Shekil,string OldShekil)
        {
            if (ModelState.IsValid)
            {
                if (Shekil != null)
                {
                    if (Shekil.ContentType != "image/png" && Shekil.ContentType != "image/jpeg" && Shekil.ContentType != "image/gif")
                    {
                        Session["uploadError"] = "Your file must be jpg,png or gif";
                        return RedirectToAction("update", "CVler", new { id=cVler.Id});
                    }
                    if ((Shekil.ContentLength / 1024) > 1024)
                    {
                        Session["uploadError"] = "Your file size must be max 1mb";
                        return RedirectToAction("update", "CVler", new { id = cVler.Id });
                    }
                    string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + Shekil.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    string oldpath = Path.Combine(Server.MapPath("~/Uploads"), OldShekil);
                    System.IO.File.Delete(oldpath);
                    Shekil.SaveAs(path);
                    cVler.Shekil = filename;
                }
                else
                {
                    cVler.Shekil = OldShekil;
                }
                db.Entry(cVler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.CinsId = new SelectList(db.Cinsler, "Id", "Cins", cVler.CinsId);
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", cVler.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", cVler.KategoriyaId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", cVler.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", cVler.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", cVler.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", cVler.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", cVler.VezifeId);
            return View(cVler);
        }

        // GET: Admin/CVler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVler cVler = db.CVler.Find(id);
            if (cVler == null)
            {
                return HttpNotFound();
            }
            return View(cVler);
        }

        // POST: Admin/CVler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVler cVler = db.CVler.Find(id);
            db.CVler.Remove(cVler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
