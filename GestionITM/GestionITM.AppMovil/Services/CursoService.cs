using GestionITM.AppMovil.Models;
using System.Net.Http.Json;

namespace GestionITM.AppMovil.Services
{
    public class CursoService
    {
        private readonly HttpClient _httpClient;

        public CursoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<CursoModel>> GetPagedAsync(
            int pageNumber, int pageSize)
        {
            var url = $"api/curso/paginado?pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _httpClient.GetFromJsonAsync<PagedResult<CursoModel>>(url);
            return result ?? new PagedResult<CursoModel>();
        }
    }
}