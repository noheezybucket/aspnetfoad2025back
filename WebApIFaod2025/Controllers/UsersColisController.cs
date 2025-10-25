using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.UsersColis;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersColisController : ControllerBase
    {
        private IUsersColisService _usersColisService;
        private IMapper _mapper;
        
    

    public UsersColisController(
             IUsersColisService usersColisService,
             IMapper mapper)
        {
            _usersColisService = usersColisService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _usersColisService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _usersColisService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _usersColisService.Create(model);
            return Ok(new { message = "User creer" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _usersColisService.Update(id, model);
            return Ok(new { message = "User Mis à jour" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersColisService.Delete(id);
            return Ok(new { message = "User supprimer" });
        }
    }

}


