--12
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT) 
AS
	BEGIN
		DECLARE @Id1 INT=(SELECT r.HotelId FROM Trips AS t
			JOIN Rooms AS r ON r.Id=t.RoomId
			WHERE @TripId=t.id)

		DECLARE @Id2 INT=(SELECT r.HotelId FROM Rooms AS r
		JOIN Hotels AS h ON h.id=r.HotelId
		WHERE @TargetRoomId=r.Id)

		IF(@Id1!=@Id2)


			THROW 50001,'Target room is in another hotel!',1

		DECLARE @NumBeds INT=(SELECT Beds FROM Rooms WHERE @TargetRoomId=id)

		DECLARE @NumOfPeople INT=( SELECT COUNT(*) FROM Accounts AS a
			JOIN AccountsTrips AS act ON act.AccountID=a.Id
			WHERE act.TripId=10)

		if(@NumBeds<@NumOfPeople)
			THROW 50002,'Not enough beds in target room!',1

		UPDATE Trips
		SET RoomId=@TargetRoomId
	END

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
--11
EXEC usp_SwitchRoom 10, 7
--Target room is in another hotel!
EXEC usp_SwitchRoom 10, 8
--Not enough beds in target room!

--10 not
SELECT t.Id,
		CASE
			WHEN MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
			ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) 
		END AS [Full Name],
		c.Name AS [FROM]
		(SELECT TOP(1) [Name] FROM Cities WHERE id=h.CityId) AS [TO]
		FROM Trips As T
	JOIN AccountsTrips AS act ON act.TripId=t.Id
	JOIN Accounts AS a ON a.Id=act.AccountId
	JOIN Cities As c ON c.Id=a.CityId
	--JOIN Hotels AS h ON c.Id=h.CityId
	WHERE t.id=273


SELECT * FROM Cities

--11
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS VARCHAR(100)
AS
	BEGIN
		DECLARE @HotelBaseRate DECIMAL(20,2)=
							(
								SELECT BaseRate FROM Hotels
								WHERE id=@HotelId								
							)
		DECLARE @RoomPrice DECIMAL(20,2)=(
											SELECT TOP(1) Price FROM Rooms As r
											JOIN Trips AS t ON t.RoomId=r.Id
											WHERE HotelId=@HotelId AND NOT(@Date Between ArrivalDate AND ReturnDate) --canceldate
											AND Beds>=@People
											ORDER BY Price DESC
											)
		DECLARE @RoomId INT=(
											SELECT TOP(1) r.Id FROM Rooms As r
											JOIN Trips AS t ON t.RoomId=r.Id
											WHERE HotelId=@HotelId AND NOT(@Date Between ArrivalDate AND ReturnDate) --canceldate
											AND Beds>=@People
											ORDER BY Price DESC
											)
		DECLARE @RoomType INT=(
											SELECT TOP(1) [Type] FROM Rooms As r
											JOIN Trips AS t ON t.RoomId=r.Id
											WHERE HotelId=@HotelId AND NOT(@Date Between ArrivalDate AND ReturnDate) --canceldate
											AND Beds>=@People
											ORDER BY Price DESC
											)
		DECLARE @RoomBeds INT=(
											SELECT TOP(1) Beds FROM Rooms As r
											JOIN Trips AS t ON t.RoomId=r.Id
											WHERE HotelId=@HotelId AND NOT(@Date Between ArrivalDate AND ReturnDate) --canceldate
											AND Beds>=@People
											ORDER BY Price DESC
											)
		DECLARE @totalPrice DECIMAL(20,2)=(@HotelBaseRate+@RoomPrice)*@People

		DECLARE @Message VARCHAR(100)=CONCAT('Room ',@RoomId,': ',@RoomType,'(',@RoomBeds,' beds) - $',@RoomPrice)
		RETURN @RoomType
	END


SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT * FROM Hotels
WHERE id=112

SELECT * FROM Rooms	As r
JOIN Trips AS t ON t.RoomId=r.Id
WHERE HotelId=112 AND NOT('2011-12-17' Between ArrivalDate AND ReturnDate) --canceldate
AND Beds>=

	