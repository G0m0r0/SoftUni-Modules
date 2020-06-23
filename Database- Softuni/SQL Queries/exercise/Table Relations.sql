--1 one to one
CREATE TABLE Persons(
	PersonID Int PRIMARY KEY IDENTITY,
	FirstName Nvarchar(50) NOT NULL,
	Salary Decimal(10,2) NOT NULL,
	PassportID Int NOT NULL
)

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber Varchar(8)
)

--add foreign key
ALTER TABLE Persons
	ADD CONSTRAINT FK_PersonPassportID
	FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

INSERT INTO Passports(PassportID,PassportNumber)
	VALUES
			(101,'N34FG21B'),
			(102,'K65LO4R7'),
			(103,'ZE657QP2')

INSERT INTO Persons(FirstName,Salary,PassportID)
	VALUES
			('Roberto',43300.00,102),
			('Tom',56100.00,103),
			('Yana',60200.00,101)

SELECT * FROM Persons
SELECT * FROM Passports

--2 one to many
CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	[Name] Nvarchar(50) NOT NULL,
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn Date
)

ALTER TABLE Models
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID);

INSERT INTO Manufacturers([Name],EstablishedOn)
	VALUES
			('BMW','07/03/1916'),
			('Tesla','01/01/2003'),
			('Lada','01/05/1996')

INSERT INTO Models(ModelID,[Name],ManufacturerID)
	VALUES
			(101,'X1',1),
			(102,'i6',1),
			(103,'Model S',2),
			(104,'Model X',2),
			(105,'Model 3',2),
			(106,'Nova',3)


SELECT * FROM Models
SELECT * FROM Manufacturers

DROP TABLE Models,Manufacturers

--3 many to many
CREATE TABLE Students(
StudentID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

--mapping table
CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL,
--possible
--PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students(StudentID, [Name])
VALUES
( 1, 'Mila'),
( 2, 'Toni'),
( 3, 'Ron')

INSERT INTO Exams(ExamID, [Name])
VALUES
( 101, 'SpringMVC'),
( 102, 'Neo4j'),
( 103, 'Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
( 1, 101),
( 1, 102),
( 2, 101),
( 3, 103),
( 2, 102),
( 2, 103)

SELECT * FROM Students
SELECT * FROM Exams
SELECT * FROM StudentsExams

ALTER TABLE Students
ADD CONSTRAINT PK_Sudent PRIMARY KEY (StudentID)

ALTER TABLE Exams
ADD CONSTRAINT PK_Exam PRIMARY KEY (ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Exam FOREIGN KEY (ExamID) REFERENCES Exams (ExamID)


--4 self reference
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT,
)

ALTER TABLE Teachers
	ADD CONSTRAINT FK_Manager FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)


INSERT INTO Teachers(TeacherID,Name,ManagerID)
	VALUES	
			(101,'John',NULL),
			(102,'Maya',106),
			(103,'Silvia',106),
			(104,'Ted',105),
			(105,'Mark',101),
			(106,'Greta',101)

SELECT * FROM Teachers
--or
CREATE TABLE Teachers(
	TeachID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)
--5

	
CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY,
	[Name] varchar(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL,
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY,
	CustomerID INT NOT NULL
)

ALTER TABLE OrderItems
	ADD CONSTRAINT FK_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)


ALTER TABLE OrderItems
	ADD CONSTRAINT PK_OrderItemID PRIMARY KEY (OrderID,ItemID)


CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday date,
	CityID INT,
)

ALTER TABLE Orders
	ADD CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)

CREATE TABLE Cities(
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

ALTER TABLE Customers
	ADD CONSTRAINT FK_CityID FOREIGN KEY (CityID) REFERENCES Cities(CityID)


--6
CREATE DATABASE School
USE School

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY,
	SubjectName NVARCHAR(50)
)

CREATE TABLE Agenda(
	StudentID INT NOT NULL,
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL
)


CREATE TABLE [Students](
	StudentID INT PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT
)

ALTER TABLE Agenda
	ADD CONSTRAINT FK_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE Agenda
	ADD CONSTRAINT PK_StudentSubjectID PRIMARY KEY (StudentID,SubjectID)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

ALTER TABLE Students 
	ADD CONSTRAINT FK_MajorID FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY,
	PaymentDate date NOT NULL,
	PaymentAmount Decimal(8,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES [Students](StudentID)
)

--9
USE Geography
SELECT * FROM Peaks
SELECT * FROM Mountains

SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
	FROM Mountains
	JOIN Peaks ON Mountains.Id=Peaks.MountainId
	WHERE Mountains.MountainRange='Rila'
	ORDER BY Peaks.Elevation DESC