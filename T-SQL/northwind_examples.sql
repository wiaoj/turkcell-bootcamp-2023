-- INSERT INTO [Tablo Adi] ([Kolon Adý 1], [Kolon Adý 2], [Kolon Adý N])
--			VALUES ([Deðer 1], [Deðer 2], [Deðer N])

INSERT INTO Categories(CategoryName, Description)
			VALUES('....', '....')

--T-SQL: Transact - Structured Query Language

--UPDATE
-- UPDATE [TabloAdi] SET [Kolon Adý 1]=[Deðer 1], [Kolon Adý 2]=[Deðer 2]
-- WHERE [Koþul]


UPDATE Categories SET Description = '......'
WHERE CategoryID = 9;


SELECT CustomerID, CompanyName, Address, City, Country 
FROM Customers
WHERE Country LIKE '%A';

SELECT FirstName, LastName, Title, YEAR(GETDATE()) - YEAR(BirthDate) AS Age
FROM Employees
ORDER BY Age;

SELECT LOWER('BÜYÜK');
SELECT UPPER('küçük');

SELECT FirstName + ' ' + UPPER(LastName) FullName, Title, YEAR(GETDATE()) - YEAR(BirthDate) AS Age
FROM Employees
ORDER BY Age, FullName;

SELECT * FROM Orders
WHERE OrderDate BETWEEN '1996-07-04' AND '1996-08-01'; -- son sayý dahil ediliyor


SELECT * FROM Customers
WHERE CompanyName BETWEEN 'A' AND 'D' -- son karakter dahil edilmiyor


-- Almanya'daki veya Italya'daki müþterilerim kim?
SELECT CustomerID, CompanyName, ContactName, Address, City, Country
FROM Customers
WHERE Country IN ('Germany', 'Italy', 'UK', 'Spain','France') -- NOT IN (..)
ORDER BY Country;

SELECT CompanyName, Country, Fax
FROM Customers
WHERE Fax IS NOT NULL; -- IS NULL -> NULL olan deðerleri getirir

-- Satýþ yapýlan ülkeler:
SELECT DISTINCT Country -- DISTINCT -> Tekrar eden satýrlardan birini getirir
FROM Customers

-- Aggregate Functions:
-- Bellekte bir araya getirilmiþ veriler üzerinde çalýþan fonksiyonlar

-- 10248 ID'li sipariþte ne kadar ödendi?
SELECT SUM(UnitPrice * (1 - Discount) * Quantity)
FROM [Order Details]
WHERE OrderID = 10248;

-- UK'da kaç adet müþterim var?
SELECT COUNT(DISTINCT CustomerID) AS TotalCustomerCount FROM Customers WHERE Country = 'UK';

-- MIN, MAX, AVG,
-- Group BY:
-- SELECT Renk, COUNT(Pantolon) 
-- FROM Gardrop
-- GROUP BY Renk

-- Hangi ülkede kaç adet müþterim var?
SELECT Country ,COUNT(DISTINCT CustomerID) AS TotalCustomer
FROM Customers 
GROUP BY Country
ORDER BY TotalCustomer DESC;

-- Hesaplanmýþ deðerleri (bellekte bulunan verileri) HAVING ile þartlandýrýrýz
-- WHERE kolonda bulunan deðerler için kullanýr
-- 5'den fazla müþterim olan ülkeler
SELECT Country ,COUNT(DISTINCT CustomerID) AS TotalCustomer
FROM Customers 
GROUP BY Country
HAVING COUNT(DISTINCT CustomerID) >= 5
ORDER BY TotalCustomer DESC;

-- Sipariþte ne kadar ödendi?
SELECT OrderId, '$' + CAST(ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS nvarchar(10)) AS TotalPrice
FROM [Order Details]
GROUP BY OrderId;

-- 1000 Dolardan fazla tutan sipariþler
SELECT OrderId, '$' + CONVERT(nvarchar,ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2)) AS TotalPriceFROM [Order Details]GROUP BY ORDERID
HAVING ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2) > 1000;

SELECT SUM(UnitPrice *(1 - Discount) * Quantity)
FROM [Order Details]
HAVING SUM(UnitPrice *(1 - Discount) * Quantity) > 1000;


SELECT TOP 5 -- Ýlk 5 satýrý getirir TOP N
	OrderId, ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS Total
FROM [Order Details]
GROUP BY OrderId
ORDER BY Total DESC




