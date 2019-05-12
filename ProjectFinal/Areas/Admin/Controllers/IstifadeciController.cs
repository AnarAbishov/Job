using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Areas.Admin.Controllers
{
    public class IstifadeciController : Controller
    {
        private isaxtarEntities db = new isaxtarEntities();

        // GET: Admin/Istifadeci
        public ActionResult Index()
        {
            return View(db.Istifadeci.ToList());
        }

        // GET: Admin/Istifadeci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadeci.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            return View(istifadeci);
        }

        // GET: Admin/Istifadeci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Istifadeci/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Email,Leqeb,Password")] Istifadeci istifadeci)
        {
            if (ModelState.IsValid)
            {
                db.Istifadeci.Add(istifadeci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(istifadeci);
        }

        // GET: Admin/Istifadeci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadeci.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            return View(istifadeci);
        }

        // POST: Admin/Istifadeci/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Email,Leqeb,Password")] Istifadeci istifadeci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(istifadeci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(istifadeci);
        }

        // GET: Admin/Istifadeci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadeci.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            return View(istifadeci);
        }

        // POST: Admin/Istifadeci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Istifadeci istifadeci = db.Istifadeci.Find(id);
            db.Istifadeci.Remove(istifadeci);
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
