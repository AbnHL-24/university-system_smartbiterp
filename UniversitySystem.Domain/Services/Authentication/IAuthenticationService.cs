using UniversitySystem.Domain.Models.Authentication;

namespace UniversitySystem.Domain.Services.Authentication;

public interface IAuthenticationService
{
    Task<SessionData> AuthenticateAsync(CredentialsModel credentials);
}