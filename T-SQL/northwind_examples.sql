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


-- Ürünlerin fotoðraf arama linklerini gösteren result set:
SELECT 
	'https://www.google.com/search?tbm=isch&q=' + ProductName
FROM Products


----- View ----- -> her çaðýrýldýðýnda bu sorguyu tekrardan çalýþtýrýyor
CREATE VIEW ActiveProducts
AS -- -> buradaki as alias deðil view'in tanýmý
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
-- ORDER BY CategoryName -> view içerisinde order by olmaz

SELECT * FROM CategoryMenu 
	WHERE Quantity > 5 
	ORDER BY Quantity DESC

CREATE VIEW DetailedOrders
AS
SELECT
	o.OrderID,
	c.CompanyName, o.OrderDate,
	e.FirstName + ' ' + e.LastName 'Çalýþan',
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
	SUM(Ödenen) AS TotalPrice
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
	ProductName, SUM(Ödenen) AS TotalPrice
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


/* Bozulan index'i düzenler */
DBCC INDEXDEFRAG (Northwind, 'Products', ProductName);
GO


-- Stored Procedure: Parametrik olarak, sorgu üretebilen nesneler:
 
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


-- Bu ürünü alanlar bunu da aldýlar.
-- 1. O ürünü alan tüm sipariþleri bul.
-- 2. O ürün hariç, diðer ürünlere bak.
CREATE PROC BunuAlanlarBunudaAldi
	@productId int,
	@value int = 1 -- -> default deðer verilebiliyor
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


-- Transaction: Bir eylemin, belirli bir durumda geri alýnabilir olmasýný saðlayan, kurallý akýþ.

BEGIN TRY
	BEGIN TRANSACTION T1
		-- Çalýþmasý gereken ilk sorgu
		BEGIN TRANSACTION T2
			-- T1'in çalýþmasýna baðlý ikinci sorgu
		COMMIT T2
	COMMIT TRANSACTION T1
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION T1
	-- Herhangi bir yerde hata olursa geri almasýný saðlýyor
	-- Bir tane daha T3 olsaydý eðer sadece T1'i geri al dediðimiz zaman tüm TRANSACTION'ý geri alýr
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
		-- 1. Önce Orders tablosunda sipariþ oluþtur.
		DECLARE @lastOrderId int -- -> deðiþken tanýmlama
		INSERT INTO Orders (CustomerID, OrderDate) VALUES (@customerId, GETDATE())
		SET @lastOrderId = SCOPE_IDENTITY() -- -> son id deðerini getiriyor
		BEGIN TRAN Create_Order_Details
			-- 2. 1. Ýþlemin sonunda elde ettiðin yeni OrderId ile sipariþ detayý(Order Details) (ürün ve adet) ekle
			INSERT INTO [Order Details] (OrderID, ProductID, Quantity) VALUES (@lastOrderId, @productId, @quantity)
			BEGIN TRAN UpdateProduct
				-- 3. Sipariþ edilen adeti ürün stoðundan düþ
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

-- Ürün satýn alýndýðýnda; o ürünün stoðundan satýn alýnan adet kadar düþen trigger:

-- After trigger
CREATE TRIGGER stockUpdater
ON [Order Details] FOR INSERT --, UPDATE
AS 
-- INSERTED & DELETED adýnda 2 tane geçici tablo var ve sadece 1 satýrý mevcut son iþlem göreni içinde tutar
-- sadece trigger içerisinden eriþilir
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
	Öðrenciler
	ÖðrenciId Ad Soyad Puan


	Geçenler
	ÖðrenciId Ad Soyad Puan


	Kalanlar
	ÖðrenciId Ad Soyad Puan

	-- Otomatik olarak 50'nin üzerinde alan öðrenciyi,
	Geçenlere kaydedecez; altýndaysa Kalanlar tablosuna kaydedecek trigger.
	-- Geçenler tablosuna insert yapýlmaya çalýþýldýðýnda INSTEAD OF ile 
	kaydý öðrencilere yönlendiren trigger yazmaya karar verildi
*/