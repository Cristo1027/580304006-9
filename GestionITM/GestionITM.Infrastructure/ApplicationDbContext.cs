using GestionITM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure
{
    // DbContext puente entre las entidades de dominio y la base de datos
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Cada DbSet representa una tabla en la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<Profesor> Profesores { get; set; }
    }
}
