using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class DemandeColis
    {
        [Key]
        public int IdDemande { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required, MaxLength(150)]
        public string AdresseEnlevement { get; set; }

        [Required, MaxLength(150)]
        public string AdresseLivraison { get; set; }

        public float PoidsEstime { get; set; }

        [Required, MaxLength(20)]
        public string TypeColis { get; set; }

        public DateTime DateDemande { get; set; } = DateTime.Now;

        [Required, MaxLength(20)]
        public string Statut { get; set; } = "En attente"; // En attente, Validée, Refusée
    }
}