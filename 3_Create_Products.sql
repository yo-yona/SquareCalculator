USE MindBox_Ionova;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
DROP TABLE dbo.Products;
CREATE TABLE dbo.Products
(
ProductId BIGINT IDENTITY(1,1) CONSTRAINT
 PK_Products PRIMARY KEY,
ProductTitle VARCHAR(25) NOT NULL,
CategoryId bigint NULL,
FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);