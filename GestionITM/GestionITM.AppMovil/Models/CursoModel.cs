namespace GestionITM.AppMovil.Models
{
    public class CursoModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int CuposDisponibles { get; set; }
    }

    // Modelo para la respuesta paginada del backend
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalRegistros { get; set; }
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalPaginas { get; set; }
    }

    // Modelo para deserializar errores del backend
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    // Modelo para el login
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = "Estudiante";
    }

    // Modelo para la respuesta del login
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expira { get; set; }
    }
}