using System.Security.Authentication;
using UniversitySystem.Domain.Models.Authentication;
using UniversitySystem.Domain.Repositories.Authentication;
using UniversitySystem.Domain.Services.Authentication;

namespace UniversitySystem.Application.Services.Authentication;

public class AuthenticationService(IAuthenticationRepository authenticationRepository) : IAuthenticationService
{
    public async Task<SessionData> AuthenticateAsync(CredentialsModel credentials)
    {
        return await authenticationRepository.AuthenticateAsync(credentials.Username!, credentials.Password!)
            ?? throw new AuthenticationException("Credenciales incorrectas");
    }
}