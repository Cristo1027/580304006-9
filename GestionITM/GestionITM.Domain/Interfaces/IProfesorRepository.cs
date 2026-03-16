using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllAsync();
        Task AddAsync(Profesor profesor);
        Task<bool> EmailExistsAsync(string email);
    }
}