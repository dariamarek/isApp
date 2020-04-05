using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace Identity
{
    public class ResourceOwnerPasswordApiValidator : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName == "valid")
            {
                context.Result = new GrantValidationResult
                (
                    "user-id",
                    "custom",
                    new List<Claim>()
                );
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }

            await Task.CompletedTask;
        }
    }
}