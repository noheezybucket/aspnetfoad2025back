using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvcFoad2025.Models
{
	public class SuiviDemande
	{
		[Key]
		public int IdSuiviDemande { get; set; }

        [MaxLength(15), Display(Name = "Nom"), Required(ErrorMessage = "^*")]
        public String Nom { get; set; }


        [ Display(Name = "Latitude"), Required(ErrorMessage = "^*")]
        public float Latitude { get; set; }


        [Display(Name = "Longitude"), Required(ErrorMessage = "^*")]
        public float Longitude { get; set; }


        [Display(Name = "Demande")]
        public int? IdDemande { get; set; }
        [ForeignKey("IdDemande")]
        public virtual DemandeColis DemandeColis { get; set; }


    }
}