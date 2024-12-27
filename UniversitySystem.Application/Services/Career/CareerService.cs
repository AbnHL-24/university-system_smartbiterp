using UniversitySystem.Domain.Models.Career;
using UniversitySystem.Domain.Repositories.Career;
using UniversitySystem.Domain.Services.Career;

namespace UniversitySystem.Application.Services.Career;

public class CareerService(ICareerRepository careerRepository) : ICareerService
{
    public async Task<IEnumerable<CareerModel>> GetCareersAsync()
    {
        return await careerRepository.GetCareersAsync();
    }

    public async Task<CareerModel?> GetCareerAsync(int careerCode)
    {
        return await careerRepository.GetCareerAsync(careerCode);
    }

    public async Task AddCareerAsync(CareerModel careerModel)
    {
        await careerRepository.AddCareerAsync(careerModel);
    }

    public async Task UpdateCareerAsync(CareerModel careerModel)
    {
        await careerRepository.UpdateCareerAsync(careerModel);
    }

    public async Task DeleteCareerAsync(int careerCode)
    {
        await careerRepository.DeleteCareerAsync(careerCode);
    }
}