using UniversitySystem.Domain.Models;

namespace UniversitySystem.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetUsersAsync();
    Task<UserModel?> GetUserAsync(int userCode);
    Task AddUserAsync(UserModel userModel);
    Task UpdateUserAsync(UserModel userModel);
    Task DeleteUserAsync(int userId);
}