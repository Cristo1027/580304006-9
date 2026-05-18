using GestionITM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Domain.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso?> ObtenerPorIdAsync(int id);
        IQueryable<Curso> ObtenerQueryable();  // 🎯 Paginación EFICIENTE
    }
}