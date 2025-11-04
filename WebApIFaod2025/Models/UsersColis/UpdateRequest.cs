//using System.ComponentModel.DataAnnotations;

//namespace WebApIFaod2025.Models.UsersColis
//{
//    public class UpdateRequest
//    {
//        public int IdUsersColis { get; set; }

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
    public class UpdateRequest
    {
        [MaxLength(80)] public string? Nom { get; set; }
        [MaxLength(80)] public string? Prenom { get; set; }
        [MaxLength(20)] public string? CNI { get; set; }
        [MaxLength(15)] public string? Telephone { get; set; }
        [MaxLength(80)] public string? Email { get; set; }
        [MaxLength(150)] public string? Adresse { get; set; }

        [MaxLength(80)] public string? Role { get; set; }
        [MaxLength(80)] public string? Statut { get; set; }
    }
}