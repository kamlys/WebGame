using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;
using System.Web.UI.WebControls;

namespace BusinessGame.Controllers
{
    public class BuildingsController : Controller
    {
        private game_BusinessDb db = new game_BusinessDb();

        // GET: Buildings
        public ActionResult Index()
        {
            var buildings = db.Buildings.Include(b => b.Products);
            return View(buildings.ToList());
        }

        public ActionResult getBuildings()
        {
            var buildings = db.Buildings.Include(b => b.Products);
            return View(buildings.ToList());
        }

        [HttpPost]
        public JsonResult CreateUserBuilding(String dane)
        {
            return Json("Spoko, inżynierowie ogarnęli kuwetę!");
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buildings buildings = db.Buildings.Find(id);
            if (buildings == null)
            {
                return HttpNotFound();
            }
            return View(buildings);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Percent_price_per_lvl,Width,Height,Product_per_lvl,Dest_price,Percent_product_per_lvl,Product_ID")] Buildings buildings)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(buildings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name", buildings.Product_ID);
            return View(buildings);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buildings buildings = db.Buildings.Find(id);
            if (buildings == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name", buildings.Product_ID);
            return View(buildings);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Percent_price_per_lvl,Width,Height,Product_per_lvl,Dest_price,Percent_product_per_lvl,Product_ID")] Buildings buildings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Name", buildings.Product_ID);
            return View(buildings);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buildings buildings = db.Buildings.Find(id);
            if (buildings == null)
            {
                return HttpNotFound();
            }
            return View(buildings);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buildings buildings = db.Buildings.Find(id);
            db.Buildings.Remove(buildings);
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
