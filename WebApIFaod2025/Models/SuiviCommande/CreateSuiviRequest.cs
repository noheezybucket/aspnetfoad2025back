using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.SuiviCommande
{
    public class CreateSuiviRequest
    {
        [Required]
        public int ColisId { get; set; }

        [Required, MaxLength(50)]
        public string Statut { get; set; } = "En attente"; // En attente, Pris, En cours, Livré

        [MaxLength(100)]
        public string? PositionGPS { get; set; }

        [MaxLength(500)]
        public string? Commentaire { get; set; }
    }
}