using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Client
{
    public class CreateClientRequest
    {
        [Required, MaxLength(160)]
        public string CodeClient { get; set; }

        [Required, MaxLength(80)]
        public string Nom { get; set; }

        [Required, MaxLength(80)]
        public string Prenom { get; set; }

        [Required, MaxLength(20)]
        public string CNI { get; set; }

        [Required, MaxLength(15)]
        public string Telephone { get; set; }

        [Required, MaxLength(80)]
        public string Email { get; set; }

        [Required, MaxLength(150)]
        public string Adresse { get; set; }

        [Required, MaxLength(80)]
        public string Statut { get; set; } = "Actif";
    }
}