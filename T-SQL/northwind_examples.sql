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
SELECT OrderId, 
'$' + CONVERT(nvarchar,ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2)) AS TotalPrice
FROM [Order Details]
GROUP BY ORDERID
HAVING ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2) > 1000;

SELECT SUM(UnitPrice *(1 - Discount) * Quantity)
FROM [Order Details]
HAVING SUM(UnitPrice *(1 - Discount) * Quantity) > 1000;


SELECT TOP 5 -- Ýlk 5 satýrý getirir TOP N
	OrderId, ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS Total
FROM [Order Details]
GROUP BY OrderId
ORDER BY Total DESC


----- JOIN -----

SELECT ProductName, CategoryID FROM Products
SELECT CategoryID FROM Categories


INSERT INTO Categories (CategoryName) VALUES ('Tatlýlar')
INSERT INTO Products (ProductName,UnitPrice) VALUES ('Gül Reçeli', 60)

SELECT ProductName, UnitPrice, CategoryName
FROM Categories INNER JOIN Products
ON Categories.CategoryID = Products.CategoryID
ORDER BY CategoryName

-- Hangi kategoriden kaç adet ürün vardýr?
-- 1. Ne yapmak istiyorsun?
-- 2. Hangi tablo veya tablolar ile çalýþmak istiyorsun?
-- 3. Hangi kolonlar ve veri ile çalýþmak istiyorsun?
-- 4. Eðer Gövdede Aggregate function varsa GROUP BY kullan


SELECT CategoryName, COUNT(DISTINCT ProductID) AS Quantity
FROM Categories INNER JOIN Products -- JOIN -> varsayýlan olarak INNER JOIN olarak iþlenir
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY CategoryName

SELECT CategoryName, AVG(UnitPrice) AS AveragePrice
FROM Categories INNER JOIN Products
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY AveragePrice DESC

-- Hangi sipariþi, hangi müþteri vermiþ?

SELECT 
	OrderID, CONVERT(nvarchar, OrderDate, 103), CompanyName
FROM Orders JOIN Customers
ON Customers.CustomerID = Orders.CustomerID
ORDER BY CompanyName


-- Hangi sipariþi, hangi müþteri vermiþ ve bu sipariþi hangi çalýþan onaylamýþ?

SELECT 
	OrderID, 
	CONVERT(nvarchar, OrderDate, 103),
	CompanyName,
	CONCAT(FirstName, ' ', LastName) AS EmployeeFullName
FROM Orders JOIN Customers
ON Customers.CustomerID = Orders.CustomerID
			JOIN Employees
			ON  Orders.EmployeeID = Employees.EmployeeID
ORDER BY CompanyName


-- Hangi sipariþi 
-- Hangi müþteri, ne zaman vermiþ
-- Hangi çalýþan onaylamýþ
-- Hangi kargo þirketiyle gönderilmiþ
-- Bu sipariþte
-- Hangi tedarikçinin saðladýðý
-- Hangi kategoriden
-- Kaç adet ürün alýnmýþ ve ne kadar ödenmiþtir?

SELECT
	o.OrderID,
	c.CompanyName, o.OrderDate,
	e.FirstName + ' ' + e.LastName 'Çalýþan', -- -> alias
	s.CompanyName 'Kargo',
	sp.CompanyName 'Tedarikçi',
	ca.CategoryName,
	p.ProductName,
	od.Quantity,
	od.Discount,
	od.UnitPrice * (1 - od.Discount) * od.Quantity 'Ödenen'
FROM Employees AS e JOIN Orders o
ON e.EmployeeID = o.EmployeeID
JOIN Customers c
ON o.CustomerID = c.CustomerID
JOIN Shippers s
ON o.ShipVia = s.ShipperID
JOIN [Order Details] od
ON od.OrderID = o.OrderID
JOIN Products p
ON p.ProductID = od.ProductID
JOIN Suppliers sp
ON p.SupplierID = sp.SupplierID
JOIN Categories ca
ON ca.CategoryID = p.CategoryID
ORDER BY 'Ödenen' DESC

-- OUTER JOIN 
-- Sadece eþleþen kayýtlarý deðil eþleþmeyenlerden de veri getiren join türü
-- Kategoriler ve Ürünler
-- Tüm kategoriler gelsin ve yanlarýnda ürünler gelsin

SELECT 
	CategoryName, ProductName
FROM Categories LEFT JOIN Products
ON Products.CategoryID = Categories.CategoryID
WHERE ProductName IS NULL -- -> ürünü olmayan kategorileri getirir


SELECT 
	CategoryName, ProductName
FROM Categories RIGHT JOIN Products
ON Products.CategoryID = Categories.CategoryID
WHERE CategoryName IS NULL

SELECT 
	CategoryName, ProductName
FROM Categories FULL OUTER JOIN Products
ON Products.CategoryID = Categories.CategoryID
WHERE CategoryName + ProductName IS NULL -- CategoryName IS NULL OR ProductName IS NULL

SELECT CategoryName, COUNT(DISTINCT ProductName) AS Quantity
FROM Categories LEFT JOIN Products
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY CategoryName

-- Kim Kimin Müdürü?
SELECT 
	Calisanlar.FirstName + ' ' + Calisanlar.LastName 'Çalýþan',
	Mudurler.FirstName + ' ' + Mudurler.LastName 'Müdür'
FROM Employees AS Calisanlar LEFT JOIN Employees AS Mudurler -- -> Alias verdiðimiz için bu þekilde join yapýlabiliyor
ON Calisanlar.ReportsTo = Mudurler.EmployeeID
--WHERE Mudurler.FirstName + ' ' + Mudurler.LastName IS NULL
ORDER BY Çalýþan


SELECT 
	*
FROM Orders CROSS JOIN [Order Details] -- -> eþlelen tüm tablolalarýn çarpýmý kadar sürüyor

SELECT ProductName, UnitPrice, UnitsInStock, Durum = CASE 
															WHEN UnitsInStock = 0 THEN 'Yok'
															WHEN UnitsInStock < 20 THEN 'Kritik'
															WHEN UnitsInStock < 50 THEN 'Normal'
															WHEN UnitsInStock > 50 THEN 'Fazla'
														END
FROM Products
ORDER BY Durum

-- En pahalý ürünüm hangisi
SELECT MAX(UnitPrice)
FROM Products

-- Top 1 ile çekince hepsini belleðe atýp 1. yi getirir uzun sürer

SELECT 
	*
FROM Products
WHERE UnitPrice = (
	SELECT MIN(UnitPrice) FROM Products
	)

SELECT CategoryName, COUNT(DISTINCT ProductName) AS Quantity
FROM Categories LEFT JOIN Products
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY CategoryName


SELECT 
	c.CategoryName, (SELECT COUNT(ProductId) FROM Products WHERE CategoryID = c.CategoryID)
FROM Categories AS c

-- ÖDEV -> Sorgumu seçtim -> CTRL + M (Include Actual Execution Plan) Sorgu maliyeti
-- Execution Planý nasýl okunur?


-- Ayný ülkede bulunan tedarikçi firmalar ve müþterilerimi istiyorum.

SELECT CompanyName, Address, City, Country, 'Müþteri' AS Durum FROM Customers 
UNION -- -> iki tablodaki verileri tek tablodan çekilmiþ þekilde gösteriyor
SELECT CompanyName, Address, City, Country, 'Tedarikçi' FROM Suppliers
ORDER BY Country -- -> ORDER BY kullanýlýrken ilk select sorgusunun Alias durumu geçerlidir

-- En fazla para çalýþan kimdir ve ne kadar para kazandýrmýþtýr?