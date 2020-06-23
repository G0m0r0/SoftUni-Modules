--towns with length of there names
SELECT [Name],LEN([Name]) AS [Length of name],LEFT([Name],1) FROM SoftUni.dbo.Towns
	WHERE LEFT([Name],1)='S'
--	WHERE [Name]='Sofia'
--townId and name
SELECT TownId, [Name] FROM Towns

SELECT GETDATE()

--JOIN
SELECT AddressText,[Name] FROM [Addresses]
	JOIN Towns ON Addresses.TownID=Towns.TownID

--Concatenation
SELECT FirstName + ' '+LastName 
		AS FullName,JobTitle,Salary 
		FROM Employees
		ORDER BY Salary ASC

--SELECT unique
SELECT DISTINCT JobTitle FROM Employees

--SELECT count of unique job title
SELECT COUNT(DISTINCT JobTitle)
	FROM Employees

--SELECT unique job title with max , min salary and count of employees
SELECT JobTitle, MAX(Salary),MIN(Salary),Count(*) FROM Employees GROUP BY JobTitle

--> < = != <= >= NOT
SELECT * FROM Employees WHERE Salary>=40000

--operators OR AND BETWEEN
SELECT * FROM Employees 
WHERE Salary<=40000 AND Salary>=2000 AND JobTitle='Production Technician'

--ending name with ris
SELECT * FROM Employees
	WHERE FirstName LIKE '%ris'

--starting name with pet
SELECT * FROM Employees
	WHERE FirstName LIKE 'pet%'

-- contrains
SELECT * FROM Employees
	WHERE FirstName LIKE '%pet%'

--search
SELECT * FROM Employees
	WHERE FirstName LIKE '%e%t%e%'

 -- search by criteria
 SELECT * FROM Employees
	WHERE Salary IN (10000,20000,30000,50000)

SELECT * FROM Employees 
	WHERE DepartmentID IN (3,6,9)

--check if not null and empty
SELECT * FROM Employees 
	WHERE MiddleName IS NOT NULL AND MiddleName !=' '

--sort by two criterias 
SELECT * FROM Employees 
	ORDER BY Salary DESC, LastName ASC

--select by date
SELECT * FROM Employees 
	WHERE HireDate>='2000-01-01'

--select by month	DAY YEAR DATEPART DATENAME()
SELECT * FROM Employees 
		WHERE MONTH(HireDate)=1

--create view	
CREATE VIEW v_GetHireDateAndDayOfWeek AS
	SELECT HireDate, DATENAME(dw,HireDate) AS [DayOfWeek]
	FROM Employees

--take from views
SELECT * FROM [v_GetHireDateAndDayOfWeek]