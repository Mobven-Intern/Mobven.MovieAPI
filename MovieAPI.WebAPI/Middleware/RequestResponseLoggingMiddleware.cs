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
        var userId = JwtHelper.GetUserIdFromToken(context);

        await LogRequestBody(context, userId);

        var originalResponseBody = context.Response.Body;
        var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            await LogResponseBody(memoryStream);

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

            var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();

            Log.Information($"Response Body: {responseBody}");
        }
    }
}
