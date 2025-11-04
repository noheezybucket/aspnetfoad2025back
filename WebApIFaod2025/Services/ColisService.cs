using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Colis;

namespace WebApIFaod2025.Services
{
    public interface IColisService
    {
        Colis CreateColis(CreateColisRequest model);
        IEnumerable<Colis> GetAll();
        Colis? GetById(int id);
        void Update(int id, UpdateColisRequest model);
        void Delete(int id);
    }
    public class ColisService : IColisService
    {
        private readonly bdTracking01Context _context;

        public ColisService(bdTracking01Context context) => _context = context;

        public Colis CreateColis(CreateColisRequest model)
        {
            var client = _context.UsersColis.Find(model.IdClient)
                ?? throw new KeyNotFoundException("Client non trouvé");

            if (client.Role != "Client")
                throw new AppException("L'ID n'est pas un Client");

            var year = DateTime.Now.Year;
            var count = _context.Colis.Count(c => c.DateCreation.Year == year) + 1;
            var code = $"COL-{year}-{count:D4}";

            var colis = new Colis
            {
                CodeColis = code,
                Description = model.Description,
                Poids = model.Poids,
                AdresseDepart = model.AdresseDepart,
                AdresseArrivee = model.AdresseArrivee,
                IdClient = model.IdClient,
                StatutLivraison = "En attente",
                DateCreation = DateTime.UtcNow
            };

            _context.Colis.Add(colis);
            _context.SaveChanges();
            return colis;
        }

        public IEnumerable<Colis> GetAll() => _context.Colis.ToList();

        public Colis? GetById(int id) => _context.Colis.Find(id);

        public void Update(int id, UpdateColisRequest model)
        {
            var colis = _context.Colis
                .Include(c => c.Client)
                .FirstOrDefault(c => c.IdColis == id)
                ?? throw new KeyNotFoundException("Colis non trouvé");

            if (colis.StatutLivraison == "Livré")
                throw new AppException("Impossible de modifier un colis déjà livré");

            // Mise à jour SEULEMENT si valeur fournie
            if (!string.IsNullOrEmpty(model.Description))
                colis.Description = model.Description;

            if (model.Poids.HasValue)  // OK : decimal?
                colis.Poids = model.Poids.Value;

            if (!string.IsNullOrEmpty(model.AdresseDepart))
                colis.AdresseDepart = model.AdresseDepart;

            if (!string.IsNullOrEmpty(model.AdresseArrivee))
                colis.AdresseArrivee = model.AdresseArrivee;

            // CHANGEMENT DE CLIENT (OPTIONNEL)
            if (model.IdClient.HasValue && model.IdClient.Value != colis.IdClient)
            {
                var nouveauClient = _context.UsersColis.Find(model.IdClient.Value)
                    ?? throw new KeyNotFoundException("Nouveau client non trouvé");

                if (nouveauClient.Role != "Client")
                    throw new AppException("Le nouvel ID doit être un Client");

                colis.IdClient = model.IdClient.Value;
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var colis = _context.Colis.Find(id)
                ?? throw new KeyNotFoundException("Colis non trouvé");

            if (colis.StatutLivraison != "En attente")
                throw new AppException("Seuls les colis en attente peuvent être supprimés");

            if (_context.Livraisons.Any(l => l.IdColis == id))
                throw new AppException("Impossible de supprimer : le colis est en livraison");

            _context.Colis.Remove(colis);
            _context.SaveChanges();
        }
    }
}