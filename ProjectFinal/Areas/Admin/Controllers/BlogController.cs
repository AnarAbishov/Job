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
    public class BlogController : Controller
    {
        private isaxtarEntities db = new isaxtarEntities();

        // GET: Admin/Blog
        public ActionResult Index()
        {
            return View(db.Blog.ToList());
        }

        // GET: Admin/Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sekil,Tarix,Basliq,Text")] Blog blog,HttpPostedFileBase Sekil)
        {
            if (ModelState.IsValid)
            {
                if (Sekil.ContentType != "image/png" && Sekil.ContentType != "image/jpeg" && Sekil.ContentType != "image/gif")
                {
                    Session["uploadError"] = "Your file must be jpg,png or gif";
                    return RedirectToAction("create");
                }
                if ((Sekil.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "Your file size must be max 1mb";
                    return RedirectToAction("create");
                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + Sekil.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                Sekil.SaveAs(path);
                blog.Sekil = filename;
                db.Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            //if (ModelState.IsValid)
            //{
            //    db.Blog.Add(blog);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(blog);
        }

        // GET: Admin/Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blog/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sekil,Tarix,Basliq,Text")] Blog blog,HttpPostedFileBase Sekil)
        {
                if (ModelState.IsValid)
                {
                    if (Sekil.ContentType != "image/png" && Sekil.ContentType != "image/jpeg" && Sekil.ContentType != "image/gif")
                    {
                        Session["uploadError"] = "Your file must be jpg,png or gif";
                        return RedirectToAction("create");
                    }
                    if ((Sekil.ContentLength / 1024) > 1024)
                    {
                        Session["uploadError"] = "Your file size must be max 1mb";
                        return RedirectToAction("create");
                    }
                    string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + Sekil.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    Sekil.SaveAs(path);
                    blog.Sekil = filename;
                    db.Blog.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }



                //if (ModelState.IsValid)
                //{
                //    db.Entry(blog).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                return View(blog);
        }

        // GET: Admin/Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            db.Blog.Remove(blog);
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
