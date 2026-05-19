using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        // Inyectamos el SERVICIO de matrícula que ya tiene
        // ObtenerCursosPaginadosAsync con IQueryable
        private readonly IMatriculaService _service;

        public CursoController(IMatriculaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista los cursos disponibles con paginación eficiente
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        /// 
        /// GET /api/curso/paginado?pageNumber=1&pageSize=10
        /// </remarks>
        /// <response code="200">Lista paginada de cursos</response>
        // GET: api/curso/paginado?pageNumber=1&pageSize=10
        [HttpGet("paginado")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginado(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var resultado = await _service
                .ObtenerCursosPaginadosAsync(pageNumber, pageSize);
            return Ok(resultado);
        }
    }
}