////using System.ComponentModel.DataAnnotations;
////using System.ComponentModel.DataAnnotations.Schema;

////namespace WebApIFaod2025.Entities
////{
////    public class Colis
////    {
////        [Key]
////        public int IdColis { get; set; }

////        [MaxLength(15), Required(ErrorMessage = "^*")]
////        public string CodeColis { get; set; } = null!;

////        [MaxLength(80), Required(ErrorMessage = "^*")]
////        public string LibelleColis { get; set; } = null!;

////        [MaxLength(1000), Required(ErrorMessage = "^*")]
////        public string DescriptionColis { get; set; } = null!;

////        public float PoidsColis { get; set; }

////        [MaxLength(20), Required(ErrorMessage = "^*")]
////        public string TypeColis { get; set; } = null!;

////        // Relation avec Livreur
////        public int? LivreurId { get; set; }

////        // Relation avec Client
////        public int? ClientId { get; set; }

////        // NAVIGATION OBLIGATOIRE
////        [ForeignKey("ClientId")]
////        public virtual Client? Client { get; set; }

////        [ForeignKey("LivreurId")]
////        public virtual Livreur? Livreur { get; set; }

////        // Navigation vers SuiviCommande
////        public virtual ICollection<SuiviCommande> SuiviCommande { get; set; } = new List<SuiviCommande>();
////    }
////}


//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApIFaod2025.Entities
//{
//    [Table("Colis")]
//    public class Colis
//    {
//        [Key]
//        public int IdColis { get; set; }

//        [Required, MaxLength(20)]
//        public string CodeColis { get; set; } = null!; // EX: "COL-2025-001"

//        [MaxLength(100), Required]
//        public string Description { get; set; } = null!;

//        [Required]
//        public decimal Poids { get; set; }

//        [MaxLength(200), Required]
//        public string AdresseDepart { get; set; } = null!;

//        [MaxLength(200), Required]
//        public string AdresseArrivee { get; set; } = null!;

//        [Required]
//        public DateTime DateCreation { get; set; } = DateTime.Now;

//        // Clés étrangères
//        public int IdClient { get; set; }
//        public int? IdLivreur { get; set; }

//        // Navigation
//        [ForeignKey("IdClient")]
//        public virtual UsersColis Client { get; set; } = null!;

//        [ForeignKey("IdLivreur")]
//        public virtual UsersColis? Livreur { get; set; }

//        public virtual Livraison? Livraison { get; set; }
//    }
//}


//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApIFaod2025.Entities
//{
//    [Table("Colis")]
//    public class Colis
//    {
//        [Key]
//        public int IdColis { get; set; }

//        [Required, MaxLength(50)]
//        public string CodeColis { get; set; } = null!;

//        [Required, MaxLength(255)]
//        public string Description { get; set; } = null!;

//        [Required]
//        public decimal Poids { get; set; }

//        [Required, MaxLength(150)]
//        public string AdresseDepart { get; set; } = null!;

//        [Required, MaxLength(150)]
//        public string AdresseArrivee { get; set; } = null!;

//        [Required]
//        public DateTime DateCreation { get; set; } = DateTime.Now;

//        // Relations
//        public int IdClient { get; set; }
//        public int LivreurId { get; set; }

//        [ForeignKey(nameof(IdClient))]
//        public virtual UsersColis Client { get; set; } = null!;

//        [ForeignKey(nameof(LivreurId))]
//        public virtual UsersColis Livreur { get; set; } = null!;

//        public virtual Livraison? Livraison { get; set; }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebApIFaod2025.Entities
//{
//    [Table("Colis")]
//    public class Colis
//    {
//        [Key]
//        public int IdColis { get; set; }

//        [Required, MaxLength(50)]
//        public string CodeColis { get; set; } = null!; // ex: "COL-2025-0001"

//        [Required, MaxLength(255)]
//        public string Description { get; set; } = null!;

//        [Required]
//        public decimal Poids { get; set; }

//        [Required, MaxLength(150)]
//        public string AdresseDepart { get; set; } = null!;

//        [Required, MaxLength(150)]
//        public string AdresseArrivee { get; set; } = null!;

//        [Required]
//        public DateTime DateCreation { get; set; } = DateTime.Now;

//        // Relations avec les utilisateurs
//        public int IdClient { get; set; }
//        public int? LivreurId { get; set; } // le colis peut ne pas avoir de livreur assigné au départ

//        [ForeignKey(nameof(IdClient))]
//        public virtual UsersColis Client { get; set; } = null!;

//        [ForeignKey(nameof(LivreurId))]
//        public virtual UsersColis? Livreur { get; set; }

//        // Relation avec la livraison
//        public virtual Livraison? Livraison { get; set; }

//        // Optionnel : historique ou suivi
//        public virtual ICollection<SuiviCommande> SuiviCommandes { get; set; } = new List<SuiviCommande>();
//    }
//}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApIFaod2025.Entities
{
    [Table("Colis")]
    public class Colis
    {
        [Key]
        public int IdColis { get; set; }

        [Required, MaxLength(20)]
        public string CodeColis { get; set; } = null!;

        [MaxLength(100), Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Poids { get; set; }

        [MaxLength(200), Required]
        public string AdresseDepart { get; set; } = null!;

        [MaxLength(200), Required]
        public string AdresseArrivee { get; set; } = null!;

        [Required]
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        // Statut du colis
        [MaxLength(20), Required]
        public string StatutLivraison { get; set; } = "En attente";

        // CLÉ ÉTRANGÈRE : CLIENT
        [Required]
        public int IdClient { get; set; }

        // NAVIGATION
        [ForeignKey("IdClient")]
        public virtual UsersColis Client { get; set; } = null!;
        [JsonIgnore]
        public virtual Livraison? Livraison { get; set; }
    }
}