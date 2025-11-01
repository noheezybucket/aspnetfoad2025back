//using System.ComponentModel.DataAnnotations;

//namespace WebApIFaod2025.Entities
//{
//    public class UsersColis
//    {
//        [Key]
//        public int IdUsersColis { get; set; }

//        [MaxLength(80),  Required(ErrorMessage = "^*")]
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

//using System.ComponentModel.DataAnnotations;

//namespace WebApIFaod2025.Entities
//{
//    public class UsersColis
//    {
//        [Key]
//        public int IdUsersColis { get; set; }

//        [Required, MaxLength(50)]
//        public string Nom { get; set; } = null!;

//        [Required, MaxLength(50)]
//        public string Prenom { get; set; } = null!;

//        [MaxLength(20)]
//        public string Telephone { get; set; } = null!;

//        [MaxLength(150)]
//        public string Adresse { get; set; } = null!;

//        [Required, MaxLength(20)]
//        public string Role { get; set; } = "Client"; // Client ou Livreur
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class UsersColis
    {
        [Key]
        public int IdUsersColis { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Nom { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Prenom { get; set; } = null!;

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public string CNI { get; set; } = null!;

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public string Telephone { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Email { get; set; } = null!; // EXISTE !

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public string Adresse { get; set; } = null!;

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public string Statut { get; set; } = "actif";

        [MaxLength(20), Required]
        public string Role { get; set; } = "Client"; // "Client" ou "Livreur"
    }
}