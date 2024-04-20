using backend.Logic.Common;

namespace backend.Controllers.Middlewares
{
    public class SessionMiddleware
    {
        private const string _sessionKey = "session";
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ISessionResolver sessionResolver)
        {
            try
            {
                var sessionId = context.Request.Cookies[_sessionKey];
                sessionResolver.SetSessionId(Guid.Parse(sessionId));
                await _next(context);
            }
            catch(Exception ex)
            {
                await context.Response.WriteAsync(ex.Message);
                context.Response.StatusCode = 400;
            }
        }
    }
}
