Use SoftUni

--1
SELECT FirstName,LastName FROM Employees
	WHERE FirstName LIKE 'SA%'

--2
SELECT FirstName,LastName FROM Employees	
	WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM Employees
	Where DepartmentID=3 OR DepartmentID=10 AND (YEAR(HireDate) BETWEEN 1995 AND 2005)

--4
SELECT FirstName, LastName FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

SELECT * FROM Employees

--5
SELECT * FROM Towns ORDER BY [Name]

SELECT [Name] FROM Towns
	WHERE LEN([Name])=5 OR LEN([Name])=6
	ORDER BY [Name] ASC

--or WHERE LEN([Name]) IN (5,6)

--6
USE SoftUni
SELECT * FROM Towns
	WHERE [Name] LIKE '[MKBE]%' 
	ORDER BY [Name] ASC

--or wildcart
--WHERE LEFT([Name],1) IN ('M','K','B','E')
-- WHERE SUBSTRING([Name],1,1) IN ('M','K','B','E')
--7
SELECT * FROM Towns
	WHERE [Name] LIKE '[^R,^B,^D]%'
	ORDER BY [Name] ASC

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName,LastName From Employees 
	WHERE YEAR(HireDate)>2000

SELECT * FROM V_EmployeesHiredAfter2000

--9
SELECT FirstName,LastName FROM Employees
	WHERE LEN(LastName)=5

--10
SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
		ORDER BY Salary DESC

--11
SELECT * FROM  (SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS [Rank Table]
	WHERE [RANK]=2
	ORDER BY Salary DESC
--12
USE Geography
SELECT CountryName,IsoCode FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode ASC
--13
--not suitable for JOIN
--SELECT p.PeakName,r.RiverName FROM Peaks AS p, Rivers AS r
--	WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
SELECT p.PeakName,r.RiverName,LOWER(p.PeakName+SUBSTRING(r.RiverName,2,Len(r.RiverName)-1)) AS MIX FROM Peaks AS p, Rivers AS r
	WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
	ORDER BY MIX ASC

--or
SELECT p.PeakName, r.RiverName, Lower(CONCAT(p.PeakName,SUBSTRING(r.RiverName,2,LEN(r.RiverName)-1))) AS MIX
FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
ORDER BY [MIX] ASC
--14
USE Diablo
SELECT * FROM Games
	ORDER BY [Name]

USE Diablo
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games AS g
	WHERE YEAR([Start])=2011 OR YEAR([Start])=2012
	ORDER BY [Start],[Name]

--or
--WHERE DATEPART(YEAR,[Start]) IN (2011,20112)
--15
SELECT 
      Username, 
      SUBSTRING(Email,CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider] 
 FROM Users
 ORDER BY [Email Provider], Username

--16
USE Diablo

SELECT Username,IpAddress FROM Users
	WHERE IpAddress LIKE '___.1_%._%.___'
	ORDER BY Username
--wild carts '___.1_%._%.___'
--17

SELECT 
 [Name] AS Game,
 CASE 
     WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
     WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
     WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 24 THEN 'Evening'
 END AS [Parts of the day],
 CASE
     WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
     WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
     WHEN Duration > 6 THEN 'Long'
     ELSE 'Extra Long'
 END AS Duration
 FROM Games
 ORDER BY [Name], Duration, [Parts of the day]

--19
SELECT
   [Name],
   DATEDIFF(year, Birthdate, GETDATE()) AS  [Age in Years],
   DATEDIFF(month, Birthdate, GETDATE()) AS [Age in Months],
   DATEDIFF(day, Birthdate, GETDATE()) AS [Age in Days],
   DATEDIFF(minute, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People