//namespace WebApIFaod2025.Models.UsersColis
//{
//    using System.ComponentModel.DataAnnotations;
//    using WebApIFaod2025.Entities;
//    public class CreateRequest

//    {
//        [MaxLength(80), Required(ErrorMessage = "^*")]
//        public String Nom { get; set; }

//        [MaxLength(80), Required(ErrorMessage = "^*")]
//        public String Prenom { get; set; }

//        [MaxLength(20), Required(ErrorMessage = "^*")]
//        public String CNI { get; set; }

//        [MaxLength(15), Required(ErrorMessage = "^*")]
//        public String Telephone { get; set; }

//        [MaxLength(80), Required(ErrorMessage = "^*")]
//        public String Email { get; set; }

//        [MaxLength(150), Required(ErrorMessage = "^*")]
//        public String Adresse { get; set; }

//        [MaxLength(80), Required(ErrorMessage = "^*")]
//        public String Statut { get; set; }
//    }
//}


using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Models.UsersColis
{
    public class CreateRequest
    {
        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Nom { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Prenom { get; set; } = null!;

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string CNI { get; set; } = null!;

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public string Telephone { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Email { get; set; } = null!;

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public string Adresse { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Statut { get; set; } = "Actif";

        [Required]
        public string Role { get; set; } = "Client"; // "Client" ou "Livreur"
    }
}