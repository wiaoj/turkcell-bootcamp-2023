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
SELECT OrderId, 
'$' + CONVERT(nvarchar,ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2)) AS TotalPrice
FROM [Order Details]
GROUP BY ORDERID
HAVING ROUND(SUM(UnitPrice *(1 - Discount) * Quantity),2) > 1000;

SELECT SUM(UnitPrice *(1 - Discount) * Quantity)
FROM [Order Details]
HAVING SUM(UnitPrice *(1 - Discount) * Quantity) > 1000;


SELECT TOP 5 -- �lk 5 sat�r� getirir TOP N
	OrderId, ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS Total
FROM [Order Details]
GROUP BY OrderId
ORDER BY Total DESC


----- JOIN -----

SELECT ProductName, CategoryID FROM Products
SELECT CategoryID FROM Categories


INSERT INTO Categories (CategoryName) VALUES ('Tatl�lar')
INSERT INTO Products (ProductName,UnitPrice) VALUES ('G�l Re�eli', 60)

SELECT ProductName, UnitPrice, CategoryName
FROM Categories INNER JOIN Products
ON Categories.CategoryID = Products.CategoryID
ORDER BY CategoryName

-- Hangi kategoriden ka� adet �r�n vard�r?
-- 1. Ne yapmak istiyorsun?
-- 2. Hangi tablo veya tablolar ile �al��mak istiyorsun?
-- 3. Hangi kolonlar ve veri ile �al��mak istiyorsun?
-- 4. E�er G�vdede Aggregate function varsa GROUP BY kullan


SELECT CategoryName, COUNT(DISTINCT ProductID) AS Quantity
FROM Categories INNER JOIN Products -- JOIN -> varsay�lan olarak INNER JOIN olarak i�lenir
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY CategoryName

SELECT CategoryName, AVG(UnitPrice) AS AveragePrice
FROM Categories INNER JOIN Products
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
ORDER BY AveragePrice DESC

-- Hangi sipari�i, hangi m��teri vermi�?

SELECT 
	OrderID, CONVERT(nvarchar, OrderDate, 103), CompanyName
FROM Orders JOIN Customers
ON Customers.CustomerID = Orders.CustomerID
ORDER BY CompanyName


-- Hangi sipari�i, hangi m��teri vermi� ve bu sipari�i hangi �al��an onaylam��?

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


-- Hangi sipari�i 
-- Hangi m��teri, ne zaman vermi�
-- Hangi �al��an onaylam��
-- Hangi kargo �irketiyle g�nderilmi�
-- Bu sipari�te
-- Hangi tedarik�inin sa�lad���
-- Hangi kategoriden
-- Ka� adet �r�n al�nm�� ve ne kadar �denmi�tir?

SELECT
	o.OrderID,
	c.CompanyName, o.OrderDate,
	e.FirstName + ' ' + e.LastName '�al��an', -- -> alias
	s.CompanyName 'Kargo',
	sp.CompanyName 'Tedarik�i',
	ca.CategoryName,
	p.ProductName,
	od.Quantity,
	od.Discount,
	od.UnitPrice * (1 - od.Discount) * od.Quantity '�denen'
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
ORDER BY '�denen' DESC

-- OUTER JOIN 
-- Sadece e�le�en kay�tlar� de�il e�le�meyenlerden de veri getiren join t�r�
-- Kategoriler ve �r�nler
-- T�m kategoriler gelsin ve yanlar�nda �r�nler gelsin

SELECT 
	CategoryName, ProductName
FROM Categories LEFT JOIN Products
ON Products.CategoryID = Categories.CategoryID
WHERE ProductName IS NULL -- -> �r�n� olmayan kategorileri getirir


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

-- Kim Kimin M�d�r�?
SELECT 
	Calisanlar.FirstName + ' ' + Calisanlar.LastName '�al��an',
	Mudurler.FirstName + ' ' + Mudurler.LastName 'M�d�r'
FROM Employees AS Calisanlar LEFT JOIN Employees AS Mudurler -- -> Alias verdi�imiz i�in bu �ekilde join yap�labiliyor
ON Calisanlar.ReportsTo = Mudurler.EmployeeID
--WHERE Mudurler.FirstName + ' ' + Mudurler.LastName IS NULL
ORDER BY �al��an


SELECT 
	*
FROM Orders CROSS JOIN [Order Details] -- -> e�lelen t�m tablolalar�n �arp�m� kadar s�r�yor

SELECT ProductName, UnitPrice, UnitsInStock, Durum = CASE 
															WHEN UnitsInStock = 0 THEN 'Yok'
															WHEN UnitsInStock < 20 THEN 'Kritik'
															WHEN UnitsInStock < 50 THEN 'Normal'
															WHEN UnitsInStock > 50 THEN 'Fazla'
														END
FROM Products
ORDER BY Durum

-- En pahal� �r�n�m hangisi
SELECT MAX(UnitPrice)
FROM Products

-- Top 1 ile �ekince hepsini belle�e at�p 1. yi getirir uzun s�rer

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

-- �DEV -> Sorgumu se�tim -> CTRL + M (Include Actual Execution Plan) Sorgu maliyeti
-- Execution Plan� nas�l okunur?


-- Ayn� �lkede bulunan tedarik�i firmalar ve m��terilerimi istiyorum.

SELECT CompanyName, Address, City, Country, 'M��teri' AS Durum FROM Customers 
UNION -- -> iki tablodaki verileri tek tablodan �ekilmi� �ekilde g�steriyor
SELECT CompanyName, Address, City, Country, 'Tedarik�i' FROM Suppliers
ORDER BY Country -- -> ORDER BY kullan�l�rken ilk select sorgusunun Alias durumu ge�erlidir

-- En fazla para �al��an kimdir ve ne kadar para kazand�rm��t�r?