USE master
CREATE LOGIN sqluser WITH PASSWORD = '1vT!KP)99?nhjkl90';

USE appdb
CREATE TABLE Products(
	ProductID	int,
	ProductName	varchar(1000),
	Quantity	int
)

INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (1, 'Mobile', 100)
INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (2, 'Laptop', 200)
INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (3, 'Tabs', 300)
SELECT * FROM Products
SELECT ProductID, ProductName, Quantity FROM Products
CREATE USER sqluser FOR LOGIN sqluser
GRANT EXECUTE TO sqluser
GRANT INSERT TO sqluser
GRANT DELETE TO sqluser
GRANT UPDATE TO sqluser
GRANT SELECT TO sqluser
