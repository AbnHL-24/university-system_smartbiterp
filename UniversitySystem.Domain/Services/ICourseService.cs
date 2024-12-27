using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Course;

namespace UniversitySystem.Domain.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseModel>> GetCoursesAsync();
    Task<IEnumerable<AssignedCourse>> GetCoursesByStudentAsync(int studentCode);
    Task<MemoryStream> GeneratePDF(IEnumerable<AssignedCourse> assignedCourses, int studentCode, string studentName);
    Task<CourseModel?> GetCourseAsync(int courseCode);
    Task AddCourseAsync(CourseModel courseModel);
    Task UpdateCourseAsync(CourseModel courseModel);
    Task DeleteCourseAsync(int courseCode);
}