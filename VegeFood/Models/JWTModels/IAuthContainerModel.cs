using System.Security.Claims;

namespace VegeFood.Models.JWTModels
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; }
        Claim[] Claims { get; set; }
    }
}
