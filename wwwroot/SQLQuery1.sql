CREATE PROCEDURE ApplyDiscountToOrder
    @OrderId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Orders
    SET Price = Price * 0.9 -- ��������� ���� �� 10%
    WHERE Id = @OrderId AND Price > 0; -- ��������� ������ ��������� ����� � ����� ������ 0
END