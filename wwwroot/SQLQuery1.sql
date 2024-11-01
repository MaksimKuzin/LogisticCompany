CREATE PROCEDURE ApplyDiscountToOrder
    @OrderId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Orders
    SET Price = Price * 0.9 -- Уменьшаем цену на 10%
    WHERE Id = @OrderId AND Price > 0; -- Обновляем только указанный заказ с ценой больше 0
END