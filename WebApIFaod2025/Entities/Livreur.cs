using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class Livreur:UsersColis
    {

        [MaxLength(20),  Required(ErrorMessage = "^*")]
        public String Matricule { get; set; }


        [MaxLength(80),  Required(ErrorMessage = "^*")]
        public String CarteGris { get; set; }


        [MaxLength(25),  Required(ErrorMessage = "^*")]
        public String Premis { get; set; }
    }
}
