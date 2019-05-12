using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    public class haqqimizdaController : Controller
    {
        isaxtarEntities db = new isaxtarEntities(); 
        // GET: haqqimizda
        public ActionResult Index()
        {
            ViewBag.haqqimizda = db.Haqqimizda.ToList();
            return View();
        }
    }
}