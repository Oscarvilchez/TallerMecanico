using Microsoft.AspNetCore.Mvc;

namespace TallerMecanico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        // GET: api/Persona
        [HttpGet]
        public IActionResult Get()
        {
            // Lista simulada con sintaxis 100% válida para C#
            var resultadoSimulado = new[]
            {
                new { Id = 1, NombreCompleto = "Juan Pérez" },
                new { Id = 2, NombreCompleto = "María López" }
            };

            return Ok(resultadoSimulado);
        }
    }
}
