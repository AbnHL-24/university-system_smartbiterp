using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Repositories.Career;
using UniversitySystem.Domain.Services.Career;

namespace UniversitySystem.Application.Services.Career;

public class CareerCourseService(ICareerCourseRepository careerCourseRepository) : ICareerCourseService
{
    public async Task<IEnumerable<CareerCourseModel>> GetCareerCoursesAsync(int careerCode)
    {
        return await careerCourseRepository.GetCareerCoursesAsync(careerCode);
    }

    public async Task AddCareerCourseAsync(CareerCourseModel careerCourseModel)
    {
        await careerCourseRepository.AddCareerCourseAsync(careerCourseModel);
    }

    public async Task DeleteCareerCourseAsync(int careerCode, int courseCode)
    {
        await careerCourseRepository.DeleteCareerCourseAsync(careerCode, courseCode);
    }
}