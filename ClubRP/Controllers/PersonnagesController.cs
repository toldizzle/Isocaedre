using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClubRP.Models
{
    public class PersonnagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personnages
        public ActionResult Index()
        {
            string Usager = User.Identity.GetUserId();
            var query = db.Joueurs.Where(j => j.AspNetUserID == Usager)
                                        .Select(p => p.PersonnageID)
                                        .First();

            return View(db.Personnages.Where(p => p.PersonnageID == query));
        }

        // GET: Personnages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnage personnage = db.Personnages.Find(id);
            if (personnage == null)
            {
                return HttpNotFound();
            }
            return View(personnage);
        }

        // GET: Personnages/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Personnages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersoID,NomPerso,Race,Classe,Niveau,Alignement,Force,Dexterite,Constitution,Charisme,Intelligence,Sagesse,Vigueur,Volonte,Reflexe,VigueurBonus,VolonteBonus,ReflexeBonus,BaB,BaBBonus,Initiative,InitiativeBonus,Lutte,LutteBonus,HP,Deplacement,AC,NaturalAC,ACBonus,ResistanceSort,ReductionDegat,NomArme,Degats,Hit,Crit,Munition,DetailsArme,NomArmure,ArmureAC,TypeArmure,Malus,DetailsArmure,Appraise,Balance,Bluff,Climb,Concentration,Craft1,Craft1Nom,Craft2,Craft2Nom,Craft3,Craft3Nom,Decipher,Diplomacy,DisableDevice,Disguise,EscapeArtist,Forgery,GatherInfo,HandleAnimal,Heal,Hide,Intimidate,Jump,Knowledge1,Knowledge1Name,Knowledge2,Knowledge2Name,Knowledge3,Knowledge3Name,Knowledge4,Knowledge4Name,Knowledge5,Knowledge5Name,Listen,MoveSilently,OpenLock,Perform1,Perform1Nom,Perform2,Perform2Nom,Profession1,Profession1Nom,Profession2,Profession2Nom,Ride,Search,SenseMotive,SleightOfHand,Spellcraft,Spot,Survival,Swim,Tumble,UMD,UseRope,Notes,Gold,Experience,JoueurID")] Personnage personnage)
        {
            if (ModelState.IsValid)
            {
                db.Personnages.Add(personnage);

                string Usager = User.Identity.GetUserId();
                Joueur query = db.Joueurs.Where(j => j.AspNetUserID == Usager).First();
                query.PersonnageID = db.Personnages.Select(p => p.PersonnageID).First();

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personnage);
        }

        // GET: Personnages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnage personnage = db.Personnages.Find(id);
            if (personnage == null)
            {
                return HttpNotFound();
            }
            return View(personnage);
        }

        // POST: Personnages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersoID,NomPerso,Race,Classe,Niveau,Alignement,Force,Dexterite,Constitution,Charisme,Intelligence,Sagesse,Vigueur,Volonte,Reflexe,VigueurBonus,VolonteBonus,ReflexeBonus,BaB,BaBBonus,Initiative,InitiativeBonus,Lutte,LutteBonus,HP,Deplacement,AC,NaturalAC,ACBonus,ResistanceSort,ReductionDegat,NomArme,Degats,Hit,Crit,Munition,DetailsArme,NomArmure,ArmureAC,TypeArmure,Malus,DetailsArmure,Appraise,Balance,Bluff,Climb,Concentration,Craft1,Craft1Nom,Craft2,Craft2Nom,Craft3,Craft3Nom,Decipher,Diplomacy,DisableDevice,Disguise,EscapeArtist,Forgery,GatherInfo,HandleAnimal,Heal,Hide,Intimidate,Jump,Knowledge1,Knowledge1Name,Knowledge2,Knowledge2Name,Knowledge3,Knowledge3Name,Knowledge4,Knowledge4Name,Knowledge5,Knowledge5Name,Listen,MoveSilently,OpenLock,Perform1,Perform1Nom,Perform2,Perform2Nom,Profession1,Profession1Nom,Profession2,Profession2Nom,Ride,Search,SenseMotive,SleightOfHand,Spellcraft,Spot,Survival,Swim,Tumble,UMD,UseRope,Notes,Gold,Experience,JoueurID")] Personnage personnage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personnage);
        }

        // GET: Personnages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnage personnage = db.Personnages.Find(id);
            if (personnage == null)
            {
                return HttpNotFound();
            }
            return View(personnage);
        }

        // POST: Personnages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personnage personnage = db.Personnages.Find(id);
            db.Personnages.Remove(personnage);
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
