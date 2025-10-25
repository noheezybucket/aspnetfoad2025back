using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvcFoad2025.Models
{
	public class Animal
	{
        
        

            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Le nom est obligatoire")]
            [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères")]
            public string Nom { get; set; }

            [Required(ErrorMessage = "*")]
            public string Type { get; set; }

            [Required(ErrorMessage = "*")]
            public string Sexe { get; set; }

            [Range(0.1, 1000, ErrorMessage = "Le poids doit être compris entre 0.1 et 1000 kg")]
            public double Poids { get; set; }

            [Range(0.1, 10, ErrorMessage = "La taille doit être comprise entre 0.1 et 10 m")]
            public double Taille { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Date de naissance")]
            public DateTime DateNaissance { get; set; }
        
    }
}