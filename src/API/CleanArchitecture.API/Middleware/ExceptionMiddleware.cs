using CleanArchitecture.API.Errors;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env; //ambiente

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); //Que el request siga al siguiente nivel hasta procesarse ne la aplciación
            }
            catch (Exception ex) //Si hay excepciones de negocio o de validaciones
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new CodeErrorException((int) HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new CodeErrorException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; //Formato para escribir el json
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json); //Envia el mensaje al cliente
            }

        }
    }
}
