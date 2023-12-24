using Microsoft.AspNetCore.Identity;

namespace ASAP.Domain.Contracts
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(IdentityUser user);
    }
}
