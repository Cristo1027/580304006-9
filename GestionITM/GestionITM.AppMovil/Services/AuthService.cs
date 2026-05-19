using GestionITM.AppMovil.Models;
using System.Net.Http.Json;

namespace GestionITM.AppMovil.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var request = new LoginRequest
            {
                Email = email,
                Password = password,
                Rol = "Estudiante"
            };

            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Credenciales inválidas.");

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result?.Token ?? throw new Exception("Token no recibido.");
        }
    }
}