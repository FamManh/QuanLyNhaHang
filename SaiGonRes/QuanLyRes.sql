CREATE DATABASE QuanLyRes
GO

USE QuanLyRes
GO


CREATE TABLE Account 
(
	ID INT PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	DisplayName NVARCHAR(100) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Office NVARCHAR(50) NOT NULL
)
CREATE TABLE UnitCategory
(
	ID VARCHAR(20) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE FoodCategory
(
	ID int PRIMARY KEY IDENTITY(0,1),
	Name NVARCHAR(100)  NOT NULL,
	IDUnit VARCHAR(20)  NOT NULL,
	FOREIGN KEY  (IDUnit) REFERENCES dbo.UnitCategory (ID)
)

CREATE TABLE Food
(
	ID INT PRIMARY KEY IDENTITY(0,1),
	Name NVARCHAR(100) NOT NULL,
	IDFoodCategory int NOT NULL,
	Price MONEY NOT NULL DEFAULT(0),
	FOREIGN KEY (IDFoodCategory) REFERENCES dbo.FoodCategory(ID)
)

CREATE TABLE FTable
(
	ID VARCHAR(20) PRIMARY KEY,
	Name NVARCHAR(50)  NOT NULL,
	Hall NVARCHAR(100)  NOT NULL,
	Status BIT DEFAULT(0) -- 0 là trống, 1 là bận
)
GO

CREATE TABLE Bill
(
	ID INT PRIMARY KEY IDENTITY(0,1),
	DateCheckIn DATE DEFAULT(GETDATE()),
	HourCheckIn TIME NOT NULL,
	HourCheckOut TIME  NOT NULL,
	IdTable VARCHAR(20)  NOT NULL,
	Status TINYINT  DEFAULT(0),-- 0: đang nhập bill, 1: đã IN, 2: đang thanh toán 
	IdStaff INT  NOT NULL,
	FOREIGN KEY (IdStaff) REFERENCES dbo.Account(ID),
	FOREIGN KEY (IdTable) REFERENCES dbo.FTable (Id),
)
GO

-------------- INSERT DATA ------------------
-- Account
INSERT INTO dbo.Account
(ID,Name,DisplayName,Password,Office)
VALUES (777,N'Phạm Hồng Mạnh',N'FamManh','21091997',N'Admin')

INSERT INTO dbo.Account
(ID,Name,DisplayName,Password,Office)
VALUES (555,N'Staff',N'Staff','123456',N'Waiter')

INSERT INTO dbo.Account
(ID,Name,DisplayName,Password,Office)
VALUES (007,N'Phạm Xuân Linh',N'FamLinh','123456',N'Waiter')

SELECT * FROM dbo.Account

-- UnitCategory
INSERT INTO dbo.UnitCategory VALUES ('BAR',N'Quầy Bar')
INSERT INTO dbo.UnitCategory VALUES ('KITCHEN',N'Bếp')

SELECT * FROM dbo.UnitCategory


-- Food Category
INSERT INTO dbo.FoodCategory VALUES (N'Nước có gas','BAR')
INSERT INTO dbo.FoodCategory VALUES (N'Nước không gas','BAR')
INSERT INTO dbo.FoodCategory VALUES (N'Bia','BAR')
INSERT INTO dbo.FoodCategory VALUES (N'Rượu vang có cồn','BAR')
INSERT INTO dbo.FoodCategory VALUES (N'Rượu vang không cồn','BAR')

SELECT * FROM dbo.FoodCategory

-- Food
INSERT INTO dbo.Food VALUES ( N'Coca cola',0, 20000)
INSERT INTO dbo.Food VALUES ( N'Sprite',0, 20000)
INSERT INTO dbo.Food VALUES ( N'Marinda',0, 20000)

SELECT * FROM dbo.Food
SELECT Name FROM dbo.Food






------------- USP ------------
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE DisplayName = @userName
END
GO

EXEC USP_GetAccountByUserName @userName = N'Fammanh'
GO

CREATE PROC USP_Login
@userName nvarchar(100), @password varchar(30)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE DisplayName = @userName AND Password = @password
END
go
--dbo.USP_Login @userName , @password

CREATE PROC USP_LoginStaff
@PinCode INT 
AS
BEGIN
	SELECT * FROM dbo.Account WHERE ID = @PinCode
END
GO

CREATE PROC USP_GetNameStaff
@PinCode int
AS
BEGIN
	SELECT Name FROM dbo.Account WHERE ID = @PinCode
END
GO
