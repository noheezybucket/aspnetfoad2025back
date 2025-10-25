using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AspNetMvcFoad2025.Controllers;
namespace AspNetMvcFoad2025.Models
{
	public class BdTrackingContext: DbContext
	{
		public BdTrackingContext(): base("connBdTracking")
		{

		}
		public DbSet<Colis> colis { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<DemandeColis> demandeColis{ get; set; }
        public DbSet<SuiviDemande> SuiviDemandes { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<UsersColis> usersColis { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }

        public DbSet<Animal> Animals { get; set; }









    }
}