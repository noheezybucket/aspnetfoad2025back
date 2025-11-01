using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.SuiviCommande;

namespace WebApIFaod2025.Services
{
    public interface ISuiviCommandeService
    {
        IEnumerable<SuiviCommande> GetAll();
        SuiviCommande GetById(int id);
        void Create(CreateSuiviRequest model);
        void Update(int id, UpdateSuiviRequest model);
        void Delete(int id);
    }

    public class SuiviCommandeService : ISuiviCommandeService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;

        public SuiviCommandeService(bdTracking01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<SuiviCommande> GetAll()
        {
            return _context.SuiviCommande;
        }

        public SuiviCommande GetById(int id)
        {
            return getSuivi(id);
        }

        public void Create(CreateSuiviRequest model)
        {
            var suivi = _mapper.Map<SuiviCommande>(model);
            _context.SuiviCommande.Add(suivi);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateSuiviRequest model)
        {
            var suivi = getSuivi(id);
            _mapper.Map(model, suivi);
            _context.SuiviCommande.Update(suivi);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var suivi = getSuivi(id);
            _context.SuiviCommande.Remove(suivi);
            _context.SaveChanges();
        }

        private SuiviCommande getSuivi(int id)
        {
            var suivi = _context.SuiviCommande.Find(id);
            if (suivi == null) throw new KeyNotFoundException("Ce suivi n'existe pas");
            return suivi;
        }
    }
}