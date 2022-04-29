USE MindBox_Ionova;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL
DROP TABLE dbo.Categories;
CREATE TABLE dbo.Categories
(
CategoryId BIGINT IDENTITY(1,1) CONSTRAINT
 PK_Categories PRIMARY KEY,
CategoryName VARCHAR(25) NOT NULL,
Info VARCHAR (25)
);