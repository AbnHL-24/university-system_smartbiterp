using Dapper;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Course;
using UniversitySystem.Domain.Repositories;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.SqlQueries;

namespace UniversitySystem.Persistence.Repositories;

public class CourseRepository(DapperContext context) : ICourseRepository
{
    public async Task<IEnumerable<CourseModel>> GetCoursesAsync()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<CourseModel>(CourseQueries.GetCourses);
    }

    public async Task<IEnumerable<AssignedCourse>> GetCoursesByStudentAsync(int studentCode)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<AssignedCourse>(CourseQueries.GetCoursesByStudent, new { StudentCode = studentCode });
    }

    public async Task<CourseModel?> GetCourseAsync(int courseCode)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CourseModel>(CourseQueries.GetCourse, new { CourseCode = courseCode });
    }

    public async Task AddCourseAsync(CourseModel courseModel)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CourseQueries.AddCourse, courseModel);
    }

    public async Task UpdateCourseAsync(CourseModel courseModel)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CourseQueries.UpdateCourse, courseModel);
    }

    public async Task DeleteCourseAsync(int courseCode)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CourseQueries.DeleteCourse, new { CourseCode = courseCode });
    }
}