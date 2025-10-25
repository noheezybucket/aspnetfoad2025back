using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Routing;

namespace AspNetMvcFoad2025.Models
{
	public class Colis
	{
       
        [Key]
		public int IdColis { get; set; }

		[MaxLength(15) , Display (Name ="Code colis"), Required (ErrorMessage ="^*")]
		public String CodeColis { get; set; }

        [MaxLength(80), Display(Name = "Libelle colis"), Required(ErrorMessage = "^*")]
        public String libelleColis { get; set; }

        [MaxLength(1000), Display(Name = "Desciption colis"), Required(ErrorMessage = "^*")]
        public String DescriptionColis { get; set; }

        [ Display(Name = "Poids colis"), Required(ErrorMessage = "^*")]
        public float PoidsColis { get; set; }

        [MaxLength(20), Display(Name = "Type colis"), Required(ErrorMessage = "^*")]
        public String TypeColis { get; set; }


    }


}