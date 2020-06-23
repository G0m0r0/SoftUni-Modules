USE TripService


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
		DECLARE @RoomType NVARCHAR(20)=(
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

		IF(@RoomId IS NULL)
			RETURN 'No rooms available                                                                                                                                                               '

		DECLARE @totalPrice DECIMAL(20,2)=(@HotelBaseRate+@RoomPrice)*@People

		IF(@totalPrice IS NULL)
			RETURN 'No rooms available                                                                                                                                                                    '

		DECLARE @Message VARCHAR(100)=CONCAT('Room ',@RoomId,': ',@RoomType,' (',@RoomBeds,' beds) - $',@totalPrice)
		RETURN @Message
	END


SELECT [dbo].[udf_GetAvailableRoom](112, '2011-12-17', 2)
SELECT * FROM Hotels
WHERE id=112

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(1, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

SELECT * FROM Hotels AS h
JOIN Rooms AS r ON r.HotelId=h.Id
 WHERE h.Id=94

 SELECT * FROM Trips
--no rooms available

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(100)
BEGIN
       DECLARE @Message VARCHAR(100)= (SELECT TOP(1)
            CONCAT( 'Room', ' ', r.Id, ': ', r.Type, ' (', r.Beds, ') - $',
                (h.BaseRate + r.Price) * @people) AS [Output]
        FROM Trips AS t
        JOIN Rooms AS r ON r.Id = t.RoomId
        JOIN Hotels AS h ON h.Id = r.HotelId
        WHERE @HotelId = h.Id AND r.Beds >= @People
            AND (ArrivalDate > @date OR ReturnDate < @date OR CancelDate < @Date)
        ORDER BY (h.BaseRate + r.Price) * @people DESC)

		RETURN @Message
END

SELECT [dbo].[udf_GetAvailableRoom](112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(1, '2015-07-26', 3)

GO
CREATE OR ALTER PROCEDURE myProcedure(@HotelId INT, @Date DATE, @People INT)
AS
	BEGIN
		SELECT TOP(1)
            CONCAT( 'Room', ' ', r.Id, ': ', r.Type, ' (', r.Beds, ') - $',
                (h.BaseRate + r.Price) * @people) AS [Output]
        FROM Trips AS t
        JOIN Rooms AS r ON r.Id = t.RoomId
        JOIN Hotels AS h ON h.Id = r.HotelId
        WHERE @HotelId = h.Id AND r.Beds >= @People
            AND (ArrivalDate > @date OR ReturnDate < @date OR CancelDate < @Date)
        ORDER BY (h.BaseRate + r.Price) * @people DESC
	END

EXECUTE myProcedure 112, '2011-12-17', 2
Execute myProcedure 94, '2015-07-26', 3
execute myProcedure 1, '2015-07-26', 3