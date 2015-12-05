using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Joueur
    {
        [Key]
        public int JoueurID { get; set; }
        public string AspNetUserID { get; set; }
        public string Nom { get; set; }
        [Required]
        public bool Maitre { get; set; }
        public string Specialisation { get; set; }
        public int? GroupeID { get; set; }
        public virtual Personnage Personnage { get; set; }
    }
}