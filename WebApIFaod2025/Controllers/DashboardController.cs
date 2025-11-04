using Microsoft.AspNetCore.Mvc;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stats = _dashboardService.GetStats();
            return Ok(stats);
        }
    }
}