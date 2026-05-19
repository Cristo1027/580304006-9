using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> ObtenerTodosAsync();
        Task AgregarAsync(Profesor profesor);
        IQueryable<Profesor> ConsultarTodo();
    }
}