using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using GestionITM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Curso?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.Id == id);  // ← Id (no id_curso)
        }

        public IQueryable<Curso> ObtenerQueryable()
        {
            return _context.Cursos.AsQueryable();  // 🎯 IQueryable para SQL optimizado
        }
    }
}