USE SoftUni

--its used for many records!!

--create index
Create NONCLUSTERED INDEX
IX_Employees_FirstName_LastName
ON Employees(FirstName, LastName)

--clean hard disck
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--drop index
DROP INDEX IX_Employees_FirstName_LastName

--group by
SELECT DepartmentID, Count(*) FROM Employees
	GROUP BY DepartmentID

--min 
SELECT MIN(Salary) FROM Employees
	
--min by deparment
SELECT MIN(Salary) FROM Employees
	GROUP BY DepartmentID

--multiple groups
SELECT DepartmentID,FirstName, COUNT(*) FROM Employees
	GROUP BY DepartmentID, FirstName

--group by and aggragate
SELECT DepartmentID, COUNT(*) AS [Count],MIN(Salary), STRING_AGG(FirstName,' ') FROM Employees
	GROUP BY DepartmentID
	ORDER BY [Count] DESC

--having
SELECT DepartmentID, Count(*) FROM Employees
	Where Salary> 10000
	GROUP BY DepartmentID
	HAVING Count(*) >10
