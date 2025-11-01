using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.Livreur;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreurController : ControllerBase
    {
        private LivreurService _livreurService;
        private IMapper _mapper;

        public LivreurController(LivreurService livreurService, IMapper mapper)
        {
            _livreurService = livreurService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var livreurs = _livreurService.GetAll();
            return Ok(livreurs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livreur = _livreurService.GetById(id);
            return Ok(livreur);
        }

        [HttpPost]
        public IActionResult Create(CreateLivreurRequest model)
        {
            _livreurService.Create(model);
            return Ok(new { message = "Livreur créé" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateLivreurRequest model)
        {
            _livreurService.Update(id, model);
            return Ok(new { message = "Livreur mis à jour" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livreurService.Delete(id);
            return Ok(new { message = "Livreur supprimé" });
        }
    }
}