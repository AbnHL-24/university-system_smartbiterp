using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using UniversitySystem.Domain.Models.Course;
using UniversitySystem.Domain.Services;

namespace UniversitySystem.WebApp.Components.Pages.Student;

public partial class AssignedCourses : ComponentBase
{
    [Inject]
    IJSRuntime JS { get; set; }
    [Inject]
    private ICourseService CourseService { get; set; }
    
    [CascadingParameter]
    private Task<AuthenticationState> authenticationState { get; set; }
    
    private IEnumerable<AssignedCourse> _assignedCourses;
    private int _studentCode;
    private string _sutdentName;
    
    protected override async Task OnInitializedAsync()
    {
        await GetStudentCode();
        _assignedCourses = await CourseService.GetCoursesByStudentAsync(_studentCode);
    }

    private async Task GetStudentCode()
    {
        var authState = await authenticationState;
        _studentCode = int.Parse(authState.User.Claims.FirstOrDefault(c => c.Type == "Id")!.Value);
        _sutdentName = authState.User.Identity!.Name;
    }

    private async Task ExportReport()
    {
        using MemoryStream fileStream = await CourseService.GeneratePDF(_assignedCourses, _studentCode, _sutdentName);
        var pdfBase64 = Convert.ToBase64String(fileStream.ToArray());
        await JS.InvokeVoidAsync("abrirPDF", pdfBase64);
    }
}