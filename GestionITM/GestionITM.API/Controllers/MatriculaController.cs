using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionITM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Matricula a un estudiante en un curso
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        /// 
        /// POST /api/matricula
        /// {
        ///     "cursoId": 1,
        ///     "periodo": "2026-1"
        /// }
        /// </remarks>
        /// <response code="201">Matrícula creada exitosamente</response>
        /// <response code="400">Sin cupos disponibles o ya matriculado</response>
        /// <response code="401">No autorizado (falta token o token inválido)</response>
        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] MatriculaCreateDto dto)
        {
            var estudianteId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var resultado = await _service.CrearMatriculaAsync(dto, estudianteId);

            return CreatedAtAction(nameof(Post), resultado);
        }
    }
}