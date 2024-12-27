namespace UniversitySystem.Persistence.SqlQueries.Authentication;

public static class AuthenticationQueries
{
    public const string Authenticate = @"
        SELECT 
            user_code [UserId],
            fullname [Name],
            user_type [Role]
        FROM
            tb_user
        WHERE
            username = @Username
            AND
            password = @Password";
}