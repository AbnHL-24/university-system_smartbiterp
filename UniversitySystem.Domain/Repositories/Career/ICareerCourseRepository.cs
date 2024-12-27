using UniversitySystem.Domain.Models.Career;

namespace UniversitySystem.Domain.Repositories.Career;

public interface ICareerCourseRepository
{
    Task<IEnumerable<CareerCourseModel> > GetCareerCoursesAsync(int careerCode);
    Task AddCareerCourseAsync(CareerCourseModel careerCourseModel);
    Task DeleteCareerCourseAsync(int careerCode, int courseCode);
}