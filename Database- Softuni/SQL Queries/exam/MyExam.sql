CREATE DATABASE TripService
USE TripService
--1


CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(20,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(20,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)	

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	BookDate DATETIME2 NOT NULL,
	ArrivalDate DATETIME2 NOT NULL,
	ReturnDate DATETIME2 NOT NULL,
	CancelDate DATETIME2
)

ALTER TABLE Trips
ADD CHECK(BookDate<ArrivalDate)

ALTER TABLE Trips
ADD CHECK(ArrivalDate<Trips.ReturnDate)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATETIME2 NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id),
	Luggage INT NOT NULL CHECK(Luggage>=0)

	CONSTRAINT PK_RepCon PRIMARY KEY (AccountId,TripId)
)	


--2
INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email)
	VALUES
			('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),  
			('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
			('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
			('Friedrich',	'Wilhelm',	'Nietzsche',	2	,'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate)
		VALUES
				(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
				(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
				(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL	  ),
				(104,	'2012-03-17',   '2012-03-31',	'2012-04-01',	'2012-01-10'),
				(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL	  )


--3
UPDATE Rooms
SET Price*=1.14
WHERE HotelId In (5,7,9)

--4
DELETE FROM AccountsTrips
Where AccountId=47

DELETE FROM Accounts
WHERE Id=47

--5
SELECT FirstName,LastName,FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,c.Name,Email FROM Accounts AS a
	JOIN Cities AS c ON c.Id=a.CityId
	WHERE LEFT(Email,1)='e'
	ORDER BY c.Name

--6
SELECT c.Name,COUNT(h.Id) AS Hotels FROM Cities AS c
	JOIN Hotels As h ON h.CityId=c.Id
	GROUP BY c.Id,c.Name
	ORDER BY Hotels DESC,c.Name --may be DESC

--7 not
SELECT a.Id AS AccountId,
	   a.FirstName+' '+a.LastName AS FullName,
	   MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
		FROM Accounts As a
	JOIN AccountsTrips AS act ON act.AccountId=a.Id
	JOIN Trips AS t ON t.Id=act.TripId
	WHERE t.CancelDate IS NOT NULL
	GROUP BY a.Id,a.FirstName,a.LastName
	ORDER BY LongestTrip DESC,ShortestTrip

--or
SELECT Id,
 FullName,
 MAX([TripDays]) AS [LongestTrip],
 MIN([TripDays]) as [ShortestTrip]
    FROM (
        SELECT a.Id,
                (a.FirstName + ' '+ LastName) AS [FullName],
                DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate) AS [TripDays]
            FROM Trips t
             RIGHT JOIN AccountsTrips act
            ON act.TripId = t.Id
             JOIN Accounts a
            ON a.Id = act.AccountId
            WHERE a.MiddleName IS  NULL AND t.CancelDate IS NULL
    ) as [k]
    GROUP BY Id, FullName
    ORDER BY LongestTrip DESC, ShortestTrip ASC
--8
SELECT TOP(10) c.Id,c.Name,c.CountryCode,COUNT(a.Id) AS Accounts FROM Cities AS c
	JOIN Accounts As a ON a.CityId=c.Id
	GROUP BY c.Id,c.Name,c.CountryCode
	ORDER BY Accounts DESC

--9
SELECT a.Id,
		a.Email,
		(SELECT TOP(1) Name FROM Cities WHERE id=a.CityId) AS City,
		Count(t.Id) AS Trips
		FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId=a.Id
	JOIN Trips As t ON t.Id=act.TripId
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	WHERE a.CityId=h.CityId
	GROUP BY a.Id,a.Email,a.CityId
	ORDER BY Trips DESC,a.Id --maybe DESC

SELECT a.Id,
		a.Email,
		(SELECT TOP(1) Name FROM Cities WHERE id=a.CityId) AS City,
		Count(t.Id) AS Trips
		FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId=a.Id
	JOIN Trips As t ON t.Id=act.TripId
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId

--10
SELECT DISTINCT t.Id,
		CASE
			WHEN MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
			ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) 
		END AS [Full Name],
		c2.Name AS [From],
		c.Name AS [TO],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CAST(DATEDIFF(Day,t.ArrivalDate,t.ReturnDate) AS NVARCHAR(50))+ ' days'
			END AS Duration
		FROM Trips AS t
	JOIN AccountsTrips AS [at] ON [at].TripId=t.Id
	JOIN Accounts AS a ON a.Id=[at].AccountId
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=h.CityId
	JOIN Cities As c2 ON c2.Id=a.CityId
	ORDER BY [Full Name],t.Id



--7
SELECT Id,
 FullName,
 MAX(TripDays) AS LongestTrip,
 MIN(TripDays) AS ShortestTrip
    FROM (
        SELECT a.Id,
                (a.FirstName + ' '+ LastName) AS FullName,
                DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate) AS TripDays
            FROM Trips t
             RIGHT JOIN AccountsTrips act ON act.TripId = t.Id
             JOIN Accounts a ON a.Id = act.AccountId
            WHERE a.MiddleName IS  NULL AND t.CancelDate IS NULL
    ) AS query
    GROUP BY Id, FullName
    ORDER BY LongestTrip DESC, ShortestTrip ASC

SELECT Id,
 FullName,
 MAX([TripDays]) AS [LongestTrip],
 MIN([TripDays]) as [ShortestTrip]
    FROM (
        SELECT a.Id,
                (a.FirstName + ' '+ LastName) AS [FullName],
                DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate) AS [TripDays]
            FROM Trips t
             RIGHT JOIN AccountsTrips act
            ON act.TripId = t.Id
             JOIN Accounts a
            ON a.Id = act.AccountId
            WHERE a.MiddleName IS  NULL AND t.CancelDate IS NULL
    ) as [k]
    GROUP BY Id, FullName
    ORDER BY LongestTrip DESC, ShortestTrip ASC




