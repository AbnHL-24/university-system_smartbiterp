using UniversitySystem.Domain.Models.Career;

namespace UniversitySystem.Domain.Services.Career;

public interface ICareerService
{
    Task<IEnumerable<CareerModel>> GetCareersAsync();
    Task<CareerModel?> GetCareerAsync(int careerCode);
    Task AddCareerAsync(CareerModel careerModel);
    Task UpdateCareerAsync(CareerModel careerModel);
    Task DeleteCareerAsync(int careerCode);
}