CREATE DATABASE School
USE School
--1

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age TINYINT check(Age> 0),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10) 
)


CREATE TABLE [Subjects](
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
)


CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL,
	SubjectId INT NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade>=2 AND Grade<=6) NOT NULL

	CONSTRAINT FK_StudentsSubjects_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
	CONSTRAINT FK_StudentsSubjects_Subjects FOREIGN KEY (SubjectId) REFERENCES Subjects (Id),
)


CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT NOT NULL,
	ExamId INT NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade>=2 AND Grade<=6) NOT NULL

	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId),

	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamId) REFERENCES Exams (Id),
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	[Phone] NVARCHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT NOT NULL,
	TeacherId INT NOT NULL

	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId),
	CONSTRAINT FK_StudentsTeachers_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
	CONSTRAINT FK_StudentsTeachers_Teachers FOREIGN KEY (TeacherId) REFERENCES Teachers (Id),
)

--2
INSERT INTO Teachers(FirstName,LastName,[Address],Phone,SubjectId)
	VALUES
			('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
			('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
			('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
			('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects([Name],Lessons)
	VALUES
			('Geometry',12),
			('Health',10),
			('Drama',7),
			('Sports',9)

--3
SELECT * FROM StudentsSubjects

UPDATE StudentsSubjects
	SET Grade=6.00
	WHERE Grade>=5.50 AND (SubjectId=1 OR SubjectId=2)

--4
DELETE FROM StudentsTeachers
	WHERE TeacherId IN (
							SELECT Id FROM Teachers
							WHERE Phone LIKE '%72%'
							)


DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

--5
SELECT FirstName,LastName,Age FROM Students
	WHERE Age>=12
	ORDER BY FirstName,LastName

--6
SELECT * FROM Students
SELECT * FROM StudentsTeachers
SELECT * FROM Teachers

SELECT s.FirstName,s.LastName,COUNT(st.TeacherId) AS TeachersCount FROM Students AS s
	JOIN StudentsTeachers AS st ON st.StudentId=s.Id
	GROUP BY s.FirstName,s.LastName

--7
SELECT * FROM Students
SELECT * FROM StudentsExams
SELECT * FROM Exams


SELECT FirstName+' '+LastName AS [Full Name] FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id=se.StudentId
	WHERE se.StudentId IS NULL
	ORDER BY [Full Name] ASC

--8
SELECT TOP(10) FirstName,LastName,FORMAT(AVG(Grade),'N2') AS Grade FROM Students AS s
	JOIN StudentsExams AS se ON se.StudentId=s.Id
	JOIN Exams As e ON e.Id=se.ExamId
	GROUP BY FirstName,LastName
	ORDER BY Grade DESC, FirstName,LastName

--9
SELECT 
		CASE
			WHEN MiddleName IS NULL THEN CONCAT(s.FirstName, ' ', s.LastName)
			ELSE CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName) 
		END AS [Full Name] FROM Students AS s
	LEFT JOIN StudentsSubjects AS ss ON ss.StudentId=s.Id
	WHERE ss.StudentId IS NULL
	ORDER BY [Full Name]


--10
USE School
SELECT s.Name,AVG(Grade) AS AverageGrade FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON s.Id=ss.SubjectId
	GROUP BY s.id,s.Name
	ORDER BY s.Id

--11
GO
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(4,2))
RETURNS VARCHAR(100)
AS
	BEGIN
		DECLARE @Student INT=(SELECT COUNT(*) FROM Students WHERE id=@studentId)
		IF(@Student=0)
			RETURN 'The student with provided id does not exist in the school!';
		IF(@grade>6.00)
			RETURN 'Grade cannot be above 6.00!                                  '

		DECLARE @CountOfGrades INT=(
									SELECT COUNT(*) FROM StudentsExams AS se
												JOIN Students AS s ON se.StudentId = s.Id
												WHERE s.id=@studentId AND (se.Grade>=@grade AND se.Grade<=@grade+0.50)
									)
		DECLARE @StudentsFirstName VARCHAR(50)= (SELECT FirstName FROM Students WHERE id=@studentId)
		RETURN CONCAT('You have to update ',@CountOfGrades,' grades for the student ',@StudentsFirstName )
	END
GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
--Grade cannot be above 6.00!
		
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
--You have to update 2 grades for the student Agace

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)
--The student with provided id does not exist in the school!


--12
GO
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	BEGIN
		DECLARE @Student INT=(SELECT COUNT(*) FROM Students WHERE Id=@StudentId)
		if(@Student=0)
			THROW 50001, 'This school has no student with the provided id!',1

		DELETE FROM StudentsTeachers
			WHERE StudentId=@StudentId

		DELETE FROM StudentsSubjects
			WHERE StudentId=@StudentId

		DELETE FROM StudentsExams
			WHERE StudentId=@StudentId

		DELETE FROM Students
			WHERE id=@StudentId
	END
GO

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301
