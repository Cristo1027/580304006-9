namespace GestionITM.AppMovil.Handlers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Recuperar el token guardado en SecureStorage
            var token = await SecureStorage.GetAsync("jwt_token");

            if (!string.IsNullOrEmpty(token))
            {
                // Inyectar el header Authorization en TODAS las peticiones
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer", token);
            }

            // Continuar con la cadena de handlers
            return await base.SendAsync(request, cancellationToken);
        }
    }
}