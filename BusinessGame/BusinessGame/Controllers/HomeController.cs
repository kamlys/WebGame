using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;
using BusinessGame.ViewModels.BuildProduct;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using BusinessGame.ViewModels.BuildProduct.Building;
using BusinessGame.ViewModels.BuildProduct.Product;

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
                UserBuildingProduct UserProductBuilding = new UserBuildingProduct();
                UserProductBuilding.UBuilding = new List<U_Building>();
                UserProductBuilding.UBuilding.AddRange(GetBuilding(uID));
                UserProductBuilding.UMap = db.Maps.FirstOrDefault(a => a.User_ID == uID);
                return View(UserProductBuilding);
            }

            return View();
        }


        public List<U_Building> GetBuilding(int uID)
        {
            var builds = db.UserBuildings.Where(u => u.User_ID == uID).Select(u => new U_Building
            {
                Buidling_ID = u.Building_ID,
                BuildingLvl = u.Lvl,
                BuildingName = u.Buildings.Name,
                User_ID = u.User_ID,
                x_left = u.X_pos,
                y_top = u.Y_pos,
                x_right = u.X_pos + db.Buildings.FirstOrDefault(a => a.ID == u.Building_ID).Width,
                y_bottom = u.Y_pos + db.Buildings.FirstOrDefault(a => a.ID == u.Building_ID).Height
            }).ToList();

            return builds;
        }

        public JsonResult GetProduct()
        {
            int uID = db.Users.First(u => u.Login == User.Identity.Name).ID;

            UpdateUserProduct();
            IList<UserProducts> UserProduct = new List<UserProducts>();


            IList<U_Product> listProduct = new List<U_Product>();
            var products = db.UserProducts.Where(u => u.User_ID == uID);

            foreach (var item in products)
            {
                listProduct.Add(new U_Product { Product_ID = item.Product_ID, ProductName = item.Product_Name, Value = item.Value });
            }

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }

        public void UpdateUserProduct()
        {
            int uID = db.Users.First(u => u.Login == User.Identity.Name).ID;

            if(db.Users.First(u => u.ID == uID).Last_Update == null)
            {
                db.Users.First(u => u.ID == uID).Last_Update = db.Users.First(u => u.ID == uID).Registration_Date;
            }

            var dateSubstract = DateTime.Now.Subtract((DateTime)(db.Users.First(u => u.ID == uID).Last_Update)).TotalSeconds;

            foreach (var item in db.UserProducts.Where(u => u.User_ID == uID))
            {
                int pID = item.Product_ID;

                int Product_per_lvl = db.Buildings.First(p => p.Product_ID == pID).Product_per_sec;
                int Percet_per_lvl = db.Buildings.First(p => p.Product_ID == pID).Percent_product_per_lvl;
                int BuildLvl = db.UserBuildings.First(b => b.Buildings.Product_ID == pID).Lvl;

                item.Value += (int)Math.Round((Product_per_lvl * (Percet_per_lvl * 0.01) * BuildLvl) * dateSubstract);
            }
            db.Users.First(u => u.ID == uID).Last_Update = DateTime.Now;
            db.SaveChanges();
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