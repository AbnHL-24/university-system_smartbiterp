namespace UniversitySystem.Persistence.SqlQueries;

public static class CourseQueries
{
    public const string GetCourses = "SELECT course_code [CourseCode], course_name [CourseName] FROM tb_course";
    public const string GetCoursesByStudent = @"
        SELECT
			tc.course_code [CourseCode],
			tc.course_name [CourseName],
			tco.[year] [Year],
			tco.semester [Semester],
			tca.grade [Grade],
			tca.approved [Approved]
		FROM tb_course_assignment tca
		INNER JOIN tb_course_opening tco ON
			tca.course_opening_code = tco.course_opening_code
		INNER JOIN tb_course tc ON
			tco.course_code = tc.course_code
		WHERE tca.student_code  = @StudentCode"; 
    public const string GetCourse = "SELECT * FROM tb_course WHERE course_code = @CourseCode";
    public const string AddCourse = "INSERT INTO tb_course (course_code, course_name) VALUES (@CourseCode, @CourseName)";
    public const string UpdateCourse = "UPDATE tb_course SET course_name = @CourseName WHERE course_code = @CourseCode";
    public const string DeleteCourse = "DELETE FROM tb_course WHERE course_code = @CourseCode";
}