CREATE DATABASE Bitbucket
USE Bitbucket

--1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)	

CREATE TABLE RepositoriesContributors(
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL

	CONSTRAINT PK_RepId PRIMARY KEY (RepositoryId,ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(20,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id)
)

--2
INSERT INTO Files(Name,Size,ParentId,CommitId)
	VALUES
			('Trade.idk',	2598.0,	1,	1),
			('menu.net'	,9238.31,	2,	2),
			('Administrate.soshy',	1246.93,	3,	3),
			('Controller.php',	7353.15,	4,	4),
			('Find.java'  ,9957.86,	5,	5),
			('Controller.json',	14034.87,	3,	6),
			('Operate.xix'	,7662.92,	7,	7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId)
	VALUES
			('Critical Problem with HomeController.cs file',	'open',	1	,4),
			('Typo fix in Judge.html','open',	4,	3),
			('Implement documentation for UsersService.cs',	'closed'	,8,	2),
			('Unreachable code in Index.cs',	'open',	9	,8)


--3
UPDATE Issues
SET IssueStatus='Closed'
WHERE AssigneeId=6

--4
DELETE FROM RepositoriesContributors
 WHERE RepositoryId = 3

 DELETE FROM Issues
 WHERE RepositoryId = 3

--5
SELECT id,Message,RepositoryId,ContributorId FROM Commits
	ORDER BY Id,Message,RepositoryId,ContributorId

--6
SELECT id,Name,Size FROM Files
	WHERE Size>1000 AND Name LIKE '%html%'
	ORDER BY Size DESC,id,Name

--7
SELECT i.Id,u.Username+' : '+i.Title AS IssueAssignee FROM Issues AS i
	JOIN Users As u ON u.Id=i.AssigneeId
	ORDER BY i.Id DESC,i.AssigneeId

--8 
SELECT id,Name,(CONVERT(VARCHAR,Size)+'KB') FROM Files
	WHERE id NOT IN (SELECT DISTINCT ParentId FROM Files WHERE ParentId IS NOT NULL)
	ORDER BY id,Name,Size DESC

--9
SELECT TOP(5) r.Id, r.Name, COUNT(*) AS Commits FROM Commits AS c
JOIN Repositories AS r ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY COUNT(*) DESC, r.Id, r.Name

--10
SELECT u.Username,AVG(f.Size) AS Size FROM Users AS u
	JOIN Commits AS c ON c.ContributorId=u.Id
	JOIN Files AS f ON f.CommitId=c.Id
	GROUP BY u.Id,u.Username
	ORDER BY AVG(f.Size) DESC,u.Username

--11
SELECT COUNT(*) FROM Commits AS c
	JOIN Users AS u ON u.Id=c.ContributorId
	WHERE u.Username='UnderSinduxrein'

GO
CREATE OR ALTER FUNCTION udf_UserTotalCommits(@username VARCHAR(50)) 
RETURNS INT
AS
	BEGIN
		DECLARE @totalCommits INT= (SELECT COUNT(*) FROM Commits AS c
										JOIN Users AS u ON u.Id=c.ContributorId
										WHERE u.Username=@username)
		RETURN @totalCommits
	END
GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

--12
GO
CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(10))
AS
	BEGIN
		SELECT id,Name,CONCAT(Size,'KB') FROM Files
			WHERE Files.[Name] LIKE ('%'+@extension+'%')
	END
GO

EXEC usp_FindByExtension 'txt'