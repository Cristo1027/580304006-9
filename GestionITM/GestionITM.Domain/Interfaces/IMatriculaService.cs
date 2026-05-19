using System.Threading.Tasks;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaDto> CrearMatriculaAsync(MatriculaCreateDto dto, int estudianteId);
        Task<PagedResult<Curso>> ObtenerCursosPaginadosAsync(int pageNumber, int pageSize);
    }
}
