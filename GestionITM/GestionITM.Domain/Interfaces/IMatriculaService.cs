using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Models; 

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaDto> CrearMatriculaAsync(MatriculaCreateDto dto, int estudianteId);
        Task<PagedResult<Curso>> ObtenerCursosPaginadosAsync(int pageNumber, int pageSize);
    }
}