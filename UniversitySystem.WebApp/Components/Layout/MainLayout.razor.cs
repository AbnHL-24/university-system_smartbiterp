using Microsoft.AspNetCore.Components;
using Radzen;

namespace UniversitySystem.WebApp.Components.Layout
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        [Inject] private DialogService DialogService { get; set; } = default!;
        // [Inject] private ParameterService ParameterService { get; set; } = default!;
    
        private bool _collapseNavMenu = true;

        private string _version = string.Empty;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (!firstRender) return;

                _version = $"Versión {GetType().Assembly.GetName().Version} | Copyright Ⓒ 2024";

                StateHasChanged();
            }
            catch (Exception ex)
            {
                await DialogService.Alert(ex.Message, "Error");
            }
        }
    }
}