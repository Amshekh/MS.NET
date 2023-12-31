-- sqlcmd -S . -E -i shop.sql

CREATE DATABASE Shop
GO

USE Shop
GO

CREATE TABLE [Product] (
  [ProductNo] int NOT NULL
, [Price] numeric(8,2) NOT NULL
, [Stock] int NOT NULL
);
GO

CREATE TABLE [Customer] (
  [CustomerId] nvarchar(8) NOT NULL
, [Password] nvarchar(8) NULL
, [Email] nvarchar(24) NOT NULL
, [Credit] numeric(8,2) NULL
);
GO

CREATE TABLE [OrderDetail] (
  [OrderNo] int NOT NULL
, [OrderDate] datetime NOT NULL
, [CustomerId] nvarchar(8) NOT NULL
, [ProductNo] int NOT NULL
, [Quantity] int NOT NULL
);
GO

CREATE TABLE [Counter] (
  [Name] nvarchar(16) NOT NULL
, [CurrentValue] int NOT NULL
);
GO

ALTER TABLE [Product] ADD CONSTRAINT [PK_Product] PRIMARY KEY ([ProductNo]);
GO
ALTER TABLE [Product] ADD CONSTRAINT [CK_Product_Stock] CHECK ([Stock] >= 0)
GO
ALTER TABLE [Customer] ADD CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId]);
GO
ALTER TABLE [Customer] ADD CONSTRAINT [CK_Customer_Credit] CHECK ([Credit] >= 0)
GO
ALTER TABLE [OrderDetail] ADD CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderNo]);
GO
ALTER TABLE [OrderDetail] ADD CONSTRAINT [FK_OrderDetail_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([CustomerId]);
GO
ALTER TABLE [OrderDetail] ADD CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY ([ProductNo]) REFERENCES [Product]([ProductNo]);
GO
ALTER TABLE [Counter] ADD CONSTRAINT [PK_Counter] PRIMARY KEY ([Name]);
GO

INSERT INTO [Customer] ([CustomerId],[Password],[Email],[Credit]) VALUES (N'CU101',N'PW101',N'cu101@met.edu',1000.00);
INSERT INTO [Customer] ([CustomerId],[Password],[Email],[Credit]) VALUES (N'CU102',N'PW102',N'cu102@met.edu',2000.00);
INSERT INTO [Customer] ([CustomerId],[Password],[Email],[Credit]) VALUES (N'CU103',N'PW103',N'cu103@met.edu',3000.00);
INSERT INTO [Customer] ([CustomerId],[Password],[Email],[Credit]) VALUES (N'CU104',N'PW104',N'cu104@met.edu',4000.00);
INSERT INTO [Product] ([ProductNo],[Price],[Stock]) VALUES (101,350.25,10);
INSERT INTO [Product] ([ProductNo],[Price],[Stock]) VALUES (102,975.50,20);
INSERT INTO [Product] ([ProductNo],[Price],[Stock]) VALUES (103,945.00,30);
INSERT INTO [Product] ([ProductNo],[Price],[Stock]) VALUES (104,1025.00,40);
INSERT INTO [Product] ([ProductNo],[Price],[Stock]) VALUES (105,750.75,50);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1001,{ts '2010-01-15 00:00:00.000'},N'CU102',101,8);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1002,{ts '2010-02-21 00:00:00.000'},N'CU101',104,6);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1003,{ts '2010-03-05 00:00:00.000'},N'CU104',102,12);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1004,{ts '2010-04-11 00:00:00.000'},N'CU103',103,3);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1005,{ts '2010-05-30 00:00:00.000'},N'CU101',101,9);
INSERT INTO [OrderDetail] ([OrderNo],[OrderDate],[CustomerId],[ProductNo],[Quantity]) VALUES (1006,{ts '2010-06-17 00:00:00.000'},N'CU101',105,5);
INSERT INTO [Counter] ([Name],[CurrentValue]) VALUES (N'order',6);
GO

CREATE PROCEDURE PlaceOrder(
	@Customer nvarchar(8),
	@Product int,
	@Quantity int,
	@OrderNo int OUTPUT) AS
BEGIN TRAN
UPDATE Counter SET CurrentValue=CurrentValue+1 WHERE Name='order'
SELECT @OrderNo = CurrentValue+1000 FROM Counter WHERE Name='order'
INSERT INTO OrderDetail VALUES(@OrderNo, GetDate(), @Customer, @Product, @Quantity)
IF @@error = 0 COMMIT TRAN
ELSE
BEGIN
	ROLLBACK TRAN
	SET @OrderNo = 0
END
GO

CREATE FUNCTION CheckCustomer(
	@Customer nvarchar(8), 
	@Password nvarchar(8))
RETURNS int AS
BEGIN
	DECLARE @result int
	SELECT @result=COUNT(CustomerId) FROM Customer WHERE CustomerId=@Customer AND Password=@Password
	RETURN @result
END
GO

CREATE VIEW Invoice AS
SELECT OrderNo, OrderDate, CustomerId, OrderDetail.ProductNo, Quantity, Price*Quantity As Amount
FROM OrderDetail, Product
WHERE OrderDetail.ProductNo = Product.ProductNo
GO

/*
EXEC sp_grantlogin N'NT AUTHORITY\NETWORK SERVICE'
GO
EXEC sp_grantdbaccess N'NT AUTHORITY\NETWORK SERVICE'
GO
*/

