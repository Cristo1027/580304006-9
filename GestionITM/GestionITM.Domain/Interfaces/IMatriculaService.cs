using System.Threading.Tasks;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        // Procesa la regla de negocio del "Chef" (Cupos) y restringe por rol
        Task<MatriculaDto> CrearMatriculaAsync(MatriculaCreateDto dto, int estudianteId);

        // Resuelve el requerimiento de paginación eficiente usando PagedResult<T>
        Task<PagedResult<Curso>> ObtenerCursosPaginadosAsync(int pageNumber, int pageSize);
    }
}
