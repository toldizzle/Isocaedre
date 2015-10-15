using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Titre { get; set; }
        public string Texte { get; set; }
        //Foreign key (Lazy Load)
        public int PostID { get; set; }
    }
}