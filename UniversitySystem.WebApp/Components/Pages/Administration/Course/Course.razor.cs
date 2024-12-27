using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Services;

namespace UniversitySystem.WebApp.Components.Pages.Administration.Course;

public partial class Course : ComponentBase
{
    [Inject]
    private ICourseService CourseService { get; set; }

    RadzenDataGrid<CourseModel> coursesGrid;
    private IEnumerable<CourseModel> _courses;

    private List<CourseModel> ordersToInsert = new();
    private List<CourseModel> ordersToUpdate = new();

    protected override async Task OnInitializedAsync()
    {
        _courses = await CourseService.GetCoursesAsync();
    }

    void Reset()
    {
        ordersToInsert.Clear();
        ordersToUpdate.Clear();
    }

    void Reset(CourseModel course)
    {
        ordersToInsert.Remove(course);
        ordersToUpdate.Remove(course);
    }

    async Task EditRow(CourseModel course)
    {
        if (!coursesGrid.IsValid) return;

        Reset();

        ordersToUpdate.Add(course);
        await coursesGrid.EditRow(course);
    }

    private async Task OnUpdateRow(CourseModel course)
    {
        Reset(course);
        await CourseService.UpdateCourseAsync(course);
    }

    async Task SaveRow(CourseModel course)
    {
        await coursesGrid.UpdateRow(course);
    }

    private async Task CancelEdit(CourseModel course)
    {
        Reset(course);
        coursesGrid.CancelEditRow(course);
        _courses = await CourseService.GetCoursesAsync();
    }

    async Task InsertRow()
    {
        if (!coursesGrid.IsValid) return;

        Reset();

        var course = new CourseModel();
        ordersToInsert.Add(course);
        await coursesGrid.InsertRow(course);
    }

    private async Task OnCreateRow(CourseModel course)
    {
        await CourseService.AddCourseAsync(course);
        ordersToInsert.Remove(course);
    }
}