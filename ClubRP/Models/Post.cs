﻿using System;
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
        public string Description { get; set; }
        public DateTime Creation = DateTime.Now;
        public int NbReponse { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }

    }
}