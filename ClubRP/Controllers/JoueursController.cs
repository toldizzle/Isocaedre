﻿using System;
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
    public class JoueursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Joueurs
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Index()
        {
            string AspNetUserID = User.Identity.GetUserId();
            var query = db.Joueurs.Where(j => j.AspNetUserID == AspNetUserID);
            if (User.IsInRole("Administrateurs")) return View(db.Joueurs.ToList());
            if (query != null)
                return View(query);
            else
                return HttpNotFound();
        }

        // GET: Joueurs/Details/5
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
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
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Create([Bind(Include = "JoueurID,AspNetUserID,Nom,Maitre,Specialisation")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                joueur.AspNetUserID = User.Identity.GetUserId();
                joueur.Nom = User.Identity.Name;
                ApplicationUser user = db.Users.Where(u => u.Id == joueur.AspNetUserID).First();
                user.details.Joueur = joueur;
                db.Joueurs.Add(joueur);
                db.SaveChanges();
                return RedirectToAction("Index","Groupes");
            }

            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
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
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Edit([Bind(Include = "JoueurID,AspNetUserID,Nom,Maitre,Specialisation,GroupeID,PersonnageID")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                joueur.AspNetUserID = User.Identity.GetUserId();
                joueur.Nom = User.Identity.Name;
                db.Entry(joueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
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
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult DeleteConfirmed(int id)
        {
            Joueur joueur = db.Joueurs.Find(id);
            if (joueur.GroupeID != null)
            {
                Groupe groupe = db.Groupes.Where(g => g.ID == joueur.GroupeID).First();
                groupe.Joueurs.Remove(joueur);
            }
            ApplicationUser user = db.Users.Where(d => d.Id == joueur.AspNetUserID).First();
            user.details.Joueur = null;
            db.Joueurs.Remove(joueur);
            db.SaveChanges();
            return RedirectToAction("Index", "Groupes");
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
