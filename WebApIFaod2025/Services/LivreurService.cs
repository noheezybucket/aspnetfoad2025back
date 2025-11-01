using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Livreur;

namespace WebApIFaod2025.Services
{
    public interface ILivreurService
    {
        IEnumerable<Livreur> GetAll();
        Livreur GetById(int id);
        void Create(CreateLivreurRequest model);
        void Update(int id, UpdateLivreurRequest model);
        void Delete(int id);
    }

    public class LivreurService : ILivreurService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;

        public LivreurService(bdTracking01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Livreur> GetAll()
        {
            return _context.Livreurs;
        }

        public Livreur GetById(int id)
        {
            return getLivreur(id);
        }

        public void Create(CreateLivreurRequest model)
        {
            if (_context.Livreurs.Any(x => x.Email == model.Email))
                throw new AppException("Livreur avec cet email '" + model.Email + "' existe déjà");

            var livreur = _mapper.Map<Livreur>(model);
            _context.Livreurs.Add(livreur);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateLivreurRequest model)
        {
            var livreur = getLivreur(id);

            if (model.Email != livreur.Email && _context.Livreurs.Any(x => x.Email == model.Email))
                throw new AppException("Livreur avec cet email '" + model.Email + "' existe déjà");

            _mapper.Map(model, livreur);
            _context.Livreurs.Update(livreur);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var livreur = getLivreur(id);
            _context.Livreurs.Remove(livreur);
            _context.SaveChanges();
        }

        private Livreur getLivreur(int id)
        {
            var livreur = _context.Livreurs.Find(id);
            if (livreur == null) throw new KeyNotFoundException("Ce livreur n'existe pas");
            return livreur;
        }
    }
}