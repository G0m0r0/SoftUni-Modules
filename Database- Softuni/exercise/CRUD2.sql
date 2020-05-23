--create view
USE Geography
CREATE VIEW v_HighestPeak AS
SELECT TOP (1)*  FROM [dbo].[Peaks]
	ORDER BY [Elevation] DESC

--insert new records
USE SoftUni
INSERT INTO Towns (Name)
	VALUES ('Paris'), ('BURGAS')
SELECT * FROM Towns 

--insert and change existing record
INSERT INTO Projects ([Name],[Description],StartDate)
	SELECT '[New]' + [Name],[Description],GETDATE()
	FROM [SoftUni].[dbo].[Projects]
	WHERE [Name] LIKE 'C%'


--take from one and insert in another table
SELECT FirstName+ ' '+LastName AS FullName, Salary	
	INTO Names
	FROM Employees

SELECT * FROM Names

--sequence
CREATE SEQUENCE seq_MyNumber
	AS INT
	START WITH 0
	INCREMENT BY 1001

SELECT NEXT VALUE FOR seq_MyNumber

--Deleting information by criteria
DELETE FROM Names
	WHERE FullName LIKE 'A%'

SELECT * FROM Names
--TRUNCATE
TRUNCATE TABLE Names

--UPDATE by given criteria
UPDATE Names 
	SET Salary=Salary+1000
	WHERE FullName LIKE 'A%'

-- set all records with null value to the current date
UPDATE [dbo].[Projects]
	SET EndDate=GETDATE()
	WHERE [EndDate] IS NULL