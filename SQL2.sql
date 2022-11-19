Customer
    PersonID
    FirstName
    LastName
    Age
    Occupation
    MaritalStatus

Orders
    OrderID
    PersonID
    DateCreated
    MethodOfPurchase

OrderDetails
    OrderID
    OrderDetailID
    ProductNumber
    ProductID
    ProductOrigin

SELECT
a.FirstName,
a.LastName as FullName,
a.Age,
b.OrderID,
b.DateCreated,
b.MethodOfPurchase as PurchaseMethod,
c.ProductNumber,
c.ProductOrigin
FROM Customer a
INNER JOIN Orders b ON a.PersonID = b.PersonID
INNER JOIN OrderDetails c ON b.OrderID = c.OrderID
WHERE c.ProductID = 1112222333