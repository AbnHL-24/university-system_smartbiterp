namespace UniversitySystem.Persistence.SqlQueries;

public static class UserQueries
{
    public const string GetUsers = "SELECT user_code [UserCode], fullname [FullName], user_type [UserType], username [Username], password [Password] FROM tb_user";
    public const string GetUser = "SELECT * FROM tb_user WHERE user_code = @UserCode";
    public const string AddUser = "INSERT INTO tb_user (user_code, fullname, user_type, username, password) VALUES (@UserCode, @FullName, @UserType, @Username, @Password)";
    public const string UpdateUser = "UPDATE tb_user SET fullname = @FullName, user_type = @UserType, username = @Username, password = @Password WHERE user_code = @UserCode";
    public const string DeleteUser = "DELETE FROM tb_user WHERE user_code = @UserCode";
}