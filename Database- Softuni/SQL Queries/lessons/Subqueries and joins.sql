Use SoftUni

--simple join
SELECT * FROM Addresses	
	JOIN Towns ON Addresses.TownId=Towns.TownID

--inner join
SELECT Addresses.AddressText,Towns.Name FROM Addresses	
	JOIN Towns ON Addresses.TownId=Towns.TownID

--left join possible to have null same for right
SELECT * FROM Addresses	
	LEFT JOIN Towns ON Addresses.TownId=Towns.TownID

--full outer join
SELECT * FROM Addresses	
	FULL OUTER JOIN Towns ON Addresses.TownId=Towns.TownID

--cross join vseki po vseki
SELECT * FROM Addresses 
	CROSS JOIN Towns

--join and criteria
SELECT * FROM Addresses	AS a
	JOIN Towns AS t ON a.TownId=t.TownID AND a.AddressText LIKE '%Av%'

--multible tables
SELECT * FROM Employees As e	
	JOIN Addresses AS a ON e.AddressID=a.AddressID
	LEFT JOIN Towns t ON a.TownID=t.TownID

--join three tables
SELECT TOP(50) e.FirstName,e.LastName,t.Name,a.AddressText FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID=a.AddressID
	JOIN Towns AS t ON t.TownID=a.TownID
	ORDER BY e.FirstName ASC, LastName

-- join by machting name
SELECT EmployeeID,FirstName,LastName, [Name] AS DepartmentName FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
	WHERE d.Name='Sales'
	ORDER BY e.EmployeeID

--
SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS DeptName FROM Employees AS e
	JOIN Departments d ON e.DepartmentID=d.DepartmentID
	WHERE HireDate>'1999-01-01' AND (d.Name='Sales' OR d.Name='Finance')
	ORDER BY HireDate ASC

--
SELECT TOP(50) 
		e.EmployeeID, 
		e.FirstName+' '+e.LastName AS EmployeeName,
		m.FirstName+' '+m.LastName AS ManagerName,
		d.Name AS DepartmentName
		FROM Employees AS e
	LEFT JOIN Employees AS m ON e.ManagerID=m.EmployeeID
	LEFT JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
	ORDER BY e.EmployeeID

--subqueries
SELECT e.FirstName, e.LastName, e.HireDate,
	(SELECT COUNT(*) FROM Employees AS e2 WHERE e2.FirstName=e.FirstName) AS CountSameNames
	FROM Employees AS e
	ORDER BY CountSameNames DESC

--avr salary by crews
SELECT *, (SELECT AVG(Salary) FROM Employees AS e WHERE e.DepartmentID=d.departmentID) AS AverageSalary 
	FROM Departments AS d
	WHERE (SELECT COUNT(*) FROM Employees AS e WHERE e.DepartmentID=d.DepartmentID)>10
		ORDER BY AverageSalary

--group by
SELECT DepartmentID,Count(*) AS Count,MIN(Salary) AS MinSalary FROM Employees
	GROUP BY DepartmentID

SELECT DepartmentID,string_agg(FirstName,' ') AS NamesInDeparment FROM Employees
	GROUP BY DepartmentID