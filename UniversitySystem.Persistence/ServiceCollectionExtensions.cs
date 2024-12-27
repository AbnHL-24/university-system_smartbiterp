using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversitySystem.Application.Services;
using UniversitySystem.Domain.Repositories;
using UniversitySystem.Domain.Repositories.Authentication;
using UniversitySystem.Domain.Repositories.Career;
using UniversitySystem.Domain.Services;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.Repositories;
using UniversitySystem.Persistence.Repositories.Authentication;
using UniversitySystem.Persistence.Repositories.Career;

namespace UniversitySystem.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DapperContext>();
        services.AddScoped<ICareerRepository, CareerDbRepository>();
        services.AddScoped<ICareerCourseRepository, CareerCourseDbRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        
        return services;
    }
}