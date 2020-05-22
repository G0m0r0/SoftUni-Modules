--1
CREATE DATABASE Minions

--2
USE Minions
CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) not null,
	Age TINYINT 
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	[name] NVARCHAR(50) NOT NULL,
)

--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--4
INSERT INTO TOWNS(Id, [Name])	
	VALUES 
			(1,'Sofia'),
			(2,'Plovdiv'),
			(3,'Varna')
--SELECT Id, [Name] FROM Towns
SELECT * FROM Towns

INSERT INTO Minions(Id, [Name],Age,TownId)
	VALUES
			(1, 'Kevin',22,1),
			(2,'Bob',15,3),
			(3,'Steward',NULL,2)

SELECT * FROM Minions
SELECT * FROM Towns

--5
TRUNCATE TABLE Minions
SELECT*FROM Minions

--6
DROP TABLE Minions
DROP TABLE Towns

--7
USE Minions
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX)CHECK(DATALENGTH(Picture)<=2048*1024),
	Height decimal(10,2),
	[Weight] decimal(10,2),
	Gender CHAR(2) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)	

SELECT * FROM People

INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate)	
	VALUES 
			('Sofia1',NULL,120.00,100.00,'m','10.05.2000'),
			('Sofia2',NULL,120.00,100.00,'m','10.05.2000'),
			('Sofia3',NULL,120.00,100.00,'m','10.05.2000'),
			('Sofia4',NULL,120.00,100.00,'m','10.05.2000'),
			('Sofia5',NULL,120.00,100.00,'m','10.05.2000')
--SELECT Id, [Name] FROM Towns
SELECT * FROM People

--8
Use Minions 
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture)<=900*1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL 
)


INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
VALUES
('Pesgo1','123455','03.05.2020',0),
('Pesgo2','123455','03.05.2020',0),
('Pesgo3','123455','03.05.2020',0),
('Pesgo4','123455','03.05.2020',1),
('Pesgo5','123455','03.05.2020',1)

SELECT * FROM Users

DELETE FROM Users WHERE Id=5

INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
VALUES
('Pesgo6','123455','03.05.2020',0)

SELECT * FROM Users

--9
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07C6E9098A]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id,Username)

--10
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength CHECK(LEN([Password])>=5)
--test
INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
VALUES
('Pesgo7','1235678','03.05.2020',0)
SELECT * FROM Users

--11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password],IsDeleted)
	VALUES
			('Pesgo8','1235678',0)
SELECT * FROM Users
--12
ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Username CHECK(LEN(Username)>=3)
--13
CREATE DATABASE Movies

USE Movies
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Directors(DirectorName)
	VALUES
			('Ivan1'),
			('Ivan2'),
			('Ivan3')
SELECT * FROM Directors

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Genres(GenreName,Notes)
	VALUES 
			('action',NULL),
			('action',NULL),
			('action3','funny movie')
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Categories(CategoryName)
	VALUES
			('Romantic'),
			('Romantic2'),
			('Romantic3')
CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	DirectorID INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyRightYear DATE NOT NULL,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating TINYINT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title,DirectorId,CopyRightYear,GenreId,CategoryId,Rating)
		Values
				('Terminator',2,'1999',2,3,100),
				('Terminator2',1,'1999',1,3,100),
				('Terminator3',5,'1999',1,3,100)
SELECT * FROM Movies
--14
CREATE DATABASE CarRental

USE CarRental
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(30) NOT NULL,
	DailyRate DECIMAL(10,2) NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL,
	MontlyRate DECIMAL(10,2) NOT NULL,
	WeekendRate DECIMAL(10,2) NOT NULL
)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MontlyRate,WeekendRate)
			VALUES
					('first',500,3000.15,10000.20,55.3),
					('second',500,3000.15,10000.20,55.3),
					('tird',5000,30000.15,100000.20,505.3)
SELECT * FROM Categories

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber NVARCHAR(20) NOT NULL,
	Manufacturer NVARCHAR(20),
	Model NVARCHAR(20) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors TINYINT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(30) NOT NULL,
	Available NVARCHAR(10) NOT NULL
)

INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Condition,Available)
			VALUES
					('BG_5432_FN','Italy','Opel','1997',2,'Excellent','YES'),
					('BG_5462_FN','Germany','Opel2','1987',2,'Excellent','YES'),
					('BG_44332_FN','Italy','Ope3l','1999',2,'Good','No')
SELECT * FROM Cars

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Employees(FirstName,LastName,Title)
			VALUES 
					('Ivan','Petrov','Boss'),
					('Ivan2','Petrov2','employee'),
					('Ivan3','Petrov3','accountant')
SELECT * FROM Employees

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber NVARCHAR(30) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	City NVARCHAR(30),
	ZIPCode NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],ZIPCode)
			VALUES
					('FN_234_JK','Ivan Petrov Ivanov','Str. Marinela 12','12365'),
					('FN_1423_JK','Ivan2 Petrov2 Ivanov2','Str. Ferveh 17','T345'),
					('FN_2234_JK','Ivan3 Petrov3 Ivanov3','Str. Obrtal 2','gg1d5')
SELECT * FROM Customers

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeedId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerID INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT,
	KilometrafeEnd INT,
	TotalKilometrage BIGINT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays TINYINT,
	RateApplied INT,
	TaxRate DECIMAL(20,2) NOT NULL,
	OrderStatus NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders(CustomerID,CarId,TankLevel,StartDate,EndDate,TaxRate,OrderStatus)
			Values
					(3,1,2000,'03.05.2020','03.25.2020',18,'Ordered'),
					(1,3,2000,'07.05.2019','02.27.2020',18,'Ordered'),
					(1,2,2000,'10.05.2018','12.21.2018',18,'Ordered')
SELECT * FROM RentalOrders
--15
CREATE DATABASE Hotel

 USE Hotel
 
 CREATE TABLE Employees(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 Title NVARCHAR(50) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Customers(
 AccountNumber  INT PRIMARY KEY NOT NULL, 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 PhoneNumber INT NOT NULL, 
 EmergencyName NVARCHAR(50) NOT NULL, 
 EmergencyNumber INT NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomStatus(
 RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomTypes(
 RoomType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE BedTypes(
 BedType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Rooms(
 RoomNumber INT PRIMARY KEY NOT NULL, 
 RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
 BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL, 
 Rate DECIMAL(5, 2) NOT NULL, 
 RoomStatus VARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Payments(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  PaymentDate DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  FirstDateOccupied DATE NOT NULL, 
  LastDateOccupied DATE NOT NULL, 
  TotalDays INT NOT NULL, 
  AmountCharged DECIMAL(10,2) NOT NULL, 
  TaxRate DECIMAL(10,2) NOT NULL, 
  TaxAmount DECIMAL(10,2) NOT NULL, 
  PaymentTotal DECIMAL(10,2) NOT NULL, 
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Occupancies(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  DateOccupied DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
  RateApplied DECIMAL(8,2) NOT NULL, 
  PhoneCharge DECIMAL(8,2), 
  Notes NVARCHAR(MAX)
  )

  INSERT INTO Employees (FirstName, LastName, Title, Notes)
	 VALUES
	 ('Toto', 'Totev', 'Boss', null),
	 ('Moto', 'Motev', 'Slave', null),
	 ('Roto', 'Rotev', 'Slave', null)

	 INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	 VALUES
	 (11, 'Toto', 'Totev', 12345, 'Toto', 911, null),
	 (22, 'Moto', 'Motev', 12345, 'Toto', 911, null),
	 (33, 'Roto', 'Rotev', 12345, 'Toto', 911, null)

	 INSERT INTO RoomStatus(RoomStatus, Notes)
	 VALUES
	  ('C', null),
	  ('O', null),
	  ('CO', null)

	 INSERT INTO RoomTypes (RoomType, Notes)
	 VALUES
	  ('Big', null),
	  ('Medium', null),
	  ('Small', null)

	 INSERT INTO BedTypes (BedType, Notes)
	 VALUES
	 ('Big', null),
	 ('Medium', null),
	 ('Small', null)

	 INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
	 VALUES
	 (1, 'Big', 'Small', 25, 'C', null),
	 (2, 'Small', 'Big', 35, 'O', null),
	 (3, 'Small', 'Small', 5, 'CO', null)

	 INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
	 VALUES
	 (1, '2020-01-23', 11, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (2, '2020-01-23', 22, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (3, '2020-01-23', 33, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null)

	 INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	 VALUES
	 (1, '2020-01-23', 11, 1, 23, 43, null),
	 (2, '2020-01-23', 22, 2, 23, 43, null),
	 (3, '2020-01-23', 33, 3, 23, 43, null)
--16
CREATE DATABASE SoftUni
Use SoftUni
Create TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

Create TABLE Adresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AdressText NVARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Adresses(Id)
)

--18
INSERT INTO Towns([Name])
	VALUES
				('Sofia'),
				('Plovid'),
				('Varna'),
				('Burgas')

INSERT INTO Departments([Name])
	VALUES
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software development'),
			('Quality Assurance')


INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
	VALUES
			('Ivan','Ivanov','Petrov','.NET Developer',4,'05.30.2020',500),
			('Ivan1','Ivanov1','Petrov','.NET Developer',3,'05.30.2020',5000),
			('Ivan2','Ivanov2','Petrov','.NET Developer',3,'05.30.2020',500),
			('Ivan3','Ivanov3','Petrov','.NET Developer',4,'05.30.2020',5000)
--19			
SELECT * FROM Towns
SELECT * FROM Employees
SELECT * FROM Employees

--20
SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21
SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName,LastName,JobTitle,Salary FROM Employees
ORDER BY Salary DESC

--22
UPDATE Employees 
SET Salary +=Salary*0.1

SELECT Salary FROM Employees

--23
USE Hotel
SELECT TaxRate FROM Payments
	UPDATE Payments
	SET TaxRate-=TaxRate*0.03
SELECT TaxRate FROM Payments
--24
TRUNCATE TABLE Occupancies 
SELECT * FROM Occupancies