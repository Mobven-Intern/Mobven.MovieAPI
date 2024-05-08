using MovieAPI.WebAPI.Helper;
using Serilog;

namespace MovieAPI.WebAPI.Middlewares;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // JWT'den kullanıcı kimlik bilgisini al
        var userId = JwtHelper.GetUserIdFromToken(context);

        // Request body'sini logla
        await LogRequestBody(context, userId);

        // Response body'sini okuyabilmek için response stream'i bellekte önbelleğe al
        var originalResponseBody = context.Response.Body;
        var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            await _next(context);

            // Response body'sini logla
            memoryStream.Seek(0, SeekOrigin.Begin);
            await LogResponseBody(memoryStream);

            // Bellek akışını kapatmak yerine pozisyonunu sıfırlayın
            memoryStream.Position = 0;
            await memoryStream.CopyToAsync(originalResponseBody);

        }
        finally
        {
            context.Response.Body = originalResponseBody;
        }
    }

    private async Task LogRequestBody(HttpContext context, string userId)
    {
        if (context.Request.ContentLength.HasValue && context.Request.ContentLength >= 0)
        {
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            Log.Information($"User ID: {userId} - Request Body: {requestBody}");
        }
    }

    private async Task LogResponseBody(Stream responseBodyStream)
    {
        if (responseBodyStream.CanRead && responseBodyStream.Length > 0)
        {
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(responseBodyStream);
            var responseBody = await reader.ReadToEndAsync();

            Log.Information($"Response Body: {responseBody}");
        }
    }
}
