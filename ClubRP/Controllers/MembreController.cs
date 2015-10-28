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
    public class MembreController : Controller
    {
        private ClubDB db = new ClubDB();

        // GET: Membre
        public ActionResult Index()
        {
            return View(db.AspNetUsersInfoSups.ToList());
        }

        // GET: Membre/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersInfoSup aspNetUsersInfoSup = db.AspNetUsersInfoSups.Find(id);
            if (aspNetUsersInfoSup == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersInfoSup);
        }

        // GET: Membre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Role,Nom,Prenom,ImageNom,ImageType,ImageTaille,ImageData")] AspNetUsersInfoSup aspNetUsersInfoSup)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsersInfoSups.Add(aspNetUsersInfoSup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUsersInfoSup);
        }

        // GET: Membre/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersInfoSup aspNetUsersInfoSup = db.AspNetUsersInfoSups.Find(id);
            if (aspNetUsersInfoSup == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersInfoSup);
        }

        // POST: Membre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Role,Nom,Prenom,ImageNom,ImageType,ImageTaille,ImageData")] AspNetUsersInfoSup aspNetUsersInfoSup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUsersInfoSup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUsersInfoSup);
        }

        // GET: Membre/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersInfoSup aspNetUsersInfoSup = db.AspNetUsersInfoSups.Find(id);
            if (aspNetUsersInfoSup == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersInfoSup);
        }

        // POST: Membre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsersInfoSup aspNetUsersInfoSup = db.AspNetUsersInfoSups.Find(id);
            db.AspNetUsersInfoSups.Remove(aspNetUsersInfoSup);
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
