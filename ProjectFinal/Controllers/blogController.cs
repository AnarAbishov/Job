using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    public class blogController : Controller
    {
        isaxtarEntities db = new isaxtarEntities();
        // GET: blog
        public ActionResult Index()
        {
            ViewBag.blog = db.Blog.ToList();
            return View();
        }
    }
}