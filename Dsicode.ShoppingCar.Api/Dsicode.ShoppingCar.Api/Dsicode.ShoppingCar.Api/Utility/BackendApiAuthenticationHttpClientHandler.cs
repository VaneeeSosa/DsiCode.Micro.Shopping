using Microsoft.AspNetCore.Authentication;

namespace Dsicode.ShoppingCart.API.Utility
{
    public class BackendApiAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _accessor;

        public BackendApiAuthenticationHttpClientHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                // Solo intentar obtener token si hay un contexto HTTP válido
                if (_accessor.HttpContext != null)
                {
                    var token = await _accessor.HttpContext.GetTokenAsync("access_token");

                    if (!string.IsNullOrEmpty(token))
                    {
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
                }
            }
            catch
            {
                // Ignorar errores de autenticación para endpoints públicos
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}