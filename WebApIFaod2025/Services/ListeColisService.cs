using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Helpers;

namespace WebApIFaod2025.Services
{
    public interface IListeColisService
    {
        IEnumerable<object> GetListePourLivreur(int livreurId);
    }

    public class ListeColisService : IListeColisService
    {
        private readonly bdTracking01Context _context;

        public ListeColisService(bdTracking01Context context)
        {
            _context = context;
        }

        public IEnumerable<object> GetListePourLivreur(int livreurId)
        {
            var result = _context.Livraisons
                .Where(l => l.IdLivreur == livreurId)
                .Include(l => l.Colis)
                .Include(l => l.Client)
                .Select(l => new
                {
                    Colis = new
                    {
                        l.Colis.IdColis,
                        l.Colis.CodeColis,
                        l.Colis.Description,
                        l.Colis.Poids,
                        l.Colis.AdresseDepart,
                        l.Colis.AdresseArrivee,
                        l.Colis.StatutLivraison
                    },
                    Client = new
                    {
                        l.Client.IdUsersColis,
                        l.Client.Nom,
                        l.Client.Prenom,
                        l.Client.Telephone,
                        l.Client.Adresse
                    },
                    Livraison = new
                    {
                        l.IdLivraison,
                        l.Statut,
                        l.DateDebut,
                        l.DateFin
                    }
                })
                .ToList();

            return result.Cast<object>();
        }
    }
}