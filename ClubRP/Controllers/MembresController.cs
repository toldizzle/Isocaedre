﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubRP.Models;
using System.IO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Data.Entity.Migrations;

namespace ClubRP.Controllers
{
    public class MembresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Roles, "Name", "Name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,details,Email,PasswordHash,Role")] ApplicationUser appUser)
        {
            PasswordHasher pass = new PasswordHasher();
            if (ModelState.IsValid)
            {
                appUser.details.ID = appUser.Id;
                db.userProp.Add(appUser.details);
                appUser.PasswordHash = pass.HashPassword(appUser.PasswordHash);
                appUser.SecurityStamp = Guid.NewGuid().ToString();
                appUser.UserName = appUser.Email;
                appUser.details.ImageNom = Path.GetFileName(appUser.details.Fichier.FileName);
                appUser.details.ImageTaille = appUser.details.Fichier.ContentLength;
                appUser.details.ImageType = appUser.details.Fichier.ContentType;
                appUser.details.ImageData = new byte[appUser.details.ImageTaille];
                appUser.details.Fichier.InputStream.Read(appUser.details.ImageData, 0, appUser.details.ImageTaille);
                db.Users.Add(appUser);
                db.SaveChanges();
                //Role
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                UserManager.AddToRole(appUser.Id, appUser.details.Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(db.Users.ToList());
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.Categories = new SelectList(db.Roles, "Name", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,details,Email,PasswordHash,Role")] ApplicationUser appUser)
        {
            PasswordHasher pass = new PasswordHasher();
            if (ModelState.IsValid)
            {
                //Modifie les entrées nécessaires.
                appUser.details.ID = appUser.Id;
                appUser.PasswordHash = pass.HashPassword(appUser.PasswordHash);
                appUser.SecurityStamp = Guid.NewGuid().ToString();
                appUser.UserName = appUser.Email;
                appUser.details.ImageNom = Path.GetFileName(appUser.details.Fichier.FileName);
                appUser.details.ImageTaille = appUser.details.Fichier.ContentLength;
                appUser.details.ImageType = appUser.details.Fichier.ContentType;
                appUser.details.ImageData = new byte[appUser.details.ImageTaille];
                appUser.details.Fichier.InputStream.Read(appUser.details.ImageData, 0, appUser.details.ImageTaille);
                //Update le aspuserinfosupp
                db.userProp.AddOrUpdate(appUser.details);
                //Role
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                UserManager.AddToRole(appUser.Id, appUser.details.Role);
                
                //db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsersInfoSup aspNetUsersInfoSup = db.userProp.Find(id);
            db.userProp.Remove(aspNetUsersInfoSup);
            ApplicationUser appUser = db.Users.Find(id);
            db.Users.Remove(appUser);
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
