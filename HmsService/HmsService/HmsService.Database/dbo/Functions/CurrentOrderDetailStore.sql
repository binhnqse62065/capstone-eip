CREATE FUNCTION [dbo].[CurrentOrderDetailStore]
(
	@rentId int
)
RETURNS int
AS
BEGIN
	DECLARE @result int;

	SELECT @result = StoreID
	FROM Rent r
	WHERE r.RentID = @rentId;

	RETURN @result;

END

