namespace GestionITM.Domain.Dtos
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
