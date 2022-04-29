USE MindBox_Ionova;

SELECT ProductTitle,CategoryName 
FROM Products 
LEFT JOIN Categories 
ON Products.CategoryId=Categories.CategoryId;