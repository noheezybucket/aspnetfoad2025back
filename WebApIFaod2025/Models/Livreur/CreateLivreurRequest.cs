using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Livreur
{
    public class CreateLivreurRequest
    {
        [Required, MaxLength(20)]
        public string Matricule { get; set; }

        [Required, MaxLength(80)]
        public string CarteGris { get; set; }

        [Required, MaxLength(25)]
        public string Permis { get; set; }

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
        public string Statut { get; set; } = "Disponible";
    }
}