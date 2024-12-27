namespace UniversitySystem.Persistence.SqlQueries.Career;

public static class CareerCourseQueries
{
    public const string GetCareerCourses = @"
        SELECT
            cc.career_course_code [CareerCourseCode],
            cc.career_code [CareerCode],
            cc.course_code [CourseCode],
            c.course_name [CourseName],
            cc.semester_number [Semester]
        FROM tb_career_courses cc
        INNER JOIN tb_course c ON cc.course_code = c.course_code
        WHERE cc.career_code = @CareerCode";
    
    public const string AddCareerCourse = @"
        INSERT INTO tb_career_courses (career_code, course_code, semester_number)
        VALUES (@CareerCode, @CourseCode, @Semester)";
    
    public const string DeleteCareerCourse = @"
        DELETE FROM tb_career_courses
        WHERE career_code = @CareerCode AND course_code = @CourseCode";
    
}