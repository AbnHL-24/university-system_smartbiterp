namespace UniversitySystem.Domain.Models;

public class ConnectionModel
{
    public string Server { get; set; }
    public string Port { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Timeout { get; set; }
    
    public string ConnectionString => $"Server={Server},{Port};Database={Database};User Id={User};Password={Password};Encrypt=True;TrustServerCertificate=True;Connect Timeout={Timeout};";
}