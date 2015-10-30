using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubRP.Models;

namespace ClubRP.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: Messages/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "MessageID,Texte,PostID,utilisateur")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.utilisateur = (from user in db.Users
                                      where user.Email == System.Web.HttpContext.Current.User.Identity.Name
                                       select user).First();
                
                message.DateMessage = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Posts");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Edit([Bind(Include = "MessageID,Texte,PostID,utilisateur")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.utilisateur.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                message.DateMessage = DateTime.Now;
                message.PostID = message.PostID;
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Posts");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "Posts");
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
