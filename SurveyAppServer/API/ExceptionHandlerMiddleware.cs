using BLL.Exceptions;

using System.Net;
using System.Text.Json;

namespace SurveyAppServer;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException e)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = e.StatusCode;
                
            await response.WriteAsync(SerializeToJson(e.Message));
        }
        catch (Exception e)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
            await response.WriteAsync(SerializeToJson(e.Message + " " + e.InnerException?.Message));
        }
    }
    
    private static string SerializeToJson(string message)
    {
        return JsonSerializer.Serialize(new { message });
    }
}