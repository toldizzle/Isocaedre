using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ClubRP.Models
{
    public class AspNetUsersInfoSup
    {
        [Key]
        public string ID { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Membres.MembreRessources), Name = "Role")]
        public string Role { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Membres.MembreRessources), Name = "LName")]
        public string Nom { get; set; }
        [Display(ResourceType = typeof(ClubRP.Views.Membres.MembreRessources), Name = "FName")]
        public string Prenom { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
        public virtual Joueur Joueur { get; set; }
    }
}