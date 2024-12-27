using Microsoft.Extensions.DependencyInjection;
using UniversitySystem.Application.Services;
using UniversitySystem.Application.Services.Authentication;
using UniversitySystem.Application.Services.Career;
using UniversitySystem.Domain.Services;
using UniversitySystem.Domain.Services.Authentication;
using UniversitySystem.Domain.Services.Career;

namespace UniversitySystem.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICareerService, CareerService>();
        services.AddScoped<ICareerCourseService, CareerCourseService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}