using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.DemandeColis;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandeColisController : ControllerBase
    {
        private DemandeColisService _demandeService;
        private IMapper _mapper;

        public DemandeColisController(DemandeColisService demandeService, IMapper mapper)
        {
            _demandeService = demandeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var demandes = _demandeService.GetAll();
            return Ok(demandes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var demande = _demandeService.GetById(id);
            return Ok(demande);
        }

        [HttpPost]
        public IActionResult Create(CreateDemandeRequest model)
        {
            _demandeService.Create(model);
            return Ok(new { message = "Demande créée" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateDemandeRequest model)
        {
            _demandeService.Update(id, model);
            return Ok(new { message = "Demande mise à jour" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _demandeService.Delete(id);
            return Ok(new { message = "Demande supprimée" });
        }
    }
}