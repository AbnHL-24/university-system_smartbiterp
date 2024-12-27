using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UniversitySystem.WebApp.Authentication;

namespace UniversitySystem.WebApp.Components.Pages.Auth;

public partial class Logout : ComponentBase
{
    [Inject] 
    private NavigationManager Navigation { get; set; } = default!;
    
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Task.Delay(1500);
        await CerrarSesion();
    }

    private async Task CerrarSesion()
    {
        var authStateProvider = (CustomAuthenticationStateProvider)AuthenticationStateProvider;
        await authStateProvider.UpdateAuthenticationState(null);
        Navigation.NavigateTo($"{Navigation.BaseUri}login", true);
    }
}