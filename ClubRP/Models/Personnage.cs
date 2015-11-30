using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Personnage
    {
        // Infos Personnages
        [Key]
        public int PersoID { get; set; }
        [Required]
        public string NomPerso { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Classe { get; set; }
        [Required]
        public string Niveau { get; set; }
        public string Alignement { get; set; }

        // Stats
        [Required]
        public int Force { get; set; }
        [Required]
        public int Dexterite { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Charisme { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Sagesse { get; set; }

        // Saves
        [Required]
        public int Vigueur { get; set; }
        [Required]
        public int Volonte { get; set; }
        [Required]
        public int Reflexe { get; set; }
        public int VigueurBonus { get; set; }
        public int VolonteBonus { get; set; }
        public int ReflexeBonus { get; set; }

        // Stats combats
        [Required]
        public int BaB { get; set; }
        public int BaBBonus { get; set; }
        [Required]
        public int Initiative { get; set; }
        public int InitiativeBonus { get; set; }
        [Required]
        public int Lutte { get; set; }
        public int LutteBonus { get; set; }
        [Required]
        public int HP { get; set; }
        [Required]
        public int Deplacement { get; set; }

        // Défense
        [Required]
        public int? AC { get; set; }
        public int? NaturalAC { get; set; }
        public int? ACBonus { get; set; }
        public int? ResistanceSort { get; set; }
        public int? ReductionDegat { get; set; }

        // Arme
        public string NomArme { get; set; }
        public string Degats { get; set; }
        public string Hit { get; set; }
        public string Crit { get; set; }
        public int? Munition { get; set; }
        public string DetailsArme { get; set; }

        // Armure
        public string NomArmure { get; set; }
        public int? ArmureAC { get; set; }
        public string TypeArmure { get; set; }
        public int? Malus { get; set; }
        public string DetailsArmure { get; set; }

        // Skills
        public int? Appraise { get; set; }
        public int? Balance { get; set; }
        public int? Bluff { get; set; }
        public int? Climb { get; set; }
        public int? Concentration { get; set; }
        public int? Craft1 { get; set; }
        public string Craft1Nom { get; set; }
        public int? Craft2 { get; set; }
        public string Craft2Nom { get; set; }
        public int? Craft3 { get; set; }
        public string Craft3Nom { get; set; }
        public int? Decipher { get; set; }
        public int? Diplomacy { get; set; }
        public int? DisableDevice { get; set; }
        public int? Disguise { get; set; }
        public int? EscapeArtist { get; set; }
        public int? Forgery { get; set; }
        public int? GatherInfo { get; set; }
        public int? HandleAnimal { get; set; }
        public int? Heal { get; set; }
        public int? Hide { get; set; }
        public int? Intimidate { get; set; }
        public int? Jump { get; set; }
        public int? Knowledge1 { get; set; }
        public string Knowledge1Name { get; set; }
        public int? Knowledge2 { get; set; }
        public string Knowledge2Name { get; set; }
        public int? Knowledge3 { get; set; }
        public string Knowledge3Name { get; set; }
        public int? Knowledge4 { get; set; }
        public string Knowledge4Name { get; set; }
        public int? Knowledge5 { get; set; }
        public string Knowledge5Name { get; set; }
        public int? Listen { get; set; }
        public int? MoveSilently { get; set; }
        public int? OpenLock { get; set; }
        public int? Perform1 { get; set; }
        public string Perform1Nom { get; set; }
        public int? Perform2 { get; set; }
        public string Perform2Nom { get; set; }
        public int? Profession1 { get; set; }
        public string Profession1Nom { get; set; }
        public int? Profession2 { get; set; }
        public string Profession2Nom { get; set; }
        public int? Ride { get; set; }
        public int? Search { get; set; }
        public int? SenseMotive { get; set; }
        public int? SleightOfHand { get; set; }
        public int? Spellcraft { get; set; }
        public int? Spot { get; set; }
        public int? Survival { get; set; }
        public int? Swim { get; set; }
        public int? Tumble { get; set; }
        public int? UMD { get; set; }
        public int? UseRope { get; set; }

        // Autre
        public string Notes { get; set; }
        public int? Gold { get; set; }
        public int? Experience { get; set; }
        // Liens
        public int JoueurID { get; set; }
    }
}