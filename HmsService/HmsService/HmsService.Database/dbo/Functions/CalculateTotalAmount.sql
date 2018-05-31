Create FUNCTION [dbo].[CalculateTotalAmount] (@rentId  int)
returns int
as
begin
	Declare @result int;
	SELECT @result = SUM(od.TotalAmount)
	FROM OrderDetail od
	WHERE od.RentID = @rentId;

	RETURN @result;
end