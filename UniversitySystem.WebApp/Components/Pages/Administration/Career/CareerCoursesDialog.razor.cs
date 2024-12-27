using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Services;
using UniversitySystem.Domain.Services.Career;

namespace UniversitySystem.WebApp.Components.Pages.Administration.Career;

public partial class CareerCoursesDialog : ComponentBase
{
    [Inject]
    private ICareerCourseService CareerCourseService { get; set; }
    
    [Inject]
    private ICourseService CourseService { get; set; }
    
    [Parameter]
    public int CareerCode { get; set; }
    
    private RadzenDataGrid<CareerCourseModel> careerCoursesGrid;
    private IEnumerable<CareerCourseModel> _careerCourses;
    private IEnumerable<CourseModel> _courses;
    
    private List<CareerCourseModel> careerCoursesToInsert = [];
    
    protected override async Task OnInitializedAsync() =>
        await LoadData();

    private async Task LoadData()
    {
        _careerCourses = await CareerCourseService.GetCareerCoursesAsync(CareerCode);
        
        var allCourses = await CourseService.GetCoursesAsync();
        _courses = allCourses.Where(c => _careerCourses.All(cc => cc.CourseCode != c.CourseCode));
    }
    
    void Reset()
    {
        careerCoursesToInsert.Clear();
    }
    
    private void Reset(CareerCourseModel careerCourse)
    {
        careerCoursesToInsert.Remove(careerCourse);
    }

    async Task SaveRow(CareerCourseModel careerCourse)
    {
        await careerCoursesGrid.UpdateRow(careerCourse);
    }

    private async Task CancelEdit(CareerCourseModel careerCourse)
    {
        Reset(careerCourse);
        careerCoursesGrid.CancelEditRow(careerCourse);
        await LoadData();
    }
    
    async Task DeleteRow(CareerCourseModel careerCourse)
    {
        Reset(careerCourse);

        if (_careerCourses.Contains(careerCourse))
        {
            await CareerCourseService.DeleteCareerCourseAsync(careerCourse.CareerCode, careerCourse.CourseCode);
            await LoadData();
        }
        else
            careerCoursesGrid.CancelEditRow(careerCourse);

        await careerCoursesGrid.Reload();
    }

    async Task InsertRow()
    {
        if (!careerCoursesGrid.IsValid) return;

        Reset();

        var careerCourse = new CareerCourseModel();
        careerCoursesToInsert.Add(careerCourse);
        await careerCoursesGrid.InsertRow(careerCourse);
    }

    private async Task OnCreateRow(CareerCourseModel careerCourse)
    {
        careerCourse.CareerCode = CareerCode;
        careerCourse.CourseName = _courses.First(c => c.CourseCode == careerCourse.CourseCode).CourseName;
        await CareerCourseService.AddCareerCourseAsync(careerCourse);
        careerCoursesToInsert.Remove(careerCourse);
    }
}