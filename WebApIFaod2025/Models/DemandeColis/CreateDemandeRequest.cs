using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.DemandeColis
{
    public class CreateDemandeRequest
    {
        [Required]
        public int ClientId { get; set; }

        [Required, MaxLength(150)]
        public string AdresseEnlevement { get; set; }

        [Required, MaxLength(150)]
        public string AdresseLivraison { get; set; }

        [Required]
        public float PoidsEstime { get; set; }

        [Required, MaxLength(20)]
        public string TypeColis { get; set; }
    }
}