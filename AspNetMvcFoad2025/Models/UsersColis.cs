using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcFoad2025.Models
{
	public class UsersColis
	{
		[Key]
		public int IdUsersColis { get; set; }

        [MaxLength(80), Display(Name = "Nom"), Required(ErrorMessage = "^*")]
        public String Nom { get; set; }

        [MaxLength(80), Display(Name = "Prenom"), Required(ErrorMessage = "^*")]
        public String Prénoom { get; set; }

        [MaxLength(20), Display(Name = "CNI"), Required(ErrorMessage = "^*")]
        public String CNI { get; set; }

        [MaxLength(15), Display(Name = "Telephone"), Required(ErrorMessage = "^*")]
        public String Telephone { get; set; }

        [MaxLength(80), Display(Name = "Email"), Required(ErrorMessage = "^*")]
        public String Email { get; set; }

        [MaxLength(150), Display(Name = "Adress"), Required(ErrorMessage = "^*")]
        public String Adress { get; set; }

        [MaxLength(80), Display(Name = "Statut"), Required(ErrorMessage = "^*")]
        public String Statut { get; set; }


    }
}