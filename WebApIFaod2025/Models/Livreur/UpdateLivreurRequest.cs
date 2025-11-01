using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Livreur
{
    public class UpdateLivreurRequest
    {
        public int IdUsersColis { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string Matricule { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string CarteGris { get; set; }

        [MaxLength(25), Required(ErrorMessage = "^*")]
        public string Permis { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Nom { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Prenom { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string CNI { get; set; }

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public string Telephone { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Email { get; set; }

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public string Adresse { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Statut { get; set; }
    }
}