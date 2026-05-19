using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        // El DbContext se inyecta AQUÍ, nunca en el controlador
        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteMatriculaAsync(int estudianteId, int cursoId)
        {
            return await _context.Matriculas
                .AnyAsync(m => m.EstudianteId == estudianteId
                            && m.CursoId == cursoId);
        }

        public async Task<Matricula?> ObtenerPorIdAsync(int id)
        {
            return await _context.Matriculas
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}