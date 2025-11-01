//using Microsoft.AspNetCore.Mvc;
//using WebApIFaod2025.Services;

//namespace WebApIFaod2025.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ListeColisController : ControllerBase
//    {
//        private readonly ListeColisService _service;

//        public ListeColisController(ListeColisService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public IActionResult GetListe(int livreurId)
//        {
//            var result = _service.GetListePourLivreur(livreurId);
//            return Ok(result);
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListeColisController : ControllerBase
    {
        private readonly IListeColisService _service;

        public ListeColisController(IListeColisService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetListe(int livreurId)
        {
            var result = _service.GetListePourLivreur(livreurId);
            return Ok(result);
        }
    }
}
