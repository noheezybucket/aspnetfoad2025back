using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AspNetMvcFoad2025.Models
{
	public class Client:UsersColis
	{
        [MaxLength(160), Display(Name = "Code Client"), Required(ErrorMessage = "^*")]
        public String CodeClient { get; set; }
       
    }
}