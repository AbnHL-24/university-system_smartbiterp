using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using UniversitySystem.Domain.Models.Authentication;

namespace UniversitySystem.WebApp.Authentication;

public class CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage) : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _sessionStorage = sessionStorage;
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var sessionDataStorageResult = await _sessionStorage.GetAsync<SessionData>("SessionData");
            var sessionData = sessionDataStorageResult.Success ? sessionDataStorageResult.Value : null;

            if (sessionData is null) return await Task.FromResult(new AuthenticationState(_anonymous));

            var claims = new List<Claim>()
            {
                new("Id", sessionData.UserId!),
                new(ClaimTypes.Name, sessionData.Name!),
                new(ClaimTypes.Role, sessionData.Role!)
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }
    
    public async Task UpdateAuthenticationState(SessionData? sessionData)
    {
        ClaimsPrincipal claimsPrincipal;

        if (sessionData is not null)
        {
            await _sessionStorage.SetAsync("SessionData", sessionData);
            var claims = new List<Claim>()
            {
                new("Id", sessionData.UserId!),
                new(ClaimTypes.Name, sessionData.Name!),
                new(ClaimTypes.Role, sessionData.Role!)
            };

            claimsPrincipal = new(new ClaimsIdentity(claims));
        }
        else
        {
            await _sessionStorage.DeleteAsync("SessionData");
            claimsPrincipal = _anonymous;
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}