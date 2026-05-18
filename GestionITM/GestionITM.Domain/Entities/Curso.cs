using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        // Créditos académicos del curso
        [Range(0, 30)]
        public int Creditos { get; set; }

        public int CuposDisponibles { get; set; }

    }
}
