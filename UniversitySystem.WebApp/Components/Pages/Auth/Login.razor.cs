using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using UniversitySystem.Domain.Models.Authentication;
using UniversitySystem.Domain.Services.Authentication;
using UniversitySystem.WebApp.Authentication;

namespace UniversitySystem.WebApp.Components.Pages.Auth;

public partial class Login : ComponentBase
{
    [Inject]
    private DialogService DialogService { get; set; } = default!;
    
    [Inject]
    private NavigationManager Navigation { get; set; } = default!;
    
    [Inject]
    private IAuthenticationService AuthService { get; set; } = default!;
    
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    private readonly CredentialsModel _credentials = new();

    private bool _busy;
    
    private async Task LogIn()
    {
        try
        {
            _busy = true;

            var sessionData = await AuthService.AuthenticateAsync(_credentials);
            
            var authStateProvider = (CustomAuthenticationStateProvider)AuthenticationStateProvider;
            await authStateProvider.UpdateAuthenticationState(sessionData);

            Navigation.NavigateTo($"{Navigation.BaseUri}index", true);
        }
        catch (Exception ex)
        {
            await DialogService.Alert(ex.Message, "No se pudo iniciar sesión", new AlertOptions() { Style = "color: white;" });
        }
        finally
        {
            _busy = false;
        }
    }
}