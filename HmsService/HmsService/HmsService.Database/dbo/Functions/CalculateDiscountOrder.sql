Create FUNCTION [dbo].[CalculateDiscountOrder] (@rentId  int)
returns int
as
begin
	Declare @result int;
	SELECT @result = SUM(od.Discount)
	FROM OrderDetail od
	WHERE od.RentID = @rentId;

	RETURN @result;
end