using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApIFaod2025.Models.UsersColis;
using WebApIFaod2025.Services;
using WebApIFaod2025.Helpers;
using Microsoft.EntityFrameworkCore;

namespace WebApIFaod2025.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersColisController : ControllerBase
    {
        private readonly IUsersColisService _service;
        private readonly bdTracking01Context _context;
        public UsersColisController(IUsersColisService service, bdTracking01Context context)
        {
            _service = service;
            _context = context;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.UsersColis
                .Where(u => u.IdUsersColis == id )
                .Select(u => new
                {
                    id = u.IdUsersColis,
                    nom = u.Nom,
                    prenom = u.Prenom,
                    cni = u.CNI,
                    telephone = u.Telephone,
                    email = u.Email,
                    adresse = u.Adresse,
                    role = u.Role,
                    statut = u.Statut
                })
                .FirstOrDefault();

            if (user == null)
                return NotFound(new { error = "Utilisateur non trouvé ou inactif" });

            return Ok(user);
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
            try
            {
                _service.Deactivate(id);
                return Ok(new { message = "Utilisateur désactivé (Inactif)" });
            }
            catch (AppException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

}