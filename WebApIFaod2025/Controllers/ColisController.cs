using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.Colis;
using WebApIFaod2025.Services;

[Route("api/[controller]")]
[ApiController]
public class ColisController : ControllerBase
{
    private readonly IColisService _service;

    public ColisController(IColisService service) => _service = service;

    [HttpPost]
    public IActionResult Create([FromBody] CreateColisRequest model)
    {
        var colis = _service.CreateColis(model);
        return Ok(new { message = "Colis créé", id = colis.IdColis, code = colis.CodeColis });
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());
}