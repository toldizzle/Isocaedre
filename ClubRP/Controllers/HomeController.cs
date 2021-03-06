﻿using ClubRP.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClubRP.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Titre = "Accueil";
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Titre = "A propos";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Titre = "Nous contacter";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Materiel()
        {
            ViewBag.Titre = "Notre matériel";
            return View();
        }

        [Authorize]
        public ActionResult Forum()
        {
            ViewBag.Titre = "Forum de l'Isocaèdre";
            ViewBag.ListePosts = new List<Post>();
            return View();
        }

        [Authorize(Roles = "Administrateurs")]
        public ActionResult Membre()
        {
            ViewBag.Titre = "Espace membre";
            return View();
        }
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Groupe()
        {
            ViewBag.Titre = "Espace de groupe";
            ViewBag.ListeGroupes = new List<Groupe>();
            return View();
        }
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Recompense()
        {
            return View();
        }
        [Authorize(Roles = "Modérateurs,Administrateurs,Utilisateurs,Maître,Joueurs")]
        public ActionResult Sorts()
        {
            return View();
        }
    }
}