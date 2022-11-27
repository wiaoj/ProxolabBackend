using ProxolabBackend.Controllers;
using ProxolabBackend.Domain.Warriors;

namespace ProxolabBackend.Middlewares;

public class ApiKeyMiddleware {
    private readonly RequestDelegate _next;
    private const String KeyName = "x-api-key";
    public ApiKeyMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        if(context.Request.Headers.TryGetValue(KeyName, out var extractedApiKey) is false) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key not found");
            return;
        }
        var configuration = context.RequestServices.GetService<IConfiguration>();

        var defaultApiKey = configuration.GetValue<String>("ApiKey");

        //var x = WarriorsController._warriors.FirstOrDefault(x => x.APIKEY.Equals(extractedApiKey)).APIKEY;
        if(defaultApiKey.Equals(extractedApiKey) is false) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unouthorized client");
            return;
        }

        await _next.Invoke(context);
    }
}
