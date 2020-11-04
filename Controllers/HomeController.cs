using OnlineToDo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineToDo.Controllers
{
    public class HomeController : Controller
    {
        todoEntities db = new todoEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(users user)
        {
            var dbUser = db.users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (dbUser != null)
            {
                FormsAuthentication.SetAuthCookie(dbUser.userName, false);
                return RedirectToAction("NoteList","Todo");
            }
            else
            {
                ViewBag.HataMesaj = "Incorrect user name or password";
                return View();
            }
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(users user)
        {
            notes note = new notes();

            if (!ModelState.IsValid)
            {
                ViewBag.CreateHata = "Confirm password doesn't match!";
                return View("CreateUser");
            }
            else
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}