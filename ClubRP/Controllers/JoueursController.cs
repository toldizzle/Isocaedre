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
    public class JoueursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Joueurs
        public ActionResult Index()
        {
            return View(db.Joueurs.ToList());
        }

        // GET: Joueurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueurs.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // GET: Joueurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JoueurID,AspNetUserID,Nom,Classe,Maitre,Specialisation,GroupeID")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.Joueurs.Add(joueur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueurs.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JoueurID,AspNetUserID,Nom,Classe,Maitre,Specialisation,GroupeID")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueurs.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Joueur joueur = db.Joueurs.Find(id);
            db.Joueurs.Remove(joueur);
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
