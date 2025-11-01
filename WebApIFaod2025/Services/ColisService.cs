using Microsoft.AspNetCore.Cors.Infrastructure;
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
    }
    public class ColisService : IColisService
    {
        private readonly bdTracking01Context _context;

        public ColisService(bdTracking01Context context)
        {
            _context = context;
        }

        //public Colis CreateColis(CreateColisRequest model)
        //{
        //    var year = DateTime.UtcNow.Year;
        //    var count = _context.Colis.Count(c => c.DateCreation.Year == year) + 1;
        //    var codeColis = $"COL-{year}-{count:D4}";

        //    var colis = new Colis
        //    {
        //        CodeColis = codeColis,
        //        Description = model.Description,
        //        Poids = model.Poids,
        //        AdresseDepart = model.AdresseDepart,
        //        AdresseArrivee = model.AdresseArrivee,
        //        StatutLivraison = "En attente"
        //    };

        //    _context.Colis.Add(colis);
        //    _context.SaveChanges();
        //    return colis;
        //}

        public Colis CreateColis(CreateColisRequest model)
        {
            var client = _context.UsersColis.Find(model.IdClient)
                ?? throw new KeyNotFoundException("Client non trouvé");

            if (client.Role != "Client")
                throw new AppException("L'ID fourni n'est pas un Client");

            var year = DateTime.Now.Year;
            var count = _context.Colis.Count(c => c.DateCreation.Year == year) + 1;
            var codeColis = $"COL-{year}-{count:D4}";

            var colis = new Colis
            {
                CodeColis = codeColis,
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

        public IEnumerable<Colis> GetAll()
        {
            return _context.Colis.ToList();
        }

        public Colis? GetById(int id)
        {
            return _context.Colis.Find(id);
        }
    }
}