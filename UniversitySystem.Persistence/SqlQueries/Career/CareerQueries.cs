namespace UniversitySystem.Persistence.SqlQueries.Career;

public static class CareerQueries
{
    public const string GetCareers = "SELECT career_code [CareerCode], career_name [CareerName] FROM tb_career";
    public const string GetCareer = "SELECT * FROM tb_career WHERE career_code = @CareerCode";
    public const string AddCareer = "INSERT INTO tb_career (career_code, career_name) VALUES (@CareerCode, @CareerName)";
    public const string UpdateCareer = "UPDATE tb_career SET career_name = @CareerName WHERE career_code = @CareerCode";
    public const string DeleteCareer = "DELETE FROM tb_career WHERE career_code = @CareerCode";
}