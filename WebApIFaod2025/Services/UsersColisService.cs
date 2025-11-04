using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.UsersColis;

namespace WebApIFaod2025.Services
{
    public interface IUsersColisService
    {
        IEnumerable<UsersColis> GetAll();
        UsersColis GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        //void Delete(int id);
        void Deactivate(int id);
    }

    public class UsersColisService : IUsersColisService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;

        public UsersColisService(bdTracking01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UsersColis> GetAll()
        {
            return _context.UsersColis;
        }

        public UsersColis GetById(int id)
        {
            return getUserColis(id);
        }

        public void Create(CreateRequest model)
        {
            if (_context.UsersColis.Any(x => x.Email == model.Email))
                throw new AppException("User avec cet email '" + model.Email + "' existe déjà");

            var user = _mapper.Map<UsersColis>(model);
            _context.UsersColis.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = GetUser(id);

            // VÉRIFIE L'EMAIL (si fourni et différent)
            if (!string.IsNullOrEmpty(model.Email) && model.Email != user.Email)
            {
                if (_context.UsersColis.Any(x => x.Email == model.Email))
                    throw new AppException($"Email '{model.Email}' déjà utilisé");

                user.Email = model.Email;
            }

            // MISE À JOUR CONDITIONNELLE
            if (!string.IsNullOrEmpty(model.Nom))
                user.Nom = model.Nom;

            if (!string.IsNullOrEmpty(model.Prenom))
                user.Prenom = model.Prenom;

            if (!string.IsNullOrEmpty(model.CNI))
                user.CNI = model.CNI;

            if (!string.IsNullOrEmpty(model.Telephone))
                user.Telephone = model.Telephone;

            if (!string.IsNullOrEmpty(model.Adresse))
                user.Adresse = model.Adresse;

            if (!string.IsNullOrEmpty(model.Statut))
                user.Statut = model.Statut;

            // SAUVEGARDE
            _context.UsersColis.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);

            // Vérifie s'il est lié à un colis
            if (_context.Colis.Any(c => c.IdClient == id))
                throw new AppException("Impossible de supprimer : cet utilisateur a des colis");

            // Vérifie s'il est lié à une livraison
            if (_context.Livraisons.Any(l => l.IdLivreur == id || l.IdClient == id))
                throw new AppException("Impossible de supprimer : cet utilisateur est dans une livraison");

            _context.UsersColis.Remove(user);
            _context.SaveChanges();
        }

        private UsersColis GetUser(int id)
        {
            var user = _context.UsersColis.Find(id);
            if (user == null) throw new KeyNotFoundException("Utilisateur non trouvé");
            return user;
        }

        public void Deactivate(int id)
        {
            var user = GetUser(id);

            // Vérifie s'il peut être désactivé
            if (user.Role == "Client" && _context.Colis.Any(c => c.IdClient == id && c.StatutLivraison != "Livré"))
                throw new AppException("Impossible de désactiver : le client a des colis en cours");

            if (user.Role == "Livreur" && _context.Livraisons.Any(l => l.IdLivreur == id && l.Statut != "Terminé"))
                throw new AppException("Impossible de désactiver : le livreur a des livraisons en cours");

            user.Statut = "Inactif";
            _context.SaveChanges();
        }

        private UsersColis getUserColis(int id)
        {
            var user = _context.UsersColis.Find(id);
            if (user == null) throw new KeyNotFoundException("Ce user n'existe pas");
            return user;
        }
    }
}