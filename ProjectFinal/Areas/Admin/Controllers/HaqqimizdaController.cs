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
    public class HaqqimizdaController : Controller
    {
        private isaxtarEntities db = new isaxtarEntities();

        // GET: Admin/Haqqimizda
        public ActionResult Index()
        {
            return View(db.Haqqimizda.ToList());
        }

        // GET: Admin/Haqqimizda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haqqimizda haqqimizda = db.Haqqimizda.Find(id);
            if (haqqimizda == null)
            {
                return HttpNotFound();
            }
            return View(haqqimizda);
        }

        // GET: Admin/Haqqimizda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Haqqimizda/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Basliq,text")] Haqqimizda haqqimizda)
        {
            if (ModelState.IsValid)
            {
                db.Haqqimizda.Add(haqqimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(haqqimizda);
        }

        // GET: Admin/Haqqimizda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haqqimizda haqqimizda = db.Haqqimizda.Find(id);
            if (haqqimizda == null)
            {
                return HttpNotFound();
            }
            return View(haqqimizda);
        }

        // POST: Admin/Haqqimizda/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Basliq,text")] Haqqimizda haqqimizda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(haqqimizda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(haqqimizda);
        }

        // GET: Admin/Haqqimizda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haqqimizda haqqimizda = db.Haqqimizda.Find(id);
            if (haqqimizda == null)
            {
                return HttpNotFound();
            }
            return View(haqqimizda);
        }

        // POST: Admin/Haqqimizda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Haqqimizda haqqimizda = db.Haqqimizda.Find(id);
            db.Haqqimizda.Remove(haqqimizda);
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
