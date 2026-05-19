using GestionITM.Domain.Dtos;
using GestionITM.Domain.Models;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> ObtenerTodosAsync();
        Task<bool> RegistrarProfesorAsync(ProfesorCreateDto profesorCreateDto);
        Task<PagedResult<ProfesorDto>> ObtenerPaginadosAsync(ProfesorFilterDto filtro);
    }
}