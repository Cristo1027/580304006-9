using System.Linq;
using System.Threading.Tasks;
using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso?> ObtenerPorIdAsync(int id);
        IQueryable<Curso> ObtenerQueryable();  // 🎯 Paginación EFICIENTE
    }
}