-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[CalculateRentTotalQuantity]
(
	@rentId int
)
RETURNS int
AS
BEGIN
	DECLARE @result int;

	SELECT @result = SUM(od.Quantity)
	FROM OrderDetail od
	WHERE od.RentID = @rentId;

	RETURN @result;

END

