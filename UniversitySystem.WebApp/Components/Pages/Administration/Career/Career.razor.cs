using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Services.Career;

namespace UniversitySystem.WebApp.Components.Pages.Administration.Career;

public partial class Career : ComponentBase
{   
    [Inject]
    private DialogService DialogService { get; set; }
    
    [Inject]
    private ICareerService CareerService { get; set; }

    RadzenDataGrid<CareerModel> careersGrid;
    private IEnumerable<CareerModel> _careers;
    
    private List<CareerModel> ordersToInsert = [];
    private List<CareerModel> ordersToUpdate = [];
    
    
    protected override async Task OnInitializedAsync() =>
        _careers = await CareerService.GetCareersAsync();
    
    void Reset()
    {
        ordersToInsert.Clear();
        ordersToUpdate.Clear();
    }

    void Reset(CareerModel career)
    {
        ordersToInsert.Remove(career);
        ordersToUpdate.Remove(career);
    }
    
    async Task EditRow(CareerModel career)
    {
        if (!careersGrid.IsValid) return;

        Reset();

        ordersToUpdate.Add(career);
        await careersGrid.EditRow(career);
    }

    private async Task OnUpdateRow(CareerModel career)
    {
        Reset(career);
        await CareerService.UpdateCareerAsync(career);
    }

    async Task SaveRow(CareerModel career)
    {
        await careersGrid.UpdateRow(career);
    }

    private async Task CancelEdit(CareerModel career)
    {
        Reset(career);
        careersGrid.CancelEditRow(career);
        _careers = await CareerService.GetCareersAsync();
    }

    async Task InsertRow()
    {
        if (!careersGrid.IsValid) return;

        Reset();

        var career = new CareerModel();
        ordersToInsert.Add(career);
        await careersGrid.InsertRow(career);
    }

    private async Task OnCreateRow(CareerModel career)
    {
        await CareerService.AddCareerAsync(career);
        ordersToInsert.Remove(career);
    }
    
    private async Task ShowCourses(CareerModel career)
    {
        var result = await DialogService.OpenAsync<CareerCoursesDialog>($"{career.CareerName}",
            new Dictionary<string, object>() { { "CareerCode", career.CareerCode } },
            new DialogOptions() 
            {
                Resizable = true, 
                Draggable = true,
                Width = "900px", 
                Height = "600px"
            });
    }
}