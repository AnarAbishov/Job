using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;
using ProjectFinal.Filter;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Auth]
    public class ElanlarController : Controller
    {
        private isaxtarEntities db = new isaxtarEntities();

        // GET: Admin/Elanlar
        public ActionResult Index()
        {
            var elanlar = db.Elanlar.OrderByDescending(e => e.Id).Include(e => e.Ish_tecrubesi).Include(e => e.Kategoriya).Include(e => e.Max_maash).Include(e => e.Max_yashlar).Include(e => e.Min_maash).Include(e => e.Min_yashlar).Include(e => e.Sheher).Include(e => e.Tehsil).Include(e => e.Vezife);
            return View(elanlar.ToList());
        }

        // GET: Admin/Elanlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elanlar elanlar = db.Elanlar.Find(id);
            if (elanlar == null)
            {
                return HttpNotFound();
            }
            return View(elanlar);
        }

        // GET: Admin/Elanlar/Create
        public ActionResult Create()
        {
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili");
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad");
            ViewBag.Max_maashId = new SelectList(db.Max_maash, "Id", "Mebleg");
            ViewBag.Max_yashId = new SelectList(db.Max_yashlar, "Id", "Max_yash");
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg");
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash");
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad");
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi");
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad");
            ViewBag.elanin_tarixi = DateTime.Now;
            return View();
        }

        // POST: Admin/Elanlar/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Telefon,VezifeId,Shirket_adi,Min_maashId,Max_maashId,SheherId,Min_yashId,Max_yashId,TehsilId,Ish_tecrubesiId,Elanin_tarixi,Bitme_tarixi,Elaqedar_shexs,Ish_barede_melumat,Namizede_telebler,KategoriyaId,Status")] Elanlar elanlar)
        {
            if (ModelState.IsValid)
            {
                db.Elanlar.Add(elanlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", elanlar.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", elanlar.KategoriyaId);
            ViewBag.Max_maashId = new SelectList(db.Max_maash, "Id", "Mebleg", elanlar.Max_maashId);
            ViewBag.Max_yashId = new SelectList(db.Max_yashlar, "Id", "Max_yash", elanlar.Max_yashId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", elanlar.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", elanlar.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", elanlar.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", elanlar.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", elanlar.VezifeId);
            return View(elanlar);
        }

        // GET: Admin/Elanlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elanlar elanlar = db.Elanlar.Find(id);
            if (elanlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", elanlar.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", elanlar.KategoriyaId);
            ViewBag.Max_maashId = new SelectList(db.Max_maash, "Id", "Mebleg", elanlar.Max_maashId);
            ViewBag.Max_yashId = new SelectList(db.Max_yashlar, "Id", "Max_yash", elanlar.Max_yashId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", elanlar.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", elanlar.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", elanlar.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", elanlar.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", elanlar.VezifeId);
            return View(elanlar);
        }

        // POST: Admin/Elanlar/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Telefon,VezifeId,Shirket_adi,Min_maashId,Max_maashId,SheherId,Min_yashId,Max_yashId,TehsilId,Ish_tecrubesiId,Elanin_tarixi,Bitme_tarixi,Elaqedar_shexs,Ish_barede_melumat,Namizede_telebler,KategoriyaId,Status")] Elanlar elanlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elanlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ish_tecrubesiId = new SelectList(db.Ish_tecrubesi, "Id", "Ili", elanlar.Ish_tecrubesiId);
            ViewBag.KategoriyaId = new SelectList(db.Kategoriya, "Id", "Ad", elanlar.KategoriyaId);
            ViewBag.Max_maashId = new SelectList(db.Max_maash, "Id", "Mebleg", elanlar.Max_maashId);
            ViewBag.Max_yashId = new SelectList(db.Max_yashlar, "Id", "Max_yash", elanlar.Max_yashId);
            ViewBag.Min_maashId = new SelectList(db.Min_maash, "Id", "Mebleg", elanlar.Min_maashId);
            ViewBag.Min_yashId = new SelectList(db.Min_yashlar, "Id", "Min_yash", elanlar.Min_yashId);
            ViewBag.SheherId = new SelectList(db.Sheher, "Id", "Ad", elanlar.SheherId);
            ViewBag.TehsilId = new SelectList(db.Tehsil, "Id", "Derecesi", elanlar.TehsilId);
            ViewBag.VezifeId = new SelectList(db.Vezife, "Id", "Ad", elanlar.VezifeId);
            return View(elanlar);
        }

        // GET: Admin/Elanlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elanlar elanlar = db.Elanlar.Find(id);
            if (elanlar == null)
            {
                return HttpNotFound();
            }
            return View(elanlar);
        }

        // POST: Admin/Elanlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elanlar elanlar = db.Elanlar.Find(id);
            db.Elanlar.Remove(elanlar);
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
    }
}
