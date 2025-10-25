namespace WebApIFaod2025.Models.UsersColis
{
    using System.ComponentModel.DataAnnotations;
    using WebApIFaod2025.Entities;
    public class CreateRequest

    {
        [MaxLength(80), Required(ErrorMessage = "^*")]
        public String Nom { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public String Prénoom { get; set; }

        [MaxLength(20), Required(ErrorMessage = "^*")]
        public String CNI { get; set; }

        [MaxLength(15), Required(ErrorMessage = "^*")]
        public String Telephone { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public String Email { get; set; }

        [MaxLength(150), Required(ErrorMessage = "^*")]
        public String Adress { get; set; }

        [MaxLength(80), Required(ErrorMessage = "^*")]
        public String Statut { get; set; }
    }
}
