using Microsoft.AspNetCore.Mvc;

namespace Loggy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            _logger.LogInformation("HTTP GET: Inicio da requisicao");
            int teste = int.Parse("f");

            return Ok("deu certo");
        }
    }
}
