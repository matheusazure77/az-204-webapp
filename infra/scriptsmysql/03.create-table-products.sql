DROP TABLE IF EXISTS Products;
CREATE TABLE Products(
	ProductID	INT NOT NULL,
	ProductName	VARCHAR(1000) NOT NULL UNIQUE,
	Quantity	INT NOT NULL,
	PRIMARY KEY (ProductID)
);
