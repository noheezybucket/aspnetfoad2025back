//using System.ComponentModel.DataAnnotations;

//namespace WebApIFaod2025.Models.Livraison
//{
//    public class CreateLivraisonRequest
//    {
//        [Required]
//        public int IdClient { get; set; }

//        [Required]
//        public int IdLivreur { get; set; }

//        [Required]
//        public string DescriptionColis { get; set; } = null!;

//        [Required]
//        public decimal Poids { get; set; }

//        [Required]
//        public string AdresseDepart { get; set; } = null!;

//        [Required]
//        public string AdresseArrivee { get; set; } = null!;
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Livraison
{
    public class CreateLivraisonRequest
    {
        [Required]
        public int IdColis { get; set; }

        [Required]
        public int IdLivreur { get; set; }
    }
}