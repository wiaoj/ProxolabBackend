using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProxolabBackend.Controllers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ProxolabBackend.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class XApiKeyAttribute : Attribute, IAuthorizationFilter {
    private const String WARRIOR_API_KEY_HEADER_NAME = "warrior-API-Key";
    public void OnAuthorization(AuthorizationFilterContext context) {
        var submittedKey = GetSubmittedApiKey(context.HttpContext);
        var warriorApiKey = WarriorsController._warriors.Any(x => x.APIKEY.Equals(submittedKey));

        if(warriorApiKey is false) {
            context.Result = new UnauthorizedResult();
        }
    }

    private static String GetSubmittedApiKey(HttpContext context) {
        return context.Request.Headers[WARRIOR_API_KEY_HEADER_NAME];
    }
}
