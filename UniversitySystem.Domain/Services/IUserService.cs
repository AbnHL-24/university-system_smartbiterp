using UniversitySystem.Domain.Models;

namespace UniversitySystem.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetUsersAsync();
    Task<UserModel?> GetUserAsync(int userId);
    Task AddUserAsync(UserModel userModel);
    Task UpdateUserAsync(UserModel userModel);
    Task DeleteUserAsync(int userId);
    
}