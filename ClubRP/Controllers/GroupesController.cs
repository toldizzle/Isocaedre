using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubRP.Models;
using Microsoft.AspNet.Identity;

namespace ClubRP.Controllers
{
    public class GroupesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groupes
        public ActionResult Index()
        {
            string AspNetUserID = User.Identity.GetUserId();
            var user = db.Users.Where(d => d.Id == AspNetUserID).First();
            ViewBag.Joueur = null;
            ViewBag.Admin = false;

            if (user.details.Joueur != null)
            {
                var query = db.Joueurs.Where(j => j.AspNetUserID == AspNetUserID).First();
                ViewBag.Joueur = query;
            }
            if (User.IsInRole("Administrateurs"))
            {
                ViewBag.Admin = true;
            }
            return View(db.Groupes.ToList());
        }

        // GET: Groupes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        // GET: Groupes/Create
        public ActionResult Create()
        {
            //string AspNetUserID = User.Identity.GetUserId();
            //var query = db.Joueurs.Select(j => j.AspNetUserID == AspNetUserID).First();
            //ViewBag.Joueur = query;
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titre,Description,Creation,AspNetUserID,Auteur")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                groupe.AspNetUserID = User.Identity.GetUserId();
                groupe.Auteur = User.Identity.Name;
                groupe.Creation = DateTime.Now;
                db.Groupes.Add(groupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupe);
        }

        // GET: Groupes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titre,Description,Creation,AspNetUserID,Auteur")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                groupe.AspNetUserID = User.Identity.GetUserId();
                groupe.Creation = DateTime.Now;
                groupe.Auteur = User.Identity.Name;
                db.Entry(groupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupe);
        }

        // GET: Groupes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groupe groupe = db.Groupes.Find(id);
            db.Groupes.Remove(groupe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Rejoindre(int id)
        {
            string AspNetUserID = User.Identity.GetUserId();
            var query = db.Joueurs.Where(j => j.AspNetUserID == AspNetUserID).First();
            query.GroupeID = id;
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
