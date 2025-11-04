using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Colis
{
    public class UpdateColisRequest
    {
        // Tous les champs sont OPTIONNELS
        public string? Description { get; set; }
        public decimal? Poids { get; set; }           // decimal? OBLIGATOIRE
        public string? AdresseDepart { get; set; }
        public string? AdresseArrivee { get; set; }
        public int? IdClient { get; set; }            // int? OK
    }
}