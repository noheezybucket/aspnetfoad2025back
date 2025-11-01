using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Models.Client;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        private IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Create(CreateClientRequest model)
        {
            _clientService.Create(model);
            return Ok(new { message = "Client créé" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateClientRequest model)
        {
            _clientService.Update(id, model);
            return Ok(new { message = "Client mis à jour" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return Ok(new { message = "Client supprimé" });
        }
    }
}