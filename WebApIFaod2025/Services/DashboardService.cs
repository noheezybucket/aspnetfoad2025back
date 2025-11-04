using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Helpers;

namespace WebApIFaod2025.Services
{
    public interface IDashboardService
    {
        object GetStats();  
    }
    public class DashboardService : IDashboardService
    {
        private readonly bdTracking01Context _context;

        public DashboardService(bdTracking01Context context)
        {
            _context = context;
        }


        public object GetStats()
        {
            // COLIS
            var colisStats = _context.Colis
                .GroupBy(c => c.StatutLivraison)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Statut, x => x.Count);

            var colis = new
            {
                total = colisStats.Values.Sum(),
                enAttente = colisStats.GetValueOrDefault("En attente"),
                enCours = colisStats.GetValueOrDefault("En cours"),
                livre = colisStats.GetValueOrDefault("Livré"),
                annule = colisStats.GetValueOrDefault("Annulé")
            };

            // LIVRAISONS
            var livraisonStats = _context.Livraisons
                .GroupBy(l => l.Statut)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Statut, x => x.Count);

            var livraisons = new
            {
                total = livraisonStats.Values.Sum(),
                enCours = livraisonStats.GetValueOrDefault("En cours"),
                terminee = livraisonStats.GetValueOrDefault("Terminé"),
                annulee = livraisonStats.GetValueOrDefault("Annulé")
            };

            // CLIENTS
            var clientStats = _context.UsersColis
                .Where(u => u.Role == "Client")
                .GroupBy(u => u.Statut)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Statut, x => x.Count);

            var clients = new
            {
                total = clientStats.Values.Sum(),
                actif = clientStats.GetValueOrDefault("Actif"),
                inactif = clientStats.GetValueOrDefault("Inactif")
            };

            // LIVREURS
            var livreurStats = _context.UsersColis
                .Where(u => u.Role == "Livreur")
                .GroupBy(u => u.Statut)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Statut, x => x.Count);

            var livreurs = new
            {
                total = livreurStats.Values.Sum(),
                actif = livreurStats.GetValueOrDefault("Actif"),
                inactif = livreurStats.GetValueOrDefault("Inactif")
            };

            return new { colis, livraisons, clients, livreurs };
        }
    }
}