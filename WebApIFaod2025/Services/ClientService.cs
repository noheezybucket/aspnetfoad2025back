using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Client;

namespace WebApIFaod2025.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        void Create(CreateClientRequest model);
        void Update(int id, UpdateClientRequest model);
        void Delete(int id);
    }

    public class ClientService : IClientService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;

        public ClientService(bdTracking01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients;
        }

        public Client GetById(int id)
        {
            return getClient(id);
        }

        public void Create(CreateClientRequest model)
        {
            if (_context.Clients.Any(x => x.Email == model.Email))
                throw new AppException("Client avec cet email '" + model.Email + "' existe déjà");

            var client = _mapper.Map<Client>(model);
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateClientRequest model)
        {
            var client = getClient(id);

            if (model.Email != client.Email && _context.Clients.Any(x => x.Email == model.Email))
                throw new AppException("Client avec cet email '" + model.Email + "' existe déjà");

            _mapper.Map(model, client);
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = getClient(id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        private Client getClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) throw new KeyNotFoundException("Ce client n'existe pas");
            return client;
        }
    }
}