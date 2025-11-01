//using System.ComponentModel.DataAnnotations;

//namespace WebApIFaod2025.Models.Colis
//{
//    public class CreateColisRequest
//    {
//        [Required, MaxLength(15)]
//        public string CodeColis { get; set; }

//        [Required, MaxLength(80)]
//        public string LibelleColis { get; set; }

//        [Required, MaxLength(1000)]
//        public string DescriptionColis { get; set; }

//        [Required]
//        public float PoidsColis { get; set; }

//        [Required, MaxLength(20)]
//        public string TypeColis { get; set; } // Standard, Express, Fragile
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Colis
{
    public class CreateColisRequest
    {

        [Required]
        public int IdClient { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Poids { get; set; }

        [Required]
        public string AdresseDepart { get; set; } = null!;

        [Required]
        public string AdresseArrivee { get; set; } = null!;
    }
}