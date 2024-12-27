namespace UniversitySystem.Domain.Models;

public class UserModel
{
    public int UserCode { get; set; }
    public string FullName { get; set; }
    public UserType UserType { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}