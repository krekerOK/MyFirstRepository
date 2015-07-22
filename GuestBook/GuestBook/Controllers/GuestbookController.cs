using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        //
        // GET: /Guestbook/
        public ActionResult Index()
        {
            var mostRecentEntries = db.GuestbookEntries.OrderBy(message => message.DateAdded).Take(20);
            ViewBag.Entries = mostRecentEntries.ToList();
            return View(); 
        }

        private GuestbookEntities db = new GuestbookEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            db.GuestbookEntries.Add(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Show(int id)
        {
            var entry = db.GuestbookEntries.Find(id);
            bool hasPermission = User.Identity.Name == entry.Name;
            ViewData["hasPermission"] = hasPermission;
            return View(entry);
        }
	}
}