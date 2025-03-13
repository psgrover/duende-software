using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Configuration;

public static class IdentityServerConfig
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[] { new IdentityResources.OpenId(), new IdentityResources.Profile() };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[] { new ApiScope("email.send", "Permission to send emails") };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "emailService",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("SuperSecretKey".Sha256()) },
                AllowedScopes = { "email.send" }
            }
        };
}
