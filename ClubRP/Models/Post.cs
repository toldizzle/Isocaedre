using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Message { get; set; }
        public DateTime Creation { get; set; }
        public int NbReponse { get; set; }

    }
}