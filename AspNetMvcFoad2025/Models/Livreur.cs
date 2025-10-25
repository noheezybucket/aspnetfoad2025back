using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcFoad2025.Models
{
	public class Livreur:UsersColis
	{

        [MaxLength(20), Display(Name = "Matricule"), Required(ErrorMessage = "^*")]
        public String Matricule { get; set; }


        [MaxLength(80), Display(Name = "Carte Gris"), Required(ErrorMessage = "^*")]
        public String CarteGris { get; set; }


        [MaxLength(25), Display(Name = "Permis"), Required(ErrorMessage = "^*")]
        public String Premis { get; set; }


    }
}