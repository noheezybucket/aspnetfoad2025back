using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Entities;
namespace WebApIFaod2025.Helpers
{
    public class bdTracking01Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public bdTracking01Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connexion à PostgreSQL avec la chaîne depuis appsettings.json
            options.UseNpgsql(Configuration.GetConnectionString("connDbTracting"));
        }

        public DbSet<UsersColis> UsersColis { get; set; }
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Client> Clients { get; set; }




    }
}
