--create our own functions
CREATE FUNCTION udf_myfunctions(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS BEGIN
		--my code
		--it can contain everything without insert update and delete
		return 5 --myvariable int
		END

--dinamic query
USE SoftUni

GO

DECLARE @TableName nvarchar(8) = 'Employee';
EXEC('SELECT COUNT(*) FROM '+@TableName)


--power functions
CREATE FUNCTION udf_Pow(@Base int,@Exp int)
RETURNS BIGINT
AS 
BEGIN
	DECLARE @result BIGINT=1;
		WHILE (@Exp>0)
		BEGIN
			SET @result*=@Base
			SET @Exp-=1;
		END
	return @result
END;


SELECT dbo.udf_Pow(2,10),POWER(2,10)

--with alter we can edit our function
ALTER FUNCTION udf_Pow(@Base int,@Exp int)
RETURNS BIGINT
AS 
BEGIN
	DECLARE @result BIGINT=1;
		WHILE (@Exp>0)
		BEGIN
			SET @result*=@Base
			SET @Exp-=1;
		END
	return @result
END;


SELECT dbo.udf_Pow(2,10),POWER(2,10)


--create or alter
CREATE OR ALTER FUNCTION udf_GETDifferenceBetDates(@StartDate datetime,@EndDate datetime)
RETURNS INT
AS 
BEGIN
		IF(@EndDate IS NULL)
			SET @EndDate=GETDATE();

		RETURN DATEDIFF(week,@startDate,@EndDate);
END

SELECT [dbo].[udf_GETDifferenceBetDates]('01-01-1999','01-01-2005')


--return table
CREATE OR ALTER FUNCTION udf_GetEmployeesCountByYear(@Year int)
RETURNS TABLE
AS
RETURN
(
	SELECT COUNT(*) AS [COUNT]
		FROM Employees
		WHERE DATEPART(year,HireDate)=@Year
)

SELECT * FROM dbo.udf_GetEmployeesCountByYear(2000)

--returns table with employees
CREATE OR ALTER FUNCTION udf_GetEmployeesByYear(@Year int)
RETURNS TABLE
AS
RETURN
(
	SELECT * 
		FROM Employees
		WHERE DATEPART(year,HireDate)=@Year
)

SELECT * FROM dbo.udf_GetEmployeesByYear(2000)


--random numbers table
CREATE OR ALTER FUNCTION udf_Squares(@Count int)
RETURNS @squares TABLE(
	Id int PRIMARY KEY IDENTITY,
	[Square] bigint
)
AS
BEGIN
	DECLARE @i int=1

	WHILE(@i <= @Count)
	BEGIN		
		INSERT INTO @squares([Square]) VALUES(@i*@i)
		SET @i+=1
	END
	RETURN
END


SELECT * FROM [dbo].[udf_Squares](10)


--exercise
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary money)
RETURNS VARCHAR(MAX)
As
BEGIN
		IF(@Salary IS NULL) RETURN NULL

		IF(@Salary<30000) RETURN 'Low'
		ELSE IF(@Salary<=50000) RETURN 'Average'
		ELSE RETURN 'High'
		RETURN '';
END


SELECT FirstName,LastName,Salary,dbo.ufn_GetSalaryLevel(Salary) FROM Employees


--stored procedures
EXEC sp_databases

--create stored procedures
USE SoftUni
GO

CREATE PROC dbo.usp_SelectEmployeesBySeniority
AS
	SELECT * FROM Employees
	WHERE DATEDIFF(Year,HireDate,GETDATE())>19
GO

--exercise with variable and default value
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience(@Year int=19)
AS
	SELECT * FROM Employees 
	WHERE DATEDIFF(year,HireDate,GETDATE())>@Year
GO

EXEC sp_GetEmployeesByExperience @Year=21
--or
EXEC sp_GetEmployeesByExperience 21
--DROP PROC - to drop it

--system proc
EXEC sp_monitor
EXEC sp_depends 'dbo.Employees'


--output stored procedures
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperienceOUT(@Count int OUTPUT,@Year int=19)
AS
	--single output
	SET @Count=(SELECT COUNT(*) FROM Employees 
	WHERE DATEDIFF(year,HireDate,GETDATE())>@Year)

GO

DECLARE @Count int;
EXECUTE sp_GetEmployeesByExperience @Count OUTPUT;

SELECT @Count

--stored procedure error messages for deviding to zero
SELECT * FROM sys.messages
	WHERE message_id=8314


--error handling

SELECT 2/0

THROW 50001, 'Null value for ',5;

--try catch
BEGIN TRY
	SELECT 0/0
END TRY
BEGIN CATCH
	SELECT @@ERROR
	SELECT ERROR_NUMBER() AS ErrorNum
	SELECT ERROR_LINE() AS ErrorLine
END CATCH




--exercise
CREATE OR ALTER PROCEDURE sp_InsertEmployeeForProject(@EmployeeId int,@ProjectId int)
AS
	DECLARE @ProjectsCount int;
	SET @ProjectsCount=(Select COUNT(*) FROM EmployeesProjects
							WHERE EmployeeID=@EmployeeId);
	IF(@ProjectsCount >=3)
		THROW 50002, 'Employee already has 3 or more projects!',1;
	INSERT INTO EmployeesProjects (EmployeeID,ProjectID)
		VALUES(@EmployeeId,@ProjectId);
GO

sp_InsertEmployeeForProject 2,1