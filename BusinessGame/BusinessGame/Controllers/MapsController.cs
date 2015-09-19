using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace BusinessGame.Controllers
{
    public class Test
    {
        public string name;
        public int x_left;
        public int y_top;
        public int x_right;
        public int y_bottom;
    }

    public class MapsController : Controller
    {
        private game_BusinessDb db = new game_BusinessDb();

        // GET: Maps
        public ActionResult Index()
        {
            var maps = db.Maps.Include(m => m.Users);
            return View(maps.ToList());
        }

        // GET: Maps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maps maps = db.Maps.Find(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            return View(maps);
        }

        // GET: Maps/GetUsersMap
        public Maps GetUsersMap()
        {
            Users loggedUser = db.Users.First(a => a.Login == User.Identity.Name);
            return loggedUser.Maps.First();
        }

        public JsonResult FreeTiles()
        {
            var json = new JavaScriptSerializer().Serialize(new string[] {"1-2", "2-2", "3-1", "4-7"});
            return Json(json);
        }

        public List<UserBuildings> GetUsersBuildings()
        {
           int loggedUserId = db.Users.First(a => a.Login == User.Identity.Name).ID;
           List<UserBuildings> ub = db.UserBuildings.SqlQuery("SELECT * FROM UserBuildings where User_ID = " + loggedUserId).ToList();
           return ub;
        }


        public ActionResult ShowCurrent()
        {
            var ub = GetUsersBuildings();
            List<dynamic> show = new List<dynamic>();
            foreach (var b in ub)
            {
                Buildings build = db.Buildings.Find(b.Building_ID);
                show.Add(new Test { name = build.Name, x_left = b.X_pos, x_right = b.X_pos + build.Width, y_top = b.Y_pos, y_bottom = b.Y_pos + build.Height });
            }
            ViewBag.buildings = show;
            return View(GetUsersMap());
        }

        // GET: Maps/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Login");
            return View();
        }

        // POST: Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Map_ID,User_ID,Height,Width")] Maps maps)
        {
            if (ModelState.IsValid)
            {
                db.Maps.Add(maps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.Users, "ID", "Login", maps.User_ID);
            return View(maps);
        }

        // GET: Maps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maps maps = db.Maps.Find(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Login", maps.User_ID);
            return View(maps);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Map_ID,User_ID,Height,Width")] Maps maps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Login", maps.User_ID);
            return View(maps);
        }

        // GET: Maps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maps maps = db.Maps.Find(id);
            if (maps == null)
            {
                return HttpNotFound();
            }
            return View(maps);
        }

        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maps maps = db.Maps.Find(id);
            db.Maps.Remove(maps);
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
