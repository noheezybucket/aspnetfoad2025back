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
        void Delete(int id);

    }

    public class UsersColisService : IUsersColisService
    {
        private bdTracking01Context _context;
        private readonly IMapper _mapper;
        public UsersColisService(
        bdTracking01Context context,
        IMapper mapper)
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
            // validate
            if (_context.UsersColis.Any(x => x.Email == model.Email))
                throw new AppException("User avec cet email '" + model.Email + "'  existe déja");
                // map model to new user object
                var user = _mapper.Map<UsersColis>(model);
            // hash password
          //  user.PasswordHash = BCrypt.HashPassword(model.Password);
            // save user
            _context.UsersColis.Add(user);
            _context.SaveChanges();
        }
        public void Update(int id, UpdateRequest model)
        {
            var user = getUserColis(id);
            // validate
            if (model.Email != user.Email && _context.UsersColis.Any(x => x.Email ==
           model.Email))
                throw new AppException("User Avec cet email '" + model.Email + "' existe deja");
 //       // hash password if it was entered
 //if (!string.IsNullOrEmpty(model.Password))
 //               user.PasswordHash = BCrypt.HashPassword(model.Password);
            // copy model to user and save
            _mapper.Map(model, user);
            _context.UsersColis.Update(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = getUserColis(id);
            _context.UsersColis.Remove(user);
            _context.SaveChanges();
        }
        // helper methods
        private UsersColis getUserColis(int id)
        {
            var user = _context.UsersColis.Find(id);
            if (user == null) throw new KeyNotFoundException("Ce user N'existe pas");
            return user;
        }
    }
}


