using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ObtenerTodoAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AgregarAsync(T entidad)
        {
            await _context.Set<T>().AddAsync(entidad);
            await _context.SaveChangesAsync();
        }
    }
}