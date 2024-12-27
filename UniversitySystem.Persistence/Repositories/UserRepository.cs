using Dapper;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Repositories;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.SqlQueries;

namespace UniversitySystem.Persistence.Repositories;

public class UserRepository (DapperContext context) : IUserRepository
{
    public async Task<IEnumerable<UserModel>> GetUsersAsync()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<UserModel>(UserQueries.GetUsers);
    }

    public async Task<UserModel?> GetUserAsync(int userCode)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UserModel>(UserQueries.GetUser, new { UserCode = userCode });
    }

    public async Task AddUserAsync(UserModel userModel)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserCode", userModel.UserCode);
        parameters.Add("FullName", userModel.FullName);
        parameters.Add("UserType", userModel.UserType.ToString());
        parameters.Add("UserName", userModel.UserName);
        parameters.Add("Password", userModel.Password);
        
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UserQueries.AddUser, parameters);
    }

    public async Task UpdateUserAsync(UserModel userModel)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserCode", userModel.UserCode);
        parameters.Add("FullName", userModel.FullName);
        parameters.Add("UserType", userModel.UserType.ToString());
        parameters.Add("UserName", userModel.UserName);
        parameters.Add("Password", userModel.Password);
        
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UserQueries.UpdateUser, parameters);
    }

    public async Task DeleteUserAsync(int userId)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UserQueries.DeleteUser, new { UserCode = userId });
    }
}