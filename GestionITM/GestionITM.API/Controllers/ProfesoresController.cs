using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesoresController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        // GET: api/Profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var profesores = await _profesorService.ObtenerTodosAsync();
            return Ok(profesores);
        }

        // POST: api/Profesores
        [HttpPost]
        public async Task<ActionResult<ProfesorDto>> Post([FromBody] ProfesorCreateDto dto)
        {
            // Aquí se ejecutan las reglas: Especialidad, Email único y el error de prueba
            var resultado = await _profesorService.CrearProfesorAsync(dto);
            return Ok(resultado);
        }
    }
}