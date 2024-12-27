using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Course;

namespace UniversitySystem.Domain.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<CourseModel>> GetCoursesAsync();
    Task<IEnumerable<AssignedCourse>> GetCoursesByStudentAsync(int studentCode);
    Task<CourseModel?> GetCourseAsync(int courseCode);
    Task AddCourseAsync(CourseModel courseModel);
    Task UpdateCourseAsync(CourseModel courseModel);
    Task DeleteCourseAsync(int courseCode);
}