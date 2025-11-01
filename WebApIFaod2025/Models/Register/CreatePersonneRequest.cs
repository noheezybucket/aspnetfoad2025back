using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.Register
{
    public class CreatePersonneRequest
    {
        [MaxLength(50), Required(ErrorMessage = "^*")]
        public string Nom { get; set; } = null!;

        [MaxLength(50), Required(ErrorMessage = "^*")]
        public string Prenom { get; set; } = null!;

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public string Telephone { get; set; } = null!;

        [MaxLength(200), Required(ErrorMessage = "^*")]
        public string Adress { get; set; } = null!;

        [MaxLength(100), Required(ErrorMessage = "^*")]
        public string Email { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!; // "Client" ou "Livreur"
    }
}