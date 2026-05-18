namespace GestionITM.Domain.Dtos
{
    public class MatriculaCreateDto
    {
        public int CursoId { get; set; }
        public string Periodo { get; set; } = string.Empty; // Ej: "2026-1"
    }
}
