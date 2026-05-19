using GestionITM.AppMovil.Models;
using System.Net.Http.Json;

namespace GestionITM.AppMovil.Services
{
    public class MatriculaService
    {
        private readonly HttpClient _httpClient;

        public MatriculaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task MatricularseAsync(int cursoId)
        {
            var body = new { CursoId = cursoId, Periodo = "2026-1" };

            var response = await _httpClient.PostAsJsonAsync("api/Matricula", body);

            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert(
                    "¡Éxito!",
                    "Te has matriculado correctamente.",
                    "OK");
                return;
            }

            // HTTP 400 — leer el JSON de error del backend
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var error = await response.Content
                    .ReadFromJsonAsync<ErrorResponse>();

                // DisplayAlert amable — sin crash, sin cierre de app
                await Shell.Current.DisplayAlert(
                    "Matrícula no disponible",
                    error?.Message ?? "No fue posible completar la matrícula.",
                    "Entendido");
                return;
            }

            // Otros errores (401, 500, etc.)
            await Shell.Current.DisplayAlert(
                "Error",
                "Ocurrió un error inesperado. Intenta más tarde.",
                "OK");
        }
    }
}