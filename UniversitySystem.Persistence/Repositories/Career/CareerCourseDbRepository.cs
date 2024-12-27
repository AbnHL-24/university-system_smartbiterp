using System.Data;
using Dapper;
using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Repositories.Career;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.SqlQueries.Career;

namespace UniversitySystem.Persistence.Repositories.Career;

public class CareerCourseDbRepository(DapperContext context) : ICareerCourseRepository
{
    public async Task<IEnumerable<CareerCourseModel>> GetCareerCoursesAsync(int careerCode)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CareerCode", careerCode, DbType.Int32);
        
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<CareerCourseModel>(CareerCourseQueries.GetCareerCourses, parameters);
    }

    public async Task AddCareerCourseAsync(CareerCourseModel careerCourseModel)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CareerCode", careerCourseModel.CareerCode, DbType.Int32);
        parameters.Add("@CourseCode", careerCourseModel.CourseCode, DbType.Int32);
        parameters.Add("@Semester", careerCourseModel.Semester, DbType.Int32);
        
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerCourseQueries.AddCareerCourse, parameters);
    }

    public async Task DeleteCareerCourseAsync(int careerCode, int courseCode)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@CareerCode", careerCode, DbType.Int32);
        parameters.Add("@CourseCode", courseCode, DbType.Int32);
        
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerCourseQueries.DeleteCareerCourse, parameters);
    }
}