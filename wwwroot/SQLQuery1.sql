CREATE PROCEDURE ApplyDiscountToOrder
    @OrderId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Price DECIMAL(15, 2);

    SELECT @Price = Price
    FROM Orders
    WHERE Id = @OrderId AND Price > 0;

    IF @Price IS NOT NULL
    BEGIN
        SET @Price = @Price * 0.9;

        UPDATE Orders
        SET Price = @Price
        WHERE Id = @OrderId;
    END
END