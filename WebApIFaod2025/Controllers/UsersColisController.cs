////using AutoMapper;
////using Microsoft.AspNetCore.Http;
////using Microsoft.AspNetCore.Mvc;
////using WebApIFaod2025.Models.UsersColis;
////using WebApIFaod2025.Services;

////namespace WebApIFaod2025.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class UsersColisController : ControllerBase
////    {
////        private IUsersColisService _usersColisService;
////        private IMapper _mapper;



////    public UsersColisController(
////             IUsersColisService usersColisService,
////             IMapper mapper)
////        {
////            _usersColisService = usersColisService;
////            _mapper = mapper;
////        }

////        [HttpGet]
////        public IActionResult GetAll()
////        {
////            var users = _usersColisService.GetAll();
////            return Ok(users);
////        }
////        [HttpGet("{id}")]
////        public IActionResult GetById(int id)
////        {
////            var user = _usersColisService.GetById(id);
////            return Ok(user);
////        }
////        [HttpPost]
////        public IActionResult Create(CreateRequest model)
////        {
////            _usersColisService.Create(model);
////            return Ok(new { message = "User creer" });
////        }
////        [HttpPut("{id}")]
////        public IActionResult Update(int id, UpdateRequest model)
////        {
////            _usersColisService.Update(id, model);
////            return Ok(new { message = "User Mis à jour" });
////        }
////        [HttpDelete("{id}")]
////        public IActionResult Delete(int id)
////        {
////            _usersColisService.Delete(id);
////            return Ok(new { message = "User supprimer" });
////        }
////    }

////}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using WebApIFaod2025.Models.UsersColis;
//using WebApIFaod2025.Services;
//using WebApIFaod2025.Entities;

//namespace WebApIFaod2025.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersColisController : ControllerBase
//    {
//        private readonly IUsersColisService _service;

//        public UsersColisController(IUsersColisService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            return Ok(_service.GetAll());
//        }

//        [HttpPost("client")]
//        public IActionResult CreateClient([FromBody] CreateRequest model)
//        {
//            if (model.Statut != "Client") return BadRequest("Statut doit être 'Client'");
//            _service.Create(model);
//            return Ok(new { message = "Client créé" });
//        }

//        [HttpPost("livreur")]
//        public IActionResult CreateLivreur([FromBody] CreateRequest model)
//        {
//            if (model.Statut != "Livreur") return BadRequest("Statut doit être 'Livreur'");
//            _service.Create(model);
//            return Ok(new { message = "Livreur créé" });
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] UpdateRequest model)
//        {
//            _service.Update(id, model);
//            return Ok(new { message = "Mis à jour" });
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            _service.Delete(id);
//            return Ok(new { message = "Supprimé" });
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApIFaod2025.Models.UsersColis;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersColisController : ControllerBase
    {
        private readonly IUsersColisService _service;

        public UsersColisController(IUsersColisService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("client")]
        public IActionResult CreateClient([FromBody] CreateRequest model)
        {
            model.Role = "Client";
            model.Statut = "Actif";
            _service.Create(model);
            return Ok(new { message = "Client créé" });
        }

        [HttpPost("livreur")]
        public IActionResult CreateLivreur([FromBody] CreateRequest model)
        {
            model.Role = "Livreur";
            model.Statut = "Actif";
            _service.Create(model);
            return Ok(new { message = "Livreur créé" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateRequest model)
        {
            _service.Update(id, model);
            return Ok(new { message = "Mis à jour" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { message = "Supprimé" });
        }
    }
}