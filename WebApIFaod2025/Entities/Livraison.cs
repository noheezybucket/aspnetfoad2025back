//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApIFaod2025.Entities
//{
//    [Table("Livraisons")]
//    public class Livraison
//    {
//        [Key]
//        public int IdLivraison { get; set; }

//        public int IdColis { get; set; }

//        [Required]
//        public DateTime DateDebut { get; set; } = DateTime.Now;

//        public DateTime? DateFin { get; set; }

//        [MaxLength(20), Required]
//        public string Statut { get; set; } = "En cours"; // "En cours" ou "Terminé"

//        // Navigation
//        [ForeignKey("IdColis")]
//        public virtual Colis Colis { get; set; } = null!;
//    }
//}

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApIFaod2025.Entities
//{
//    [Table("Livraisons")]
//    public class Livraison
//    {
//        [Key]
//        public int IdLivraison { get; set; }

//        public int IdColis { get; set; }
//        public int IdClient { get; set; }
//        public int IdLivreur { get; set; }

//        [Required]
//        public DateTime DateDebut { get; set; } = DateTime.Now;

//        public DateTime? DateFin { get; set; }

//        [MaxLength(20), Required]
//        public string Statut { get; set; } = "En cours"; // En cours | Terminé

//        // Navigation
//        [ForeignKey("IdColis")]
//        public virtual Colis Colis { get; set; } = null!;

//        [ForeignKey("IdClient")]
//        public virtual UsersColis Client { get; set; } = null!;

//        [ForeignKey("IdLivreur")]
//        public virtual UsersColis Livreur { get; set; } = null!;
//    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApIFaod2025.Entities
{
    [Table("Livraisons")]
    public class Livraison
    {
        [Key]
        public int IdLivraison { get; set; }

        public int IdColis { get; set; }
        public int IdClient { get; set; }
        public int IdLivreur { get; set; }  // LIVREUR ICI

        [Required]
        public DateTime DateDebut { get; set; } = DateTime.UtcNow;

        public DateTime? DateFin { get; set; }

        [MaxLength(20), Required]
        public string Statut { get; set; } = "En cours";

        // Navigation
        [ForeignKey("IdColis")]
        public virtual Colis Colis { get; set; } = null!;

        [ForeignKey("IdClient")]
        public virtual UsersColis Client { get; set; } = null!;

        [ForeignKey("IdLivreur")]
        public virtual UsersColis Livreur { get; set; } = null!;  // LIVREUR ICI
    }
}