using OnlineToDo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineToDo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        todoEntities3 db = new todoEntities3();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(notes note)
        {
            if (note.notes1 == null)
            {
                return RedirectToAction("NoteList", "Todo");
            }
            else
            {
                notes sNote = new notes();
                sNote.notes1 = note.notes1;
                sNote.username = User.Identity.Name;
                db.notes.Add(sNote);
                db.SaveChanges();

                return RedirectToAction("NoteList", "Todo");
            }
        }

        public ActionResult NoteList()
        {
            string u = User.Identity.Name;
            var query = from b in db.notes where b.username == u select b;
            return View(query);
        }

        public ActionResult Delete(int id)
        {
            var deleteModel = db.notes.Find(id);
            if (deleteModel == null)
            {
                return HttpNotFound();
            }
            db.notes.Remove(deleteModel);
            db.SaveChanges();
            return RedirectToAction("NoteList", "Todo");
        }
    }
}