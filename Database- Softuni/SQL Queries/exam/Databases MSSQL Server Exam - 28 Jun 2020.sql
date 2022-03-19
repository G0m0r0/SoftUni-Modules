CREATE DATABASE ColonialJourney
USE ColonialJourney

CREATE TABLE Planets(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
)

CREATE TABLE SpacePorts(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PlanetId INT REFERENCES Planets(Id) NOT NULL,
)

CREATE TABLE SpaceShips(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0,
)

CREATE TABLE Colonists(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) UNIQUE NOT NULL,
BirthDate DateTime NOT NULL,
)

Create TABLE Journeys(
Id INT PRIMARY KEY IDENTITY,
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11), /*DEFAULT 'Medical'; 'Technical', 'Educational', 'Military',*/
DestinationSpaceportId INT REFERENCES Spaceports NOT NULL,
SpaceShipId INT REFERENCES Spaceships NOT NULL,
)

CREATE TABLE TravelCards(
Id INT PRIMARY KEY IDENTITY,
CardNumber VARCHAR(10) UNIQUE NOT NULL,
JobDuringJourney VARCHAR(8), /*“Pilot”, “Engineer”, “Trooper”, “Cleaner”, “Cook”.*/
ColonistId INT REFERENCES Colonists NOT NULL,
JourneyId INT REFERENCES Journeys NOT NULL,
)

--2
INSERT INTO Planets(Name)
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO SpaceShips(Name,Manufacturer,LightSpeedRate)
VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('bed','Vidolov',6)

SELECT * FROM SpaceShips
SELECT * FROM TravelCards
SELECT * FROM Journeys

--3
UPDATE SpaceShips
Set LightSpeedRate+=1
Where Id BETWEEN 8 AND 12

--4
DELETE FROM TravelCards
Where JourneyId<=3

DELETE Journeys
Where Id<=3

--5
SELECT Id,FORMAT (JourneyStart, 'dd/MM/yyyy') as JourneyStart ,FORMAT (JourneyEnd, 'dd/MM/yyyy') as JourneyEnd FROM Journeys
WHERE Purpose='Military'
ORDER BY JourneyStart ASC

--6
SELECT c.Id AS id,c.FirstName+' '+c.LastName AS full_name FROM Colonists AS c
JOIN TravelCards On c.Id=TravelCards.ColonistId
WHERE JobDuringJourney='Pilot'
ORDER BY c.Id ASC

--7
SELECT COUNT(c.Id) AS count FROM Colonists AS c
JOIN TravelCards On c.Id=TravelCards.ColonistId
JOIN Journeys ON TravelCards.JourneyId=Journeys.Id
WHERE Journeys.Purpose='Technical'

--8
SELECT  s.Name,s.Manufacturer FROM SpaceShips AS s
JOIN Journeys AS j ON  s.Id=j.SpaceShipId
JOIN TravelCards AS tc ON tc.JourneyId=j.Id
JOIN Colonists As col ON col.Id=tc.ColonistId
WHERE tc.JobDuringJourney='Pilot' 
AND YEAR(GETDATE()) - YEAR(col.BirthDate) <=30
ORDER BY s.Name ASC

--9
SELECT p.Name AS PlanetName,COUNT(j.Id) AS JourneysCount FROM Planets AS p
RIGHT JOIN SpacePorts AS sp ON sp.PlanetId=p.Id
RIGHT JOIN Journeys AS j ON j.SpaceShipId=sp.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC, PlanetName ASC

