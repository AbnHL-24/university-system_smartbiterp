namespace UniversitySystem.Domain.Models.Course;

public class AssignedCourse
{
    public int CourseCode { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Semester { get; set; }
    public int Grade { get; set; }
    public bool Approved { get; set; }
}