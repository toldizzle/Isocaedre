﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class AspNetUsersInfoSup
    {
        //[Key]
        public string ID { get; set; }
        public string Role { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }

    }
}