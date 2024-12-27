using Dapper;
using UniversitySystem.Domain.Models.Authentication;
using UniversitySystem.Domain.Repositories.Authentication;
using UniversitySystem.Persistence.DbContext;
using UniversitySystem.Persistence.SqlQueries.Authentication;

namespace UniversitySystem.Persistence.Repositories.Authentication;

public class AuthenticationRepository(DapperContext context) : IAuthenticationRepository
{
    public async Task<SessionData?> AuthenticateAsync(string username, string password)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Username", username);
        parameters.Add("@Password", password);
        
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<SessionData>(AuthenticationQueries.Authenticate, parameters);
    }
}