using System.Security.Claims;
using System.Collections.Generic;
using VegeFood.Models.JWTModels;

namespace VegeFood.Services.JWTServices
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
