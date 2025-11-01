using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class SuiviCommande
    {
        [Key]
        public int IdSuivi { get; set; }

        public int ColisId { get; set; }
        public Colis Colis { get; set; }

        [Required, MaxLength(50)]
        public string Statut { get; set; }

        public DateTime DateMiseAJour { get; set; } = DateTime.Now;

        [MaxLength(100)]
        public string PositionGPS { get; set; }

        [MaxLength(500)]
        public string Commentaire { get; set; }
    }
}