using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.SuiviCommande;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuiviCommandeController : ControllerBase
    {
        private ISuiviCommandeService _suiviService;
        private IMapper _mapper;

        public SuiviCommandeController(ISuiviCommandeService suiviService, IMapper mapper)
        {
            _suiviService = suiviService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var suivis = _suiviService.GetAll();
            return Ok(suivis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var suivi = _suiviService.GetById(id);
            return Ok(suivi);
        }

        [HttpPost]
        public IActionResult Create(CreateSuiviRequest model)
        {
            _suiviService.Create(model);
            return Ok(new { message = "Suivi créé" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateSuiviRequest model)
        {
            _suiviService.Update(id, model);
            return Ok(new { message = "Suivi mis à jour" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _suiviService.Delete(id);
            return Ok(new { message = "Suivi supprimé" });
        }
    }
}