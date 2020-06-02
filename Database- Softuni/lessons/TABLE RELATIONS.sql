CREATE TABLE Mountains
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] nvarchar(100) NOT NULL,
)

CREATE TABLE Peaks
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] nvarchar(100) NOT NULL,
	MountainId int NOT NULL,
	CONSTRAINT FK_Peaks_Mountains
		FOREIGN KEY (MountainId) REFERENCES Mountains(Id) 
)

DROP TABLE Mountains
DROP TABLE Peaks