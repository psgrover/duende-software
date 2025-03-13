using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IdentityServer.EmailSecurity;

public class IdentityServerEmailAuth : IExtensionGrantValidator
{
    public string GrantType => "email_auth";

    public async Task ValidateAsync(ExtensionGrantValidationContext context)
    {
        var email = context.Request.Raw.Get("email");
        var apiKey = context.Request.Raw.Get("api_key");

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(apiKey))
        {
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid email authentication request.");
            return;
        }

        // Validate API key for email sending authorization (to prevent abuse)
        if (!EmailAuthService.ValidateApiKey(email, apiKey))
        {
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid API key.");
            return;
        }

        // Successful authentication
        context.Result = new GrantValidationResult(email, GrantType);
    }
}

public static class EmailAuthService
{
    private static readonly Dictionary<string, string> ValidApiKeys = new()
    {
        { "user@example.com", "VALID_API_KEY_123" }
    };

    public static bool ValidateApiKey(string email, string apiKey)
    {
        return ValidApiKeys.ContainsKey(email) && ValidApiKeys[email] == apiKey;
    }
}
