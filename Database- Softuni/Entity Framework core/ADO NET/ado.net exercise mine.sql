CREATE DATABASE MinionsDB

USE MinionsDB

CREATE TABLE EvilnessFactors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Villains(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EvilnessFactorId INT REFERENCES EvilnessFactors(Id) NOT NULL
)

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryCode INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT,
	TownsId INT REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Minionsvillaines(
	MinionId INT REFERENCES Minions(Id) NOT NULL,
	VillainId INT REFERENCES Villains(Id) NOT NULL

   PRIMARY KEY (MinionId,VillainId)
)

USE MinionsDB

INSERT INTO Countries(Name)
	VALUES
			('Bulgaria'),
			('Croatia'),
			('Georgia'),
			('USA'),
			('Portugal')


INSERT INTO Towns(Name,CountryCode)
	VALUES
			('Burgas',1),
			('Split',2),
			('Tbilisi',3),
			('Boston',4),
			('Portugal',5)

SELECT * FROM Towns

INSERT INTO Minions(Name,Age,TownsId)
	VALUES
			('Pesho',20,6),
			('Ivan',25,2),
			('Petar',2,2),
			('Gosho',20,3),
			('Maria',5,2)

SELECT * FROM Minions
SELECT * FROM Towns

INSERT INTO EvilnessFactors(Name)

INSERT INTO Villains(Name,EvilnessFactorId)
	VALUES
		()