using System.Collections.Generic;
using IdentityServer4.Models;

namespace Identity
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource
            {
                Name = "api",
                Description = "Resource owner password credentials",
                Scopes = {new Scope("ropc")},
                ApiSecrets = {new Secret("secret".Sha256())}
            }
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "api",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedScopes = {"ropc"},
                AccessTokenType = AccessTokenType.Jwt
            }
        };

        public static IEnumerable<IdentityResource> Ids => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    }
}