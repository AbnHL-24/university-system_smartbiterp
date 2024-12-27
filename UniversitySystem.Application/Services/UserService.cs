using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Repositories;
using UniversitySystem.Domain.Services;

namespace UniversitySystem.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<IEnumerable<UserModel>> GetUsersAsync()
    {
        return await userRepository.GetUsersAsync();
    }

    public async Task<UserModel?> GetUserAsync(int userId)
    {
        return await userRepository.GetUserAsync(userId);
    }

    public async Task AddUserAsync(UserModel userModel)
    {
        await userRepository.AddUserAsync(userModel);
    }

    public async Task UpdateUserAsync(UserModel userModel)
    {
        await userRepository.UpdateUserAsync(userModel);
    }

    public async Task DeleteUserAsync(int userId)
    {
        await userRepository.DeleteUserAsync(userId);
    }
}