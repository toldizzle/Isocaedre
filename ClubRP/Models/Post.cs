using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Post
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Creation { get; set; }
        public int NbReponse { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}