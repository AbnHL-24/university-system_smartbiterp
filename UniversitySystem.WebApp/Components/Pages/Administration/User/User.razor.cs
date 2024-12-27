using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Services;

namespace UniversitySystem.WebApp.Components.Pages.Administration.User;

public partial class User : ComponentBase
{
    [Inject]
    private IUserService UserService { get; set; }

    private RadzenDataGrid<UserModel> usersGrid;
    private IEnumerable<UserModel> _users;

    private List<UserModel> ordersToInsert = [];
    private List<UserModel> ordersToUpdate = [];

    protected override async Task OnInitializedAsync() =>
        _users = await UserService.GetUsersAsync();

    void Reset()
    {
        ordersToInsert.Clear();
        ordersToUpdate.Clear();
    }

    void Reset(UserModel user)
    {
        ordersToInsert.Remove(user);
        ordersToUpdate.Remove(user);
    }

    async Task EditRow(UserModel user)
    {
        if (!usersGrid.IsValid) return;

        Reset();

        ordersToUpdate.Add(user);
        await usersGrid.EditRow(user);
    }

    private async Task OnUpdateRow(UserModel user)
    {
        Reset(user);
        await UserService.UpdateUserAsync(user);
    }

    async Task SaveRow(UserModel user)
    {
        await usersGrid.UpdateRow(user);
    }

    private async Task CancelEdit(UserModel user)
    {
        Reset(user);
        usersGrid.CancelEditRow(user);
        _users = await UserService.GetUsersAsync();
    }

    async Task InsertRow()
    {
        if (!usersGrid.IsValid) return;

        Reset();

        var user = new UserModel();
        ordersToInsert.Add(user);
        await usersGrid.InsertRow(user);
    }

    private async Task OnCreateRow(UserModel user)
    {
        await UserService.AddUserAsync(user);
        ordersToInsert.Remove(user);
    }
}