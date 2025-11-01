using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Colis
{
    public class UpdateColisRequest
    {
        public int IdColis { get; set; }

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public string CodeColis { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string LibelleColis { get; set; }

        [MaxLength(1000), Required(ErrorMessage = "^*")]
        public string DescriptionColis { get; set; }

        public float PoidsColis { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string TypeColis { get; set; }

        public int? LivreurId { get; set; }
        public int? ClientId { get; set; }
    }
}