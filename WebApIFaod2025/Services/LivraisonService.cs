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
        Livraison? AnnulerLivraison(int id);
        Livraison? ReprendreLivraison(int id);
    }

    public class LivraisonService : ILivraisonService
    {
        private readonly bdTracking01Context _context;

        public LivraisonService(bdTracking01Context context) => _context = context;

        public Livraison CreateLivraison(CreateLivraisonRequest model)
        {
            // RÉCUPÈRE LE COLIS + SON CLIENT
            var colis = _context.Colis
                .Include(c => c.Client)
                .FirstOrDefault(c => c.IdColis == model.IdColis)
                ?? throw new KeyNotFoundException("Colis non trouvé");

            if (colis.StatutLivraison != "En attente")
                throw new AppException("Ce colis est déjà en livraison");

            // VÉRIFIE LE LIVREUR
            var livreur = _context.UsersColis.Find(model.IdLivreur);
            if (livreur == null)
                throw new KeyNotFoundException("Livreur non trouvé");

            if (livreur.Role != "Livreur")
                throw new AppException("L'utilisateur sélectionné n'est pas un Livreur");

            // CRÉE LA LIVRAISON
            var livraison = new Livraison
            {
                IdColis = model.IdColis,
                IdClient = colis.IdClient,
                IdLivreur = model.IdLivreur,
                Statut = "En cours",
                DateDebut = DateTime.UtcNow
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

            if (livraison == null)
                throw new KeyNotFoundException("Livraison non trouvée");

            if (livraison.Statut == "Terminé")
                throw new AppException("Cette livraison est déjà terminée");

            // METTRE À JOUR
            livraison.Statut = "Terminé";
            livraison.DateFin = DateTime.UtcNow;
            livraison.Colis.StatutLivraison = "Livré";

            _context.SaveChanges();
            return livraison;
        }

        public Livraison? ReprendreLivraison(int id)
        {
            var livraison = _context.Livraisons
                .Include(l => l.Colis)
                .FirstOrDefault(l => l.IdLivraison == id);

            if (livraison == null)
                throw new KeyNotFoundException("Livraison non trouvée");

            if (livraison.Statut != "Annulé")
                throw new AppException("Seules les livraisons annulées peuvent être reprises");

            if (livraison.Colis.StatutLivraison != "En attente")
                throw new AppException("Le colis n'est plus en attente");

            // REPRENDRE
            livraison.Statut = "En cours";
            livraison.Colis.StatutLivraison = "En cours";

            _context.SaveChanges();
            return livraison;
        }

        public Livraison? AnnulerLivraison(int id)
        {
            var livraison = _context.Livraisons
                .Include(l => l.Colis)
                .FirstOrDefault(l => l.IdLivraison == id);

            if (livraison == null)
                throw new KeyNotFoundException("Livraison non trouvée");

            if (livraison.Statut == "Terminé")
                throw new AppException("Impossible d'annuler une livraison terminée");

            if (livraison.Statut == "Annulé")
                throw new AppException("Cette livraison est déjà annulée");

            // ANNULATION
            livraison.Statut = "Annulé";
            livraison.Colis.StatutLivraison = "Annulé";

            _context.SaveChanges();
            return livraison;
        }
    }
}