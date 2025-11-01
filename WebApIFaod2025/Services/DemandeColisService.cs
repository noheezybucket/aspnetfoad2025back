using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.DemandeColis;

namespace WebApIFaod2025.Services
{
    public interface IDemandeColisService
    {
        IEnumerable<DemandeColis> GetAll();
        DemandeColis GetById(int id);
        void Create(CreateDemandeRequest model);
        void Update(int id, UpdateDemandeRequest model);
        void Delete(int id);
    }

    public class DemandeColisService : IDemandeColisService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;

        public DemandeColisService(bdTracking01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DemandeColis> GetAll()
        {
            return _context.DemandeColis;
        }

        public DemandeColis GetById(int id)
        {
            return getDemande(id);
        }

        public void Create(CreateDemandeRequest model)
        {
            var demande = _mapper.Map<DemandeColis>(model);
            _context.DemandeColis.Add(demande);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateDemandeRequest model)
        {
            var demande = getDemande(id);
            _mapper.Map(model, demande);
            _context.DemandeColis.Update(demande);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var demande = getDemande(id);
            _context.DemandeColis.Remove(demande);
            _context.SaveChanges();
        }

        private DemandeColis getDemande(int id)
        {
            var demande = _context.DemandeColis.Find(id);
            if (demande == null) throw new KeyNotFoundException("Cette demande n'existe pas");
            return demande;
        }
    }
}