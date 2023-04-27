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


-- �r�nlerin foto�raf arama linklerini g�steren result set:
SELECT 
	'https://www.google.com/search?tbm=isch&q=' + ProductName
FROM Products


----- View ----- -> her �a��r�ld���nda bu sorguyu tekrardan �al��t�r�yor
CREATE VIEW ActiveProducts
AS -- -> buradaki as alias de�il view'in tan�m�
SELECT 
	ProductName, UnitPrice
FROM Products
WHERE Discontinued = 0

SELECT * FROM ActiveProducts

CREATE VIEW CategoryMenu
AS
SELECT CategoryName, COUNT(DISTINCT ProductName) AS Quantity
FROM Categories LEFT JOIN Products
ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName
-- ORDER BY CategoryName -> view i�erisinde order by olmaz

SELECT * FROM CategoryMenu 
	WHERE Quantity > 5 
	ORDER BY Quantity DESC

CREATE VIEW DetailedOrders
AS
SELECT
	o.OrderID,
	c.CompanyName, o.OrderDate,
	e.FirstName + ' ' + e.LastName '�al��an',
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


SELECT 
	CategoryName, COUNT(OrderID) AS TotalOrder
FROM DetailedOrders
GROUP BY CategoryName
ORDER BY TotalOrder DESC

CREATE VIEW CategorySales_1996_August
AS
SELECT 
	CategoryName,
	COUNT(OrderID) AS TotalOrder, 
	SUM(�denen) AS TotalPrice
FROM DetailedOrders
WHERE OrderDate BETWEEN '1996-08-01' AND '1996-08-31'
GROUP BY CategoryName

SELECT * FROM CategorySales_1996_August

SELECT 
	ProductName, SUM(Quantity) AS TotalQuantity
FROM DetailedOrders
GROUP BY ProductName
ORDER BY TotalQuantity DESC


SELECT 
	ProductName, SUM(�denen) AS TotalPrice
FROM DetailedOrders
GROUP BY ProductName
ORDER BY TotalPrice DESC


SELECT *
FROM Products
WHERE ProductName LIKE '%Cha%'


/* Nonclustered index: */
CREATE NONCLUSTERED INDEX ProductName ON Products
(
	[ProductName] ASC
)
GO


/* Bozulan index'i d�zenler */
DBCC INDEXDEFRAG (Northwind, 'Products', ProductName);
GO


-- Stored Procedure: Parametrik olarak, sorgu �retebilen nesneler:
 
CREATE PROCEDURE AddNewProduct
	@name nvarchar(40), 
	@price money
AS
INSERT INTO Products (ProductName, UnitPrice)
			VALUES (@name, @price);

AddNewProduct 'Domates', 40


CREATE PROC GetOrdersByDate
	@start datetime,
	@finish datetime
AS
SELECT *
FROM Orders WHERE OrderDate BETWEEN @start AND @finish


GetOrdersByDate '19971201', '19971231'


-- Bu �r�n� alanlar bunu da ald�lar.
-- 1. O �r�n� alan t�m sipari�leri bul.
-- 2. O �r�n hari�, di�er �r�nlere bak.
CREATE PROC BunuAlanlarBunudaAldi
	@productId int,
	@value int = 1 -- -> default de�er verilebiliyor
AS
SELECT TOP 5 ProductName, SUM(Quantity) AS TotalQuantity
FROM Products JOIN [Order Details]
ON Products.ProductID = [Order Details].ProductID
WHERE [Order Details].OrderID IN(
			SELECT OrderId FROM [Order Details] WHERE ProductID = @productId
		)
		AND [Order Details].ProductID != @productId
GROUP BY ProductName
ORDER BY TotalQuantity DESC



BunuAlanlarBunudaAldi 1


-- Transaction: Bir eylemin, belirli bir durumda geri al�nabilir olmas�n� sa�layan, kurall� ak��.

BEGIN TRY
	BEGIN TRANSACTION T1
		-- �al��mas� gereken ilk sorgu
		BEGIN TRANSACTION T2
			-- T1'in �al��mas�na ba�l� ikinci sorgu
		COMMIT T2
	COMMIT TRANSACTION T1
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION T1
	-- Herhangi bir yerde hata olursa geri almas�n� sa�l�yor
	-- Bir tane daha T3 olsayd� e�er sadece T1'i geri al dedi�imiz zaman t�m TRANSACTION'� geri al�r
END CATCH


CREATE PROC NewOrderDetail
	@customerId nchar(5),
	@productId int,
	@quantity int
AS
--@@ROWCOUNT
--@@ERROR
BEGIN TRY 
	BEGIN TRAN CreateOrder
		-- 1. �nce Orders tablosunda sipari� olu�tur.
		DECLARE @lastOrderId int -- -> de�i�ken tan�mlama
		INSERT INTO Orders (CustomerID, OrderDate) VALUES (@customerId, GETDATE())
		SET @lastOrderId = SCOPE_IDENTITY() -- -> son id de�erini getiriyor
		BEGIN TRAN Create_Order_Details
			-- 2. 1. ��lemin sonunda elde etti�in yeni OrderId ile sipari� detay�(Order Details) (�r�n ve adet) ekle
			INSERT INTO [Order Details] (OrderID, ProductID, Quantity) VALUES (@lastOrderId, @productId, @quantity)
			BEGIN TRAN UpdateProduct
				-- 3. Sipari� edilen adeti �r�n sto�undan d��
				UPDATE Products SET UnitInStock = UnitInStock - @quantity WHERE ProductID = @productId
			COMMIT TRAN UpdateProduct
		COMMIT TRAN Create_Order_Details
	COMMIT TRAN CreateOrder
END TRY
BEGIN CATCH
	ROLLBACK TRAN CreateOrder
END CATCH


AddNewOrderDetail 'ALFKI', 3, 4

SELECT TOP 1 * FROM Orders ORDER BY OrderID DESC
SELECT OrderID, ProductID, Quantity FROM [Order Details] WHERE OrderID = 11078
SELECT ProductName, UnitInStock FROM Products WHERE ProductID = 3

-- ...yerine (instead of)
-- ...den sonra (after)

-- �r�n sat�n al�nd���nda; o �r�n�n sto�undan sat�n al�nan adet kadar d��en trigger:

-- After trigger
CREATE TRIGGER stockUpdater
ON [Order Details] FOR INSERT --, UPDATE
AS 
-- INSERTED & DELETED ad�nda 2 tane ge�ici tablo var ve sadece 1 sat�r� mevcut son i�lem g�reni i�inde tutar
-- sadece trigger i�erisinden eri�ilir
DECLARE @quantity int
DECLARE @productId int
SELECT @productId = ProductID, @quantity = Quantity FROM inserted 

UPDATE Products SET UnitInStock = UnitInStock - @quantity WHERE ProductID = @productId

-- Instead of.
SELECT ProductName, Discontinued FROM Products

CREATE TRIGGER TR_DeleteProduct
ON Products INSTEAD OF DELETE
AS 
DECLARE @id int
SELECT @id = ProductID FROM deleted
UPDATE Products SET Discountinued = 1 WHERE ProductID = @id

/*
	��renciler
	��renciId Ad Soyad Puan


	Ge�enler
	��renciId Ad Soyad Puan


	Kalanlar
	��renciId Ad Soyad Puan

	-- Otomatik olarak 50'nin �zerinde alan ��renciyi,
	Ge�enlere kaydedecez; alt�ndaysa Kalanlar tablosuna kaydedecek trigger.
	-- Ge�enler tablosuna insert yap�lmaya �al���ld���nda INSTEAD OF ile 
	kayd� ��rencilere y�nlendiren trigger yazmaya karar verildi
*/