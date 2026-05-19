using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionITM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Genera un token JWT para pruebas
        /// </summary>
        /// <remarks>
        /// Para probar el endpoint de matrícula usa:
        /// 
        ///     POST /api/auth/login
        ///     {
        ///         "email": "estudiante@correo.itm.edu.co",
        ///         "password": "123456",
        ///         "rol": "Estudiante"
        ///     }
        /// </remarks>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // Para pruebas: cualquier credencial es válida
            // En producción aquí se valida contra la base de datos
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"), // EstudianteId = 1
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(ClaimTypes.Role, dto.Rol),       // "Estudiante" o "Admin"
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expira = DateTime.UtcNow.AddHours(8)
            });
        }
    }

    // DTO local solo para el login
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = "Estudiante";
    }
}