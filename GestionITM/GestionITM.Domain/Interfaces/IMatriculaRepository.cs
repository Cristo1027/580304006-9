using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        // Persiste una nueva matrícula en la base de datos
        Task AgregarAsync(Matricula matricula);

        // Verifica si un estudiante ya está inscrito en un curso
        // Evita matrículas duplicadas
        Task<bool> ExisteMatriculaAsync(int estudianteId, int cursoId);

        // Recupera una matrícula con sus datos de navegación
        // (incluye el Estudiante y el Curso relacionados)
        Task<Matricula?> ObtenerPorIdAsync(int id);
    }
}