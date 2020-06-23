--1
USE SoftUni

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	BEGIN
		SELECT FirstName,LastName FROM Employees
			WHERE Salary>35000
	END
GO

EXECUTE usp_GetEmployeesSalaryAbove35000

--2
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
	BEGIN
		SELECT FirstName,LastName FROM Employees
			WHERE Salary>=@number
	END

EXECUTE usp_GetEmployeesSalaryAboveNumber 35000

--3
CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith(@str VARCHAR(50))
AS
	BEGIN
		SELECT [Name] FROM Towns
			WHERE [Name] LIKE (@str+'%')
	END

EXECUTE [dbo].[usp_GetTownsStartingWith] b

--4
USE SoftUni

CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
	BEGIN
		SELECT FirstName,LastName FROM Employees AS e
			JOIN Addresses AS a ON e.AddressID=a.AddressID
			JOIN Towns AS t ON a.TownID=t.TownID
			WHERE t.Name=@TownName
	END


EXECUTE [dbo].[usp_GetEmployeesFromTown] Sofia

--5
GO

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS VARCHAR(7) 
	AS
		BEGIN
			IF(@Salary<30000) RETURN 'Low'
			ELSE IF(@Salary<=50000) RETURN 'Average'
			ELSE RETURN 'High'
			
			RETURN 'Error'
		END

SELECT Salary,[dbo].[ufn_GetSalaryLevel](Salary) AS SalaryLevel FROM Employees


--or

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS VARCHAR(7) 
	AS
		BEGIN
			DECLARE @salaryLevel VARCHAR(7);

			IF(@Salary<30000) 
				SET @salaryLevel='Low'
			ELSE IF(@Salary<=50000) 
				SET @salaryLevel='Average'
			ELSE 
				SET @salaryLevel='High'
			
			RETURN @salaryLevel;
		END

GO
SELECT Salary,[dbo].[ufn_GetSalaryLevel](Salary) As SalaryLevel FROM Employees

--6
GO

CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(7))
AS
	BEGIN
		SELECT FirstName,LastName FROM Employees
			WHERE [dbo].[ufn_GetSalaryLevel](Salary)=@LevelOfSalary
	END

EXECUTE [dbo].[usp_EmployeesBySalaryLevel] 'High'


--7

USE SoftUni
GO 

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(100), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @Size INT = LEN(@word);
	DECLARE @Counter INT = 1;

	WHILE(@Size >=  @Counter)
			BEGIN
				DECLARE @CurentChar VARCHAR(1)= SUBSTRING(@word,@Counter ,1)
				IF( CHARINDEX(@CurentChar,@setOfLetters)=0)
					RETURN 0;

				SET @Counter += 1
			END
	RETURN 1
END 

GO 

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','Sofia')

--8
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
AS
	BEGIN
		--all ids which are going to be deleted
		--SELECT EmployeeID FROM Employees
		--WHERE DepartmentID=@DepartmentId

		--delete all records from employeesprojects
		DELETE FROM EmployeesProjects
		Where EmployeeID IN
			(
			SELECT EmployeeID FROM Employees
			WHERE DepartmentID=@DepartmentId
			)

		--set manager id to null
		UPDATE Employees
		SET ManagerID=NULL
		WHERE ManagerID IN
			(
			SELECT EmployeeID FROM Employees
			WHERE DepartmentID=@DepartmentId
			)

		--alter coloumn managerid to allow null
		ALTER TABLE Departments
		ALTER COLUMN ManagerID INT

		--set managerid to null where manager is an employee which will be deleted
		UPDATE Departments
		SET ManagerID=NULL
		WHERE ManagerID IN(SELECT EmployeeID FROM Employees
			WHERE DepartmentID=@DepartmentId)

		--delete all employees
		DELETE FROM Employees
		WHERE DepartmentID=@DepartmentId

		DELETE FROM Departments
		WHERE DepartmentID=@DepartmentId

		SELECT COUNT(*) FROM Employees
		WHERE DepartmentID=@DepartmentId
	END

EXEC usp_DeleteEmployeesFromDepartment 1

--9
USE Bank

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName 
AS
	BEGIN
		SELECT CONCAT(FirstName,' ',LastName) AS [Full Name] FROM AccountHolders
	END


EXECUTE [dbo].[usp_GetHoldersFullName]

--10
GO

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@num DECIMAL(18,4))
AS
	BEGIN
		SELECT FirstName,LastName FROM Accounts AS a
		JOIN AccountHolders AS ah ON a.AccountHolderId=ah.Id
		GROUP BY ah.ID,FirstName,LastName
		HAVING SUM(Balance)>@num
		ORDER BY FirstName,LastName
	END


EXECUTE usp_GetHoldersWithBalanceHigherThan 25000

--11
GO 

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue 
               (@sum DECIMAL (20, 4), @yearlyInterestRate FLOAT, @numberOfYears int)
RETURNS DECIMAL(20,4)
AS
BEGIN
	DECLARE @Result DECIMAL(20,4);

	SET @Result = @sum * POWER((1 + @yearlyInterestRate), @numberOfYears); 

	RETURN @Result;
END;

GO

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)
