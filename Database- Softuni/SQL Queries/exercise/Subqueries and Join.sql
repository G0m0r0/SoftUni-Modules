USE SoftUni
--1

SELECT TOP(5) EmployeeID,JobTitle,Addresses.AddressID,AddressText FROM Employees
	JOIN Addresses ON Addresses.AddressID=Employees.AddressID
	ORDER BY Addresses.AddressID ASC;

--2
SELECT TOP(50) e.FirstName,e.LastName,t.Name,a.AddressText FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID=e.AddressID
	JOIN Towns AS t ON a.TownID=t.TownID
	ORDER BY FirstName ASC,LastName ASC;

--3
SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
	WHERE d.Name='Sales'
	ORDER BY e.EmployeeID ASC;

--4
SELECT TOP(5) EmployeeID,FirstName,Salary,d.Name FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
	WHERE e.Salary>15000
	ORDER BY e.DepartmentID ASC

--5
SELECT TOP(3) e.EmployeeID,e.FirstName FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID ASC 

--if we want opposite right join

--6
SELECT FirstName,LastName,HireDate,d.Name AS DeptName FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
	WHERE YEAR(e.HireDate)>1999 AND (d.Name='Sales' OR d.Name='Finance')
	ORDER BY HireDate ASC

--7
SELECT * FROM Projects

SELECT TOP(5) e.EmployeeID,FirstName,p.Name FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
	JOIN Projects AS p ON p.ProjectID=ep.ProjectID
	WHERE p.StartDate>'08-13-2002' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID ASC; 

--8
SELECT e.EmployeeID,e.FirstName,(
		CASE 
			WHEN YEAR(p.StartDate)>=2005 THEN NULL
			ELSE P.Name
			END
		)AS ProjectName FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
	JOIN Projects AS p ON p.ProjectID=ep.ProjectID
	WHERE e.EmployeeID=24

--9
SELECT * FROM Employees
SELECT e.EmployeeID,e.FirstName,e.ManagerID,em.FirstName FROM Employees AS e
	JOIN Employees As em ON e.ManagerID=em.EmployeeID
	Where e.ManagerID=3 OR e.ManagerID=7
	ORDER BY e.EmployeeID ASC

--10
SELECT TOP(50) e1.EmployeeID,
		e1.FirstName+' '+e1.LastName AS EmployeeName,
		(e2.FirstName+' '+e2.LastName) AS ManagerName,
		d.Name AS DepartmentName
	FROM Employees AS e1
	LEFT JOIN Employees As e2 ON e1.ManagerID=e2.EmployeeID
	JOIN Departments AS d ON e1.DepartmentID=d.DepartmentID
	ORDER BY e1.EmployeeID ASC
	
--11
SELECT MIN([Average Salary])AS [MinAverageSalary] FROM
	(SELECT DepartmentID, AVG(Salary) AS [Average Salary] FROM Employees
		GROUP BY DepartmentID) AS [AverageSalaryQuery]

--12
USE Geography
SELECT * FROM Countries
	ORDER BY CountryCode
SELECT * FROM Mountains
SELECT * FROM Peaks

SELECT c.CountryCode,MountainRange,PeakName,p.Elevation FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId=m.Id
	JOIN MountainsCountries AS mc ON mc.MountainId=p.MountainId
	JOIN Countries AS c ON mc.CountryCode=c.CountryCode
	WHERE c.CountryCode='BG' AND p.Elevation>2835
	ORDER BY p.Elevation DESC

--13

USE Geography

SELECT CountryCode,Count(MountainId) AS MountainRanges FROM MountainsCountries	
	WHERE CountryCode IN ('US','RU','BG')
	GROUP BY CountryCode;

SELECT * FROM MountainsCountries

--14
SELECT TOP(5) CountryName,RiverName FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id=cr.RiverId
	WHERE c.ContinentCode='AF'
	ORDER BY c.CountryName ASC

--15
SELECT ContinentCode,CurrencyCode,CurrencyCount AS CurrencyUsage FROM (
			SELECT ContinentCode,CurrencyCode,CurrencyCount,
				DENSE_RANK() OVER (Partition by ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
			FROM (
				SELECT ContinentCode,
					CurrencyCode,
					Count(*)
					AS [CurrencyCount] FROM Countries
				GROUP BY ContinentCode,CurrencyCode) AS CurrencyCount
			WHERE CurrencyCount>1) AS CurrencyRankingQuery
		WHERE CurrencyRank=1
		ORDER BY ContinentCode

--16
SELECT COUNT(*) AS [Count] FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE mc.MountainId IS NULL

--17
SELECT TOP(5) cm.CountryName, cm.HighestPeakElevation, cr.LongestRiverLength 
FROM (SELECT c.CountryName, Max(p.Elevation) AS HighestPeakElevation 
      FROM Countries AS c
      LEFT JOIN MountainsCountries AS mc On mc.CountryCode = c.CountryCode
      LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
      LEFT JOIN Peaks AS p ON p.MountainId = m.Id
      GROUP BY c.CountryName) AS cm
JOIN (SELECT c.CountryName, Max(r.[Length]) AS LongestRiverLength
      FROM Countries AS c
      LEFT JOIN CountriesRivers AS cr On cr.CountryCode = c.CountryCode
      LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
      GROUP BY c.CountryName) AS cr ON cm.CountryName = cr.CountryName
ORDER BY cm.HighestPeakElevation DESC, cr.LongestRiverLength DESC

--18

SELECT  mount.CountryName, mount.MountainRange, p.PeakName, MAX(p.Elevation) AS Elevation
INTO #TemtTable
FROM (SELECT c.CountryName, m.MountainRange, m.Id
               FROM Countries AS c
               LEFT JOIN MountainsCountries AS mc On mc.CountryCode = c.CountryCode
               LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
               GROUP BY c.CountryName, m.MountainRange, m.Id) AS mount
LEFT JOIN Peaks AS p ON p.MountainId = mount.Id
GROUP BY mount.CountryName, mount.MountainRange, p.PeakName

SELECT TOP(5) 
        CountryName AS Country, 
        ISNULL(PeakName, '(no highest peak)' ) AS [Highest Peak Name],
		ISNULL(Elevation, 0) AS  [Highest Peak Elevation],  
		ISNULL(MountainRange, '(no mountain)') AS Mountain 
FROM (SELECT CountryName, MountainRange, PeakName, Elevation,
      DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
      FROM #TemtTable) AS t
WHERE [Rank] = 1

