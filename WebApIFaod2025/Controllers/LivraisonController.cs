using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Models.Livraison;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivraisonController : ControllerBase
    {

        private readonly ILivraisonService _service;

        public LivraisonController(ILivraisonService service)
        {
            _service = service;
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreateLivraisonRequest model)
        //{
        //    var livraison = _service.CreateLivraison(model);
        //    return Ok(new
        //    {
        //        message = "Livraison créée",
        //        idLivraison = livraison.IdLivraison,
        //        codeColis = _context.Colis.Find(livraison.IdColis)?.CodeColis
        //    });
        //}

        [HttpPost]
        public IActionResult Create([FromBody] CreateLivraisonRequest model)
        {
            var livraison = _service.CreateLivraison(model);
            return Ok(new
            {
                message = "Livraison créée",
                idLivraison = livraison.IdLivraison,
                codeColis = livraison.Colis?.CodeColis
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPatch("{id}/terminer")]
        public IActionResult Terminer(int id)
        {
            var livraison = _service.TerminerLivraison(id);
            if (livraison == null) return NotFound();
            return Ok(new { message = "Livraison terminée", livraison });
        }
    }
}

//[Route("api/[controller]")]
//[ApiController]
//public class LivraisonController : ControllerBase
//{
//    private readonly ILivraisonService _service;

//    public LivraisonController(ILivraisonService service) => _service = service;

//    [HttpPost]
//    public IActionResult Create([FromBody] CreateLivraisonRequest model)
//    {
//        var livraison = _service.CreateLivraison(model);
//        return Ok(new { message = "Livraison créée", id = livraison.IdLivraison });
//    }

//    [HttpGet]
//    public IActionResult GetAll() => Ok(_service.GetAll());

//    [HttpPatch("{id}/terminer")]
//    public IActionResult Terminer(int id)
//    {
//        var livraison = _service.TerminerLivraison(id);
//        if (livraison == null) return NotFound();
//        return Ok(new { message = "Livraison terminée" });
//    }
//}