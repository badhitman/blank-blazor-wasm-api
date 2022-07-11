////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using ServerLib;

namespace ApiRestApp
{
    public class PassageMiddleware
    {
        private readonly RequestDelegate _next;

        public PassageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext _http_context, ISessionService _session, ILogger<PassageMiddleware> _logger)
        {
            //CultureInfo.CurrentCulture = GlobalUtils.RU;
            //CultureInfo.CurrentUICulture = GlobalUtils.RU;
            try
            {
                await _session.InitSession();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(PassageMiddleware)}");
            }

            await _next.Invoke(_http_context);
        }
    }
}
