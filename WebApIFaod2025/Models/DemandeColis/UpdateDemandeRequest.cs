using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.DemandeColis
{
    public class UpdateDemandeRequest
    {
        public int IdDemande { get; set; }

        public int ClientId { get; set; }

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public string AdresseEnlevement { get; set; }

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public string AdresseLivraison { get; set; }

        public float PoidsEstime { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string TypeColis { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string Statut { get; set; } // En attente, Validée, Refusée
    }
}