using ClubRP.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;

namespace ClubRP.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Index(string SearchTerm = null, string SearchField = null, int page = 1)
        {
            ViewBag.Champs = new SelectList(new string[] { "Auteur", "Titre" }, "Titre");
            IEnumerable<Post> postListe;
            postListe = db.Posts;

            if (SearchTerm != null)
            {
                switch (SearchField)
                {
                    case "Auteur":
                        postListe = db.Posts.Where(j => j.Auteur.Contains(SearchTerm));
                        break;
                    case "Titre":
                        postListe = db.Posts.Where(j => j.Titre.Contains(SearchTerm));
                        break;
                }
            }

            var model = postListe.ToList().ToPagedList(page, 2);

            if (Request.IsAjaxRequest()) return PartialView("_PartialPost", model);

            return View(model);
        }

        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Users = db.Users.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Create([Bind(Include = "ID,Titre,Description,utilisateur")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Auteur = User.Identity.Name;
                post.Creation = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Edit([Bind(Include = "ID,Titre,Description,utilisateur")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Auteur = User.Identity.Name;
                post.Creation = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(actionName: "Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Modérateurs,Administrateurs")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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