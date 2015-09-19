using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;
//using BusinessGame.ViewModels.BuildProduct;

namespace BusinessGame.Controllers
{
    public class HomeController : Controller
    {
        game_BusinessDb db = new game_BusinessDb();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                int uID = db.Users.First(u => u.Login == User.Identity.Name).ID;
                //UserBuildingProduct UserProductBuilding = new UserBuildingProduct();
               // UserProductBuilding.UBuilding = new List<UserBuildings>();
            //    UserProductBuilding.UProduct = new List<UserProducts>();
               // UserProductBuilding.UBuilding.AddRange(GetBuilding(uID));
            //    UserProductBuilding.UProduct.AddRange(GetProduct(uID));
            //    return View(UserProductBuilding);
              //  return View(UserProductBuilding);
            }

            return View();
        }


        public List<UserBuildings> GetBuilding(int uID)
        {
            var builds = db.UserBuildings.Where(u => u.User_ID == uID).ToList();
           
            return builds;
        }

        public JsonResult GetProduct()
        {

            IList<UserProducts> up = new List<UserProducts>();

            int uID = db.Users.First(u => u.Login == User.Identity.Name).ID;
            var products = db.UserProducts.Where(u => uID == u.User_ID);

            foreach (var item in products)
            {
                up.Add(item);
            }

            return Json(up, JsonRequestBehavior.AllowGet);
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
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}