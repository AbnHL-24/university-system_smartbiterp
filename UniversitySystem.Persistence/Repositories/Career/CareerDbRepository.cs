using Dapper;
using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Repositories.Career;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.SqlQueries.Career;

namespace UniversitySystem.Persistence.Repositories.Career;

public class CareerDbRepository(DapperContext context) : ICareerRepository
{
    public async Task<IEnumerable<CareerModel>> GetCareersAsync()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<CareerModel>(CareerQueries.GetCareers);
    }

    public async Task<CareerModel?> GetCareerAsync(int careerCode)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CareerModel>(CareerQueries.GetCareer, new { CareerCode = careerCode });
    }

    public async Task AddCareerAsync(CareerModel careerModel)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.AddCareer, careerModel);
    }

    public async Task UpdateCareerAsync(CareerModel careerModel)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.UpdateCareer, careerModel);
    }

    public async Task DeleteCareerAsync(int careerCode)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.DeleteCareer, new { CareerCode = careerCode });
    }
}