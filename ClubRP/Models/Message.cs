using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string AspNetUserID { get; set; }
        public string Auteur { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
        [DataType(DataType.MultilineText)]
        public string Texte { get; set; }
        public DateTime DateMessage { get; set; }
        //Foreign key (Lazy Load)
        public int PostID { get; set; }
    }
}