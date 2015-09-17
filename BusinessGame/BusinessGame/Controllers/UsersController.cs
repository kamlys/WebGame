using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessGame.Models;
using System.Web.Helpers;
using System.Web.Security;

namespace BusinessGame.Controllers
{
    public class UsersController : Controller
    {
        private game_BusinessDb db = new game_BusinessDb();

        // GET: Users
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BusinessGame.ViewModels.User.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Login == model.Login) && !db.Users.Any(u => u.Email == model.Email))
                {
                    var user = new Users()
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = Crypto.HashPassword(model.Password),
                        Registration_Date = DateTime.Now,
                        Last_log = DateTime.Now
                    };

                    
                    
                    db.Users.Add(user);
                    db.SaveChanges();



                    int uID = db.Users.Max(u => u.ID);

                    var map = new Maps()
                    {
                        User_ID = uID,
                        Height = 10,
                        Width = 10
                    };

                    db.Maps.Add(map);
                    db.SaveChanges();


                    return RedirectToAction("Index", "Home");
                }
            }
            if (!string.IsNullOrEmpty(model.Login) && db.Users.Any(u => u.Login == model.Login))
                ModelState.AddModelError("Login", "Ten login jest już używany.");

            if (!string.IsNullOrEmpty(model.Email) && db.Users.Any(u => u.Email == model.Email))
                ModelState.AddModelError("Email", "Ten email jest już używany.");

            return View(model);
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(BusinessGame.ViewModels.User.LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Login == model.Login))
                {
                    var user = db.Users.First(u => u.Login == model.Login);
                    if (Crypto.VerifyHashedPassword(user.Password, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);

                            return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Login bądź hasło niepoprawne.");
                }

            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }


    }
}