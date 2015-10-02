using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Membre
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Depuis { get; set; }
        public DateTime Age { get; set; }
        public bool Maitre { get; set; }

    }
}