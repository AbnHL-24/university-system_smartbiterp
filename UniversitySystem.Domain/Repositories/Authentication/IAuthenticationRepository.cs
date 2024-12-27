using UniversitySystem.Domain.Models.Authentication;

namespace UniversitySystem.Domain.Repositories.Authentication;

public interface IAuthenticationRepository
{
    Task<SessionData?> AuthenticateAsync(string username, string password);
}