using UniversitySystem.Domain.Models.Career;

namespace UniversitySystem.Domain.Services.Career;

public interface ICareerCourseService
{
    Task<IEnumerable<CareerCourseModel> > GetCareerCoursesAsync(int careerCode);
    Task AddCareerCourseAsync(CareerCourseModel careerCourseModel);
    Task DeleteCareerCourseAsync(int careerCode, int courseCode);
}