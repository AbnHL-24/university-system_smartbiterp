namespace UniversitySystem.Domain.Models.Career;

public class CareerCourseModel
{
    public int CareerCourseCode { get; set; }
    public int CareerCode { get; set; }
    public int CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Semester { get; set; }
}