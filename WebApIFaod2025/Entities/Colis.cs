using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class Colis
    {

        [Key]
        public int IdColis { get; set; }

        [MaxLength(15),  Required(ErrorMessage = "^*")]
        public String CodeColis { get; set; }

        [MaxLength(80),  Required(ErrorMessage = "^*")]
        public String libelleColis { get; set; }

        [MaxLength(1000), Required(ErrorMessage = "^*")]
        public String DescriptionColis { get; set; }

        public float PoidsColis { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public String TypeColis { get; set; }
    }
}
