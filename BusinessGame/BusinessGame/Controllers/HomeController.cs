using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;

namespace BusinessGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            game_BusinessDb db = new game_BusinessDb();

            //ViewBag.user = db.Products.First();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}