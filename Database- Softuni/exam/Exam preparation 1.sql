--1
CREATE DATABASE Airport
USE Airport

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
	)


CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)


CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NVARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price Decimal(10,2) NOT NULL
)

DROP TABLE Tickets
DROP TABLE Luggages
DROP TABLE LuggagesTypes


--2
	INSERT INTO Planes([Name],Seats,[Range])
		VALUES
				('Airbus 336',112,5132),
				('Airbus 330',432,5325),
				('Boeing 369',231,2355),
				('Stelt 297',254,2143),
				('Boeing 338',165,5111),
				('Airbus 558',387,1342),
				('Boeing 128',345,5541)

	INSERT INTO LuggageTypes([Type])
		VALUES
				('Crossbody Bag'),
				('School Backpack'),
				('Shoulder Bag')

--3
SELECT Id FROM Tickets
	WHERE FlightId=30

SELECT Id FROM Flights
	WHERE Destination='Ayn Halagim';

Update Tickets
	SET Price*=1.13
	WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination='Carlsbad')
--or
UPDATE Tickets
SET Price+=Price*0.13 FROM Tickets AS t
JOIN Flights AS f ON t.FlightId=f.Id
	WHERE f.Destination='Carlsbad'

--4
USE AIRPORT

DELETE FROM Tickets
	WHERE FlightId IN (
						SELECT Id FROM Flights
							WHERE Destination='Ayn Halagim'
						)

DELETE FROM Flights
	WHERE Destination='Ayn Halagim'

--5
SELECT * FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id ASC, [Name] ASC, Range ASC

--6
SELECT FlightId,SUM(Price) AS PRICE FROM Tickets AS t
	GROUP BY FlightId
	ORDER BY Price DESC, FlightId ASC

--7
SELECT p.FirstName+' '+p.LastName AS FullName,
		f.Origin,
		f.Destination 
		FROM Passengers AS p
	JOIN Tickets AS t ON p.Id=t.PassengerId
	JOIN Flights As f ON f.Id=t.flightId
	ORDER BY FirstName ASC,f.Origin ASC, f.Destination ASC

--8
SELECT p.FirstName,p.LastName,p.Age FROM Passengers AS p
	LEFT JOIN Tickets AS t ON p.Id=t.PassengerId
	WHERE t.PassengerId IS NULL
	ORDER BY p.Age DESC,p.FirstName ASC, p.LastName

--9
SELECT  p.FirstName+' '+p.LastName AS [Full Name],
		pl.[Name] AS [Plane Name],
		f.Origin+' - '+f.Destination AS Trip,
		lt.[Type] AS [Luggage Type]
	FROM Passengers AS p
	JOIN Tickets AS t ON p.Id=t.PassengerId
	JOIN Flights AS f ON f.Id=t.FlightId
	JOIN Planes AS pl ON pl.Id=f.PlaneId
	JOIN Luggages AS l ON l.Id=t.LuggageId
	JOIN LuggageTypes AS lt ON lt.Id=l.LuggageTypeId
	ORDER BY [Full Name] ASC,pl.[Name] ASC, f.Origin ASC, f.Destination ASC, lt.[Type] ASC

SELECT * FROM Tickets
SELECT * FROM Planes
SELECT * FROM Flights
SELECT * FROM Luggages
SELECT * FROM LuggageTypes

--10
SELECT p.[Name],p.[Seats],COUNT(t.PassengerId) AS [Passenger Count] FROM Planes AS p
	LEFT JOIN Flights AS f ON p.Id=f.PlaneId
	LEFT JOIN Tickets AS t ON t.flightId=f.Id
	GROUP BY p.[Name],p.Seats
	ORDER BY [Passenger Count] DESC,p.[Name] ASC, Seats ASC

--11
Go

CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(30)
AS
	BEGIN
		if(@peopleCount<=0)
			RETURN 'Invalid people count!'

		DECLARE @flightId INT= ( 
									SELECT TOP(1) Id FROM Flights
									WHERE Origin=@Origin AND Destination=@Destination
								);
		if(@flightId IS NULL)
			RETURN 'Invalid flight!';
		
		DECLARE @pricePerTicket DECIMAL(15,2)=(
													SELECT TOP(1) PRICE FROM Tickets
														WHERE FlightId=@FlightId
												);
		DECLARE @totalPrice DECIMAL(24,2)=@pricePerTicket*@peopleCount

		return CONCAT('Total price ', @totalPrice)
	END
Go

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
--1947
--12

CREATE OR ALTER PROCEDURE usp_CancelFlights
AS
	BEGIN
		UPDATE Flights
		SET DepartureTime=NULL, ArrivalTime=NULL
		WHERE DATEDIFF(SECOND,ArrivalTime,DepartureTime)<0
	END
GO

