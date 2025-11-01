using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Livraison;

namespace WebApIFaod2025.Services
{
    public interface ILivraisonService
    {
        Livraison CreateLivraison(CreateLivraisonRequest model);
        IEnumerable<Livraison> GetAll();
        Livraison? TerminerLivraison(int id);
    }
    public class LivraisonService : ILivraisonService
    {
        private readonly bdTracking01Context _context;

        public LivraisonService(bdTracking01Context context)
        {
            _context = context;
        }

        public Livraison CreateLivraison(CreateLivraisonRequest model)
        {
            var colis = _context.Colis.Find(model.IdColis)
                ?? throw new KeyNotFoundException("Colis non trouvé");

            if (colis.StatutLivraison != "En attente")
                throw new AppException("Ce colis est déjà en livraison");

            var client = _context.UsersColis.Find(model.IdClient)
                ?? throw new KeyNotFoundException("Client non trouvé");

            var livreur = _context.UsersColis.Find(model.IdLivreur)
                ?? throw new KeyNotFoundException("Livreur non trouvé");

            if (client.Role != "Client") throw new AppException("IdClient doit être un Client");
            if (livreur.Role != "Livreur") throw new AppException("IdLivreur doit être un Livreur");

            var livraison = new Livraison
            {
                IdColis = model.IdColis,
                IdClient = model.IdClient,
                IdLivreur = model.IdLivreur,  // LIVREUR ICI
                Statut = "En cours"
            };

            colis.StatutLivraison = "En cours";

            _context.Livraisons.Add(livraison);
            _context.SaveChanges();

            return livraison;
        }

        public IEnumerable<Livraison> GetAll()
        {
            return _context.Livraisons
                .Include(l => l.Colis)
                .Include(l => l.Client)
                .Include(l => l.Livreur)
                .ToList();
        }

        public Livraison? TerminerLivraison(int id)
        {
            var livraison = _context.Livraisons
                .Include(l => l.Colis)
                .FirstOrDefault(l => l.IdLivraison == id);

            if (livraison == null || livraison.Statut == "Terminé") return livraison;

            livraison.Statut = "Terminé";
            livraison.DateFin = DateTime.UtcNow;
            livraison.Colis.StatutLivraison = "Livré";

            _context.SaveChanges();
            return livraison;
        }
    }
}