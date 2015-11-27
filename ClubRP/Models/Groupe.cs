using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Groupe
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "Title")]
        public string Titre { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "Description")]
        public string Description { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "Creation")]
        public DateTime Creation { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "UserID")]
        public string AspNetUserID { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "Author")]
        public string Auteur { get; set; }
        public virtual ICollection<Joueur> Joueurs { get; set; }
    }
}