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
            return View();
        }

        public ActionResult About()
        {
            game_BusinessDb db = new game_BusinessDb();

            int loggedUser = db.Users.First(a => a.Login == User.Identity.Name).ID;

            var ub = new UserBuildings()
            {
                User_ID = loggedUser,
                X_pos = 2,
                Y_pos = 2,
                Lvl = 1,
                Building_ID = 2
            };

            db.UserBuildings.Add(ub);
            db.SaveChanges();

            return View();
            //return db.UserBuildings.First(u => u.User_ID == loggedUser);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}