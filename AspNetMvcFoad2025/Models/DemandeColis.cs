using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcFoad2025.Models
{
	public class DemandeColis
	{
		[Key]
		public int IdDemandeColis { get; set; }

		[Display(Name ="Client")]
		public int? IdClient { get; set; }
		[ForeignKey("IdClient")]
		public virtual Client Client { get; set; }

        [Display(Name = "Livreur")]
        public int? IdLivreur { get; set; }
        [ForeignKey("IdLivreur")]
        public virtual Livreur Livreur { get; set; }

        [Display(Name = "Colis")]
        public int? IdColis { get; set; }
        [ForeignKey("IdColis")]
        public virtual Colis Colis { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Liver"), Required(ErrorMessage = "^*")]
        public DateTime? DateLiver { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Souhaiter"), Required(ErrorMessage = "^*")]
        public DateTime? DateSouhaiter { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Demander"), Required(ErrorMessage = "^*")]
        public DateTime? DateDemander { get; set; }

        [MaxLength(25), Display(Name = "Statut"), Required(ErrorMessage = "^*")]
        public String Statut { get; set; }


        [MaxLength(25), Display(Name = "Lieu Depart"), Required(ErrorMessage = "^*")]
        public String LieuDepart { get; set; }


        [MaxLength(25), Display(Name = "Lieu Arriver"), Required(ErrorMessage = "^*")]
        public String LieuArriver { get; set; }


        [Display(Name = "Prix"), Required(ErrorMessage = "^*")]
        public float Prix { get; set; }


    }
}