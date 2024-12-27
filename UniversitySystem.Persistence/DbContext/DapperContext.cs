using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using UniversitySystem.Domain.Models;
using UniversitySystem.Domain.Models.Career;

namespace UniversitySystem.Persistence.DbContext;

public class DapperContext
{
    private readonly string _connectionString;
    
    public DapperContext(IConfiguration configuration)
    {
        var connectionModel = configuration.GetSection("Connections:dbuniversity").Get<ConnectionModel>();
        _connectionString = connectionModel!.ConnectionString;
    }

    public IDbConnection CreateConnection() =>
        new SqlConnection(_connectionString);
}