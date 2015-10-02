using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubRP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Titre = "Accueil";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Titre = "A propos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Titre = "Nous contacter";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Materiel()
        {
            ViewBag.Titre = "Notre matériel";
            return View();
        }
        public ActionResult Forum()
        {
            ViewBag.Titre = "Forum de l'Isocaèdre";
            return View();
        }
        public ActionResult Membre()
        {
            ViewBag.Titre = "Espace membre";
            return View();
        }
    }
}