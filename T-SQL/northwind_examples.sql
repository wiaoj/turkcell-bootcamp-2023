-- INSERT INTO [Tablo Adi] ([Kolon Ad� 1], [Kolon Ad� 2], [Kolon Ad� N])
--			VALUES ([De�er 1], [De�er 2], [De�er N])

INSERT INTO Categories(CategoryName, Description)
			VALUES('....', '....')

--T-SQL: Transact - Structured Query Language

--UPDATE
-- UPDATE [TabloAdi] SET [Kolon Ad� 1]=[De�er 1], [Kolon Ad� 2]=[De�er 2]
-- WHERE [Ko�ul]


UPDATE Categories SET Description = '......'
WHERE CategoryID = 9;


SELECT CustomerID, CompanyName, Address, City, Country 
FROM Customers
WHERE Country LIKE '%A';

SELECT FirstName, LastName, Title, YEAR(GETDATE()) - YEAR(BirthDate) AS Age
FROM Employees
ORDER BY Age;

SELECT LOWER('B�Y�K');
SELECT UPPER('k���k');

SELECT FirstName + ' ' + UPPER(LastName) FullName, Title, YEAR(GETDATE()) - YEAR(BirthDate) AS Age
FROM Employees
ORDER BY Age, FullName;

SELECT * FROM Orders
WHERE OrderDate BETWEEN '1996-07-04' AND '1996-08-01'; -- son say� dahil ediliyor


SELECT * FROM Customers
WHERE CompanyName BETWEEN 'A' AND 'D' -- son karakter dahil edilmiyor


-- Almanya'daki veya Italya'daki m��terilerim kim?
SELECT CustomerID, CompanyName, ContactName, Address, City, Country
FROM Customers
WHERE Country IN ('Germany', 'Italy', 'UK', 'Spain','France') -- NOT IN (..)
ORDER BY Country;

SELECT CompanyName, Country, Fax
FROM Customers
WHERE Fax IS NOT NULL; -- IS NULL -> NULL olan de�erleri getirir

-- Sat�� yap�lan �lkeler:
SELECT DISTINCT Country -- DISTINCT -> Tekrar eden sat�rlardan birini getirir
FROM Customers

-- Aggregate Functions:
-- Bellekte bir araya getirilmi� veriler �zerinde �al��an fonksiyonlar

-- 10248 ID'li sipari�te ne kadar �dendi?
SELECT SUM(UnitPrice * (1 - Discount) * Quantity)
FROM [Order Details]
WHERE OrderID = 10248;

-- UK'da ka� adet m��terim var?
SELECT COUNT(DISTINCT CustomerID) AS TotalCustomerCount FROM Customers WHERE Country = 'UK';

-- MIN, MAX, AVG,
-- Group BY:
-- SELECT Renk, COUNT(Pantolon) 
-- FROM Gardrop
-- GROUP BY Renk

-- Hangi �lkede ka� adet m��terim var?
SELECT Country ,COUNT(DISTINCT CustomerID) AS TotalCustomer
FROM Customers 
GROUP BY Country
ORDER BY TotalCustomer DESC;

-- Hesaplanm�� de�erleri (bellekte bulunan verileri) HAVING ile �artland�r�r�z
-- WHERE kolonda bulunan de�erler i�in kullan�r
-- 5'den fazla m��terim olan �lkeler
SELECT Country ,COUNT(DISTINCT CustomerID) AS TotalCustomer
FROM Customers 
GROUP BY Country
HAVING COUNT(DISTINCT CustomerID) >= 5
ORDER BY TotalCustomer DESC;

-- Sipari�te ne kadar �dendi?
SELECT OrderId, '$' + CAST(ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS nvarchar(10)) AS TotalPrice
FROM [Order Details]
GROUP BY OrderId;

-- 1000 Dolardan fazla tutan sipari�ler
SELECT OrderId, '$' + CONVERT(nvarchar,ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2)) AS TotalPriceFROM [Order Details]GROUP BY ORDERID
HAVING ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2) > 1000;

SELECT SUM(UnitPrice *(1 - Discount) * Quantity)
FROM [Order Details]
HAVING SUM(UnitPrice *(1 - Discount) * Quantity) > 1000;


SELECT TOP 5 -- �lk 5 sat�r� getirir TOP N
	OrderId, ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS Total
FROM [Order Details]
GROUP BY OrderId
ORDER BY Total DESC




