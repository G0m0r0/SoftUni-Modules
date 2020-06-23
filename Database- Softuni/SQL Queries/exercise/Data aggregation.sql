USE Gringotts
	
--1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits
	
--2
SELECT MAX(MagicWandSize) AS [LongestMagicWand]FROM WizzardDeposits

--3
SELECT * FROM WizzardDeposits
	ORDER BY MagicWandSize

SELECT DepositGroup,MAX(MagicWandSize) FROM WizzardDeposits
	GROUP BY DepositGroup

--4
SELECT * FROM WizzardDeposits

SELECT TOP(2) DepositGroup FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize) ASC
	
--5
SELECT DepositGroup,SUM(DepositAmount) FROM WizzardDeposits
	GROUP BY DepositGroup

--6
SELECT DepositGroup,SUM(DepositAmount) FROM WizzardDeposits
	WHERE MagicWandCreator='Ollivander family'
	GROUP BY DepositGroup

--7
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
	WHERE MagicWandCreator='Ollivander family' 
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount)<150000
	ORDER BY TotalSum DESC

--8
SELECT DepositGroup, MagicWandCreator,MIN(DepositCharge) FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
	ORDER BY MagicWandCreator ASC, DepositGroup ASC

--9
SELECT new.AgeGroup,COUNT(*) FROM (SELECT 
					CASE 
						WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
						WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
						WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
						WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
						WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
						WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
						WHEN Age > 60 THEN '[61+]'
						END AS AgeGroup
					FROM WizzardDeposits) AS new
	GROUP BY new.AgeGroup

--10


SELECT * FROM (SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter FROM WizzardDeposits
               WHERE DepositGroup = 'Troll Chest') AS t
GROUP BY FirstLetter
ORDER BY FirstLetter

--11
USE Gringotts

SELECT DepositGroup, IsDepositExpired,AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits
	WHERE DepositStartDate>'01-01-1985'
	GROUP BY DepositGroup,IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12
SELECT SUM(new.[Difference]) AS SumDifference FROM( SELECT FirstName As [Host Wizard], 
       DepositAmount AS [Host Wizard Deposit],
	   LEAD(FirstName) OVER(ORDER BY id DESC) AS [Guest Wizzard],
	   LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
	   DepositAmount- LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	   FROM WizzardDeposits) AS new
	   WHERE [Guest Wizzard] IS NOT NULL

--13
USE SoftUni

SELECT DepartmentID,SUM(Salary) AS TotalSalary FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--14
SELECT DepartmentID,MIN(Salary) FROM Employees
	WHERE DepartmentID IN (2,5,7) AND HireDate>'01-01-2000'
	GROUP BY DepartmentID

--15
SELECT * INTO EmployeesWithHighSalaries FROM Employees
	WHERE Salary>30000 

--SELECT * FROM EmployeesWithHighSalaries
	
DELETE FROM EmployeesWithHighSalaries
	WHERE ManagerID=42

UPDATE EmployeesWithHighSalaries
	SET Salary+=5000
	WHERE DepartmentID=1

SELECT DepartmentID,AVG(Salary) AS AverageSalary FROM EmployeesWithHighSalaries
	GROUP BY DepartmentID

--16
SELECT DepartmentID,MAX(Salary) AS MaxSalary FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary)<30000 OR MAX(Salary)>70000

--17
SELECT COUNT(*) FROM Employees
	WHERE ManagerID IS NULL

--18
SELECT DepartmentID,Salary AS [ThirdHighestSalary] FROM (SELECT DepartmentID,
       Salary,
	DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [SalaryRank]
	FROM Employees
	GROUP BY DepartmentID,Salary
	) AS SalaryRankedQuery
WHERE SalaryRank=3

--or distinct for departmentid

--19
SELECT TOP(10) FirstName,LastName,DepartmentID FROM Employees AS e1
	WHERE e1.Salary > (
							SELECT AVG(Salary) AS AVGSalary 
							FROM Employees AS e2
							WHERE e2.DepartmentID=e1.DepartmentID
							GROUP BY DepartmentID
						)
		ORDER BY DepartmentID ASC

