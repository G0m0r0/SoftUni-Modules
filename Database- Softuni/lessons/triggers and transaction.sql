USE Bank

--transfer money
CREATE OR ALTER PROCEDURE usp_TransferFunds(@FromAccountId int,@ToAccountId int, @Amount money)
AS
BEGIN TRANSACTION
	IF(@Amount<=0)
	BEGIN
		ROLLBACK;
		THROW 50004, 'Invalid amount value',1
	END

	IF ((SELECT COUNT(*) FROM Accounts WHERE Id=@FromAccountId)!=1)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid from accountID.',1;
	END

	IF ((SELECT COUNT(*) FROM Accounts WHERE Id=@FromAccountId)!=1)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid ToAccountID',1;
	END

	IF((SELECT Balance FROM Accounts WHERE Id=@FromAccountId)<@Amount)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Insufficient amount',1
	END

	UPDATE Accounts SET Balance=Balance-@Amount WHERE Id=@FromAccountId
	UPDATE Accounts SET Balance=Balance+@Amount WHERE Id=@ToAccountId
COMMIT
GO


--trigers
USE SoftUni
CREATE TRIGGER tr_TownsUpdate ON Towns INSTEAD OF DELETE
AS
	SELECT * FROM inserted
	SELECT * FROM deleted
GO

CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS


GO


--exercise
CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS
	IF (EXISTS(SELECT * FROM inserted WHERE Name IS NULL OR LEN(Name) = 0))
	BEGIN
		RAISERROR('Town name cannot be empty.', 16, 1)
		ROLLBACK
		RETURN
	END

	UPDATE Towns SET Name='' WHERE TownId=1
GO
--instead of
USE Bank

CREATE OR ALTER TRIGGER tr_SetIsDeletedOnDeleted ON AccountHolders
INSTEAD OF DELETE
AS
	UPDATE ah SET ah.IsDeleted=1
	FROM AccountHolders AS ah
	JOIN deleted AS d ON ah.Id=d.Id

GO


--or
CREATE OR ALTER TRIGGER tr_SetIsDeletedOnDeleted ON AccountHolders
INSTEAD OF DELETE
AS
	UPDATE AccountHolders SET IsDeleted=1
		WHERE Id IN (SELECT Id FROM deleted)
GO

--exercise
CREATE TABLE Logs
(
	Id int IDENTITY PRIMARY KEY,
	AccountId int REFERENCES Accounts(Id),
	OldAmount money NOT NULL,
	NewAmount money NOT NULL,
	UpdatedOn datetime,
	UpdatedBy nvarchar(max),
)

CREATE OR ALTER TRIGGER tr_AddToLogsOnAccountUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId,OldAmount,NewAmount,UpdatedOn,UpdatedBy)
	SELECT i.Id,d.Balance ,i.Balance,GETDATE(), CURRENT_USER FROM inserted AS i
		JOIN deleted AS d ON i.Id=d.Id
			WHERE i.Balance!=d.Balance

GO