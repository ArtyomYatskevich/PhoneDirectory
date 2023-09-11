using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PhoneDirectory.Backend.Infrastructure.Exceptions;

namespace PhoneDirectory.Backend.Middleware;

public class ApiErrorHandler
{
    private readonly RequestDelegate _next;

    public ApiErrorHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context,
        IHostEnvironment environment,
        ILoggerFactory loggerFactory)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            loggerFactory
                .CreateLogger("PhoneDirectory")
                .LogError(exception.ToString());
 
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                NotFoundException _ => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            object value = new { Error = new { message = exception.Message } };
            
            await context.Response.WriteAsync(JsonConvert.SerializeObject(value, serializerSettings));
        }
    }
}