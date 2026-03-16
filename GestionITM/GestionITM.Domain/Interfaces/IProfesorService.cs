using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> ObtenerTodosAsync();
        Task<ProfesorDto> CrearProfesorAsync(ProfesorCreateDto dto);
    }
}