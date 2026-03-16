using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Profesor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime FechaContratacion { get; set; }
    }
}