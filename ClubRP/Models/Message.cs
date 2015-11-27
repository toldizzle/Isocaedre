using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ClubRP.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Display(ResourceType = typeof(ClubRP.Views.Membres.MembreRessources), Name = "User")]
        public string AspNetUserID { get; set; }

        [Display(ResourceType = typeof(ClubRP.Views.Groupes.GroupeRessources), Name = "Author")]
        public string Auteur { get; set; }

        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(ClubRP.Views.Messages.MessageRessources), Name = "Content")]
        public string Texte { get; set; }

        public DateTime DateMessage { get; set; }

        //Foreign key (Lazy Load)
        public int PostID { get; set; }
    }
}