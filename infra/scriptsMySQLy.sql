CREATE SCHEMA `appdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
CREATE USER 'sqluser' IDENTIFIED BY '1vT!KP)99?nhjkl90';

USE appdb
DROP TABLE IF EXISTS Products;
CREATE TABLE Products(
	ProductID	int,
	ProductName	varchar(1000),
	Quantity	int,
	PRIMARY KEY (ProductID)
);

INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (1, 'Mobile', 100);
INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (2, 'Laptop', 200);
INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (3, 'Tabs', 300);
SELECT * FROM Products;
SELECT ProductID, ProductName, Quantity FROM Products;
GRANT EXECUTE TO sqluser
GRANT INSERT TO sqluser
GRANT DELETE TO sqluser
GRANT UPDATE TO sqluser
GRANT SELECT TO sqluser
