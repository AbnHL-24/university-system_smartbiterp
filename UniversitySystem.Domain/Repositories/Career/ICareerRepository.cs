using UniversitySystem.Domain.Models.Career;

namespace UniversitySystem.Domain.Repositories.Career;

public interface ICareerRepository
{
    Task<IEnumerable<CareerModel>> GetCareersAsync();
    Task<CareerModel?> GetCareerAsync(int careerCode);
    Task AddCareerAsync(CareerModel careerModel);
    Task UpdateCareerAsync(CareerModel careerModel);
    Task DeleteCareerAsync(int careerCode);
}