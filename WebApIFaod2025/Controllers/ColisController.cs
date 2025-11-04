//using AutoMapper;
//using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApIFaod2025.Models.Colis;
//using WebApIFaod2025.Services;

//namespace WebApIFaod2025.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ColisController : ControllerBase
//    {
//        private ColisService _colisService;
//        private IMapper _mapper;

//        public ColisController(ColisService colisService, IMapper mapper)
//        {
//            _colisService = colisService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var colis = _colisService.GetAll();
//            return Ok(colis);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var colis = _colisService.GetById(id);
//            return Ok(colis);
//        }

//        [HttpPost]
//        [HttpPost]
//        public IActionResult Create(CreateColisRequest model)
//        {
//            _colisService.CreateColis(model);  // ← CreateColis
//            return Ok(new { message = "Colis créé" });
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update(int id, UpdateColisRequest model)
//        {
//            _colisService.Update(id, model);
//            return Ok(new { message = "Colis mis à jour" });
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            _colisService.Delete(id);
//            return Ok(new { message = "Colis supprimé" });
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Colis;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColisController : ControllerBase
    {
        private readonly IColisService _colisService;
        private readonly bdTracking01Context _context;

        public ColisController(IColisService colisService, bdTracking01Context context)
        {
            _colisService = colisService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var colis = _context.Colis
            .Include(c => c.Client)
            .Select(c => new
            {
                idColis = c.IdColis,
                codeColis = c.CodeColis,
                description = c.Description,
                poids = c.Poids,
                adresseDepart = c.AdresseDepart,
                adresseArrivee = c.AdresseArrivee,
                dateCreation = c.DateCreation,
                statutLivraison = c.StatutLivraison,
                idClient = c.IdClient,
                nomclient = c.Client.Nom,
                prenomclient = c.Client.Prenom
            })
            .ToList();

            return Ok(colis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var colis = _context.Colis
                .Include(c => c.Client)
                .Where(c => c.IdColis == id)
                .Select(c => new
                {
                    idColis = c.IdColis,
                    codeColis = c.CodeColis,
                    description = c.Description,
                    poids = c.Poids,
                    adresseDepart = c.AdresseDepart,
                    adresseArrivee = c.AdresseArrivee,
                    dateCreation = c.DateCreation,
                    statutLivraison = c.StatutLivraison,
                    idClient = c.IdClient,
                    nomclient = c.Client.Nom,
                    prenomclient = c.Client.Prenom
                })
                .FirstOrDefault();

            if (colis == null)
                return NotFound(new { error = "Colis non trouvé" });

            return Ok(colis);
        }

        [HttpPost]
        public IActionResult Create(CreateColisRequest model)
        {
            var colis = _colisService.CreateColis(model);
            return Ok(new { message = "Colis créé", id = colis.IdColis, code = colis.CodeColis });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateColisRequest model)
        {
            try
            {
                _colisService.Update(id, model);
                return Ok(new { message = "Colis mis à jour avec succès" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _colisService.Delete(id);
            return Ok(new { message = "Colis supprimé" });
        }
    }
}