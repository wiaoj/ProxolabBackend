using ProxolabBackend.Controllers;
using ProxolabBackend.Domain.Warriors;

namespace ProxolabBackend.Middlewares;

public class ApiKeyMiddleware {
    private readonly RequestDelegate _next;
    private const String UserKey = "warrior-api-key";
    public ApiKeyMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        if(context.Request.Headers.TryGetValue(UserKey, out var extractedApiKey) is false) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key not found");
            return;
        }

        var x = WarriorsController._warriors.FirstOrDefault(x => x.APIKEY.Equals(extractedApiKey)).APIKEY;
        if(x.Equals(extractedApiKey) is false) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unouthorized client");
            return;
        }

        await _next.Invoke(context);
    }
}
