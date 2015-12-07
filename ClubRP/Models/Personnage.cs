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
        [Required]
        public int PersonnageID { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NomPerso")]
        public string NomPerso { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Race")]
        public string Race { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Classe")]
        public string Classe { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Niveau")]
        public string Niveau { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Alignement")]
        public string Alignement { get; set; }

        // Stats
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Force")]
        public int Force { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Dexterite")]
        public int Dexterite { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Constitution")]
        public int Constitution { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Charisme")]
        public int Charisme { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Intelligence")]
        public int Intelligence { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Sagesse")]
        public int Sagesse { get; set; }

        // Saves
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Vigueur")]
        public int Vigueur { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Volonte")]
        public int Volonte { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Reflexe")]
        public int Reflexe { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "VigueurBonus")]
        public int? VigueurBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "VolonteBonus")]
        public int? VolonteBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "ReflexeBonus")]
        public int? ReflexeBonus { get; set; }

        // Stats combats
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "BaB")]
        public int BaB { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "BaBBonus")]
        public int? BaBBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Initiative")]
        public int Initiative { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "InitiativeBonus")]
        public int? InitiativeBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Lutte")]
        public int Lutte { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "LutteBonus")]
        public int? LutteBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "HP")]
        public int HP { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Deplacement")]
        public int Deplacement { get; set; }

        // Défense
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "AC")]
        public int? AC { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NaturalAC")]
        public int? NaturalAC { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "ACBonus")]
        public int? ACBonus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "ResistanceSort")]
        public int? ResistanceSort { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "ReductionDegat")]
        public int? ReductionDegat { get; set; }

        // Arme
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NomArme")]
        public string NomArme { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Degats")]
        public string Degats { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Hit")]
        public int? Hit { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Crit")]
        public string Crit { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Munition")]
        public int? Munition { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "DetailsArme")]
        public string DetailsArme { get; set; }

        // Arme2
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NomArme2")]
        public string NomArme2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Degats2")]
        public string Degats2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Hit2")]
        public int? Hit2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Crit2")]
        public string Crit2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Munition2")]
        public int? Munition2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "DetailsArme2")]
        public string DetailsArme2 { get; set; }

        // Armure
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NomArmure")]
        public string NomArmure { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "ArmureAC")]
        public int? ArmureAC { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "TypeArmure")]
        public string TypeArmure { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Malus")]
        public int? Malus { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "DetailsArmure")]
        public string DetailsArmure { get; set; }

        // Armure
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "NomBouclier")]
        public string NomBouclier { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "BouclierAC")]
        public int? BouclierAC { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "MalusBouclier")]
        public int? MalusBouclier { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "DetailsBouclier")]
        public string DetailsBouclier { get; set; }

        // Skills
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Appraise")]
        public int? Appraise { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Balance")]
        public int? Balance { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Bluff")]
        public int? Bluff { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Climb")]
        public int? Climb { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Concentration")]
        public int? Concentration { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft1")]
        public int? Craft1 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft1Nom")]
        public string Craft1Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft2")]
        public int? Craft2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft2Nom")]
        public string Craft2Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft3")]
        public int? Craft3 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Craft3Nom")]
        public string Craft3Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Decipher")]
        public int? Decipher { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Diplomacy")]
        public int? Diplomacy { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "DisableDevice")]
        public int? DisableDevice { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Disguise")]
        public int? Disguise { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "EscapeArtist")]
        public int? EscapeArtist { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Forgery")]
        public int? Forgery { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "GatherInfo")]
        public int? GatherInfo { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "HandleAnimal")]
        public int? HandleAnimal { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Heal")]
        public int? Heal { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Hide")]
        public int? Hide { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Intimidate")]
        public int? Intimidate { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Jump")]
        public int? Jump { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge1")]
        public int? Knowledge1 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge1Nom")]
        public string Knowledge1Name { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge2")]
        public int? Knowledge2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge2Nom")]
        public string Knowledge2Name { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge3")]
        public int? Knowledge3 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge3Nom")]
        public string Knowledge3Name { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge4")]
        public int? Knowledge4 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge4Nom")]
        public string Knowledge4Name { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge5")]
        public int? Knowledge5 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Knowledge5Nom")]
        public string Knowledge5Name { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Listen")]
        public int? Listen { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "MoveSilently")]
        public int? MoveSilently { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "OpenLock")]
        public int? OpenLock { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Perform1")]
        public int? Perform1 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Perform1Nom")]
        public string Perform1Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Perform2")]
        public int? Perform2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Perform2Nom")]
        public string Perform2Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Profession1")]
        public int? Profession1 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Profession1Nom")]
        public string Profession1Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Profession2")]
        public int? Profession2 { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Profession2Nom")]
        public string Profession2Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Ride")]
        public int? Ride { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Search")]
        public int? Search { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "SenseMotive")]
        public int? SenseMotive { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "SleightOfHand")]
        public int? SleightOfHand { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Spellcraft")]
        public int? Spellcraft { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Spot")]
        public int? Spot { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Survival")]
        public int? Survival { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Swim")]
        public int? Swim { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Tumble")]
        public int? Tumble { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "UMD")]
        public int? UMD { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "UseRope")]
        public int? UseRope { get; set; }

        // Autre
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Note")]
        public string Notes { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Gold")]
        public int? Gold { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Personnages.PersoRessources), Name = "Experience")]
        public int? Experience { get; set; }
        // Liens
        public int JoueurID { get; set; }
    }
}