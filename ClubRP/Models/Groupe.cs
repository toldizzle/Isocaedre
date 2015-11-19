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
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
        public string AspNetUserID { get; set; }
        public string Auteur { get; set; }
        public virtual ICollection<Joueur> Joueurs { get; set; }
    }
}