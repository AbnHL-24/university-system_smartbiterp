CREATE DATABASE db_university;
USE db_university;

CREATE TABLE [tb_user] (
  [user_code] int PRIMARY KEY,
  [fullname] varchar(100),
  [user_type] varchar(45) CHECK ([user_type] IN ('ADMIN', 'TEACHER', 'STUDENT')),
  [username] varchar(45),
  [password] varchar(500)
);
GO

CREATE TABLE [tb_career] (
  [career_code] int PRIMARY KEY,
  [career_name] varchar(45)
);
GO

CREATE TABLE [tb_user_careers] (
  [user_code] int,
  [career_code] int
);
GO

CREATE TABLE [tb_course] (
  [course_code] int PRIMARY KEY,
  [course_name] varchar(100)
);
GO

CREATE TABLE [tb_career_courses] (
  [career_course_code] int,
  [career_code] int,
  [course_code] int,
  [semester_number] int
);
GO

CREATE TABLE [tb_course_opening] (
  [course_opening_code] int PRIMARY KEY,
  [course_code] int,
  [year] varchar(45),
  [semester] int,
  [teacher_code] int
);
GO

CREATE TABLE [tb_course_assignment] (
  [course_assignment_code] int PRIMARY KEY,
  [student_code] int,
  [course_opening_code] int,
  [grade] varchar(45),
  [approved] AS (
  	CASE
		WHEN ISNULL(TRY_CAST(grade AS int), 0) > 61 THEN 1
		ELSE 0
	END
  )
)
GO

ALTER TABLE [tb_user_careers] ADD FOREIGN KEY ([user_code]) REFERENCES [tb_user] ([user_code])
GO

ALTER TABLE [tb_user_careers] ADD FOREIGN KEY ([career_code]) REFERENCES [tb_career] ([career_code])
GO

ALTER TABLE [tb_career_courses] ADD FOREIGN KEY ([career_code]) REFERENCES [tb_career] ([career_code])
GO

ALTER TABLE [tb_career_courses] ADD FOREIGN KEY ([course_code]) REFERENCES [tb_course] ([course_code])
GO

ALTER TABLE [tb_course_opening] ADD FOREIGN KEY ([course_code]) REFERENCES [tb_course] ([course_code])
GO

ALTER TABLE [tb_course_opening] ADD FOREIGN KEY ([teacher_code]) REFERENCES [tb_user] ([user_code])
GO

ALTER TABLE [tb_course_assignment] ADD FOREIGN KEY ([student_code]) REFERENCES [tb_user] ([user_code])
GO

ALTER TABLE [tb_course_assignment] ADD FOREIGN KEY ([course_opening_code]) REFERENCES [tb_course_opening] ([course_opening_code])
GO


INSERT INTO [tb_user] ([user_code], [fullname], [user_type], [username], [password])
VALUES
(1, 'Admin User', 'ADMIN', 'admin_user', 'admin123'),
(2, 'John Doe', 'TEACHER', 'jdoe', 'password123'),
(3, 'Jane Smith', 'TEACHER', 'jsmith', 'password123'),
(4, 'Alice Johnson', 'STUDENT', 'alicej', 'password123'),
(5, 'Bob Brown', 'STUDENT', 'bobb', 'password123'),
(6, 'Charlie White', 'TEACHER', 'cwhite', 'teach123'),
(7, 'Diana Prince', 'STUDENT', 'dprince', 'student123'),
(8, 'Evan Black', 'ADMIN', 'eblack', 'admin321'),
(9, 'Fiona Green', 'TEACHER', 'fgreen', 'teach321'),
(10, 'George Blue', 'STUDENT', 'gblue', 'bluepass'),
(11, 'Hannah Red', 'STUDENT', 'hred', 'redpass'),
(12, 'Ian Yellow', 'TEACHER', 'iyellow', 'yellowpass'),
(13, 'Jack Purple', 'ADMIN', 'jpurple', 'purple123'),
(14, 'Karen Pink', 'TEACHER', 'kpink', 'pinkpass'),
(15, 'Leo Orange', 'STUDENT', 'lorange', 'orangepass');


INSERT INTO [tb_career] ([career_code], [career_name])
VALUES
(1, 'Computer Science'),
(2, 'Business Administration'),
(3, 'Mechanical Engineering'),
(4, 'Civil Engineering'),
(5, 'Electrical Engineering'),
(6, 'Mathematics'),
(7, 'Physics'),
(8, 'Chemistry'),
(9, 'Biology'),
(10, 'Philosophy'),
(11, 'Psychology'),
(12, 'Economics'),
(13, 'Political Science');


INSERT INTO [tb_user_careers] ([user_code], [career_code])
VALUES
(4, 1),
(5, 2),
(6, 3),
(7, 4),
(8, 5),
(9, 6),
(10, 7),
(11, 8),
(12, 9),
(13, 10),
(14, 11),
(15, 12);



INSERT INTO [tb_course] ([course_code], [course_name])
VALUES
(101, 'Introduction to Programming'),
(102, 'Database Systems'),
(201, 'Business Management'),
(202, 'Marketing Principles'),
(301, 'Thermodynamics'),
(302, 'Mechanical Design'),
(401, 'Structural Analysis'),
(402, 'Electromagnetic Theory'),
(501, 'Calculus I'),
(502, 'Calculus II'),
(601, 'Classical Mechanics'),
(602, 'Organic Chemistry'),
(701, 'Genetics'),
(702, 'Ethics'),
(801, 'Cognitive Psychology');



INSERT INTO [tb_course_opening] ([course_opening_code], [course_code], [year], [semester], [teacher_code])
VALUES
(1, 101, '2024', 1, 2),
(2, 102, '2024', 2, 3),
(3, 201, '2024', 1, 2),
(4, 202, '2024', 2, 3),
(5, 301, '2024', 1, 2),
(6, 302, '2024', 2, 3),
(7, 401, '2024', 1, 6),
(8, 402, '2024', 2, 9),
(9, 501, '2024', 1, 12),
(10, 502, '2024', 2, 14),
(11, 601, '2024', 1, 8),
(12, 602, '2024', 2, 11),
(13, 701, '2024', 1, 13),
(14, 702, '2024', 2, 15),
(15, 801, '2024', 1, 7);



INSERT INTO [tb_course_assignment] ([course_assignment_code], [student_code], [course_opening_code], [grade])
VALUES
(1, 4, 1, '85'),
(2, 4, 2, '90'),
(3, 5, 3, '75'),
(4, 5, 4, '60'),
(5, 4, 5, '88'),
(6, 5, 6, '72'),
(7, 7, 7, '95'),
(8, 7, 8, '88'),
(9, 10, 9, '84'),
(10, 10, 10, '91'),
(11, 11, 11, '80'),
(12, 12, 12, '87'),
(13, 13, 13, '78'),
(14, 14, 14, '89'),
(15, 15, 15, '92');