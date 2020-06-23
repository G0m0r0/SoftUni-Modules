CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @BaseRate DECIMAL(18,2)
    SET @BaseRate = (SELECT Hotels.BaseRate FROM Hotels WHERE Hotels.Id = @HotelId)
 
    DECLARE @RoomId INT
    SET @RoomId = (SELECT TOP(1) k.RoomId FROM(
                    SELECT r.Id AS RoomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
                    FROM Rooms AS r
                    JOIN Hotels AS h ON h.Id = r.HotelId
                    JOIN Trips AS t ON t.RoomId = r.Id
                    WHERE h.Id = @HotelId AND r.Beds >= @People ) as k
                    WHERE NOT EXISTS (SELECT tempDBTwo.RoomId
                                FROM(
                                SELECT r2.Id AS RoomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
                                FROM Rooms AS r2
                                JOIN Hotels AS h2 ON h2.Id = r2.HotelId
                                JOIN Trips AS t2 ON t2.RoomId = r2.Id
                                WHERE h2.Id = @HotelId AND r2.Beds >= @People ) as tempDBTwo
                                WHERE (CancelDate IS NULL AND @Date > ArrivalDate AND @Date < ReturnDate))
                    ORDER BY k.Price DESC)
 
    IF(@RoomId IS NULL) 
		RETURN 'No rooms available'
 
    DECLARE @highestPrice DECIMAL(18,2)= (SELECT Price FROM Rooms WHERE Id = @RoomId)
 
    DECLARE @roomType NVARCHAR(100)=(SELECT [Type] FROM Rooms WHERE Id = @RoomId)
 
    DECLARE @roomBeds INT=(SELECT Beds FROM Rooms WHERE Id = @RoomId)
 
    DECLARE @totalPrice DECIMAL(18,2)= (@BaseRate + @highestPrice) * @People

	DECLARE @Message VARCHAR(100)=CONCAT('Room ',@roomId,': ',@roomType,' (',@roomBeds,' beds) - $',@totalPrice)
		RETURN @Message
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)