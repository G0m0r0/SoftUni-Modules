CREATE DATABASE [Service]
USE [Service]

--1
CREATE TABLE Users(
	Id Int PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age>=14 AND Age<=110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age>=18 AND Age<=110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

SET IDENTITY_INSERT [Reports] OFF
--2
INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId)
	VALUES
			('Marlo',	'O''Malley', '1958-9-21',	1),
			('Niki',	'Stanaghan',	'1969-11-26',	4),
			('Ayrton',	'Senna',	'1960-03-21',	9),
			('Ronnie',	'Peterson',	'1944-02-14',	9),
			('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId)
	VALUES
			(1,	1,	'2017-04-13',NULL,	'Stuck Road on Str.133',	6,	2),
			(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running',3,5),
			(14,	2,	'2015-09-07',NULL,	'Falling bricks on Str.58',	5,	2),
			(4,	4,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11', 1,	1)
INSERT INTO Status(Label)
	VAlues
			('MYLABEL')
--3
SELECT * FROM Reports
	WHERE CloseDate IS NULL

UPDATE Reports
	SET CloseDate=GETDATE()
	WHERE CloseDate IS NULL;

SELECT * FROM Reports
	WHERE StatusId=4
SELECT * FROM Status
--4
DELETE FROM Reports
	Where StatusId=4

--5
--if we name format to open date we sort by Reports.OpenDate (the orignal date)
SELECT [Description],FORMAT(OpenDate,'dd-MM-yyyy') FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC,Description ASC

--6
SELECT [Description],c.[Name] FROM Reports AS r
	 JOIN Categories AS c ON c.Id=r.CategoryId
	 ORDER BY r.[Description] ASC,c.[Name] ASC
	
--7
SELECT * FROM Reports
SELECT * FROM Categories

SELECT TOP(5) c.[Name],COUNT(CategoryId) AS ReportsNumber FROM Reports AS r
	 JOIN Categories AS c ON c.Id=r.CategoryId
	 GROUP BY c.[Name]
	 ORDER BY COUNT(CategoryId) DESC,c.[Name] ASC
--or
SELECT TOP(5)	
				[Name], 
				(SELECT COUNT(*) FROM Reports WHERE CategoryId=c.Id)AS [ReportsNumber] 
				FROM Categories AS c
	ORDER BY [ReportsNumber] DESC, [Name] ASC

--8
SELECT u.Username,c.[Name] FROM Reports AS r	
	JOIN Users AS u ON u.Id=r.UserId
	JOIN Categories AS c ON c.Id=r.CategoryId
	WHERE DATEPART(MONTH,r.OpenDate)=DATEPART(MONTH,Birthdate) AND DATEPART(DAY,r.OpenDate)=DATEPART(DAY,Birthdate)
	ORDER BY u.Username,c.[Name]

--9
USE Service

SELECT e.FirstName+' '+e.LastName AS FullName,COUNT(DISTINCT r.UserId) AS UsersCount FROM Reports AS r
	RIGHT JOIN Employees AS e ON r.EmployeeId=e.Id
	GROUP BY r.EmployeeId,e.FirstName,e.LastName
	ORDER BY COUNT(DISTINCT r.UserId) DESC,FullName

--or
SELECT FirstName+' '+LastName AS FullName,
		(SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId=e.Id) AS UsersCount FROM Employees AS e
		ORDER BY UsersCount DESC, FullName ASC

--10
SELECT ISNULL(e.FirstName+' '+e.LastName,'None') AS Employee,
		ISNULL(d.[Name],'None') AS Department,
		c.[Name] AS Category,
		r.[Description],
		FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
		s.[Label] AS [Status],
		ISNULL(u.[Name],'None') AS [User]
		FROM Reports AS r
	LEFT JOIN Employees AS e ON r.EmployeeId=e.Id
	LEFT JOIN Categories AS c ON c.Id=r.CategoryId
	LEFT JOIN Departments AS d ON d.Id=e.DepartmentId
	LEFT JOIN [Status] AS s ON s.Id=r.StatusId
	LEFT JOIN Users AS u ON u.Id=r.UserId
	ORDER BY FirstName DESC, LastName DESC, 
			d.[Name],c.[Name],r.[Description],r.OpenDate,s.[Label],u.[Name]

--11
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME2, @EndDate DATETIME2) 
RETURNS INT
AS
	BEGIN
		if(@StartDate IS NULL)
			RETURN 0;
		if(@EndDate IS NULL)
			RETURN 0;

		DECLARE @totalHoursDiff INT=DATEDIFF(HOUR,@StartDate,@EndDate)

		RETURN @totalHoursDiff;
	END
GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12
Go
CREATE OR ALTER PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	BEGIN
		DECLARE @EmployeeDepartmentId INT=(SELECT DepartmentId FROM Employees WHERE Id=@EmployeeId)

		DECLARE @ReportDepartmentId INT=
						(SELECT c.DepartmentId FROM Reports AS r 
							JOIN Categories AS c ON c.Id=r.CategoryId
							WHERE r.Id=@ReportId)

		if(@EmployeeDepartmentId!=@ReportDepartmentId)
			THROW 50001,'Employee doesn''t belong to the appropriate department!',1

		UPDATE Reports 
		SET EmployeeId=@EmployeeId
		WHERE Id=@ReportId
	END

EXEC usp_AssignEmployeeToReport 30, 1