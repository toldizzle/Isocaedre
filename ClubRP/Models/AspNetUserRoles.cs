using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class AspNetUserRoles
    {
        //[Key]
        public string ID { get; set; }
        public DateTime DateInscription { get; set; }
        public ApplicationIdentity IdentifiantSTH { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }

    }
}