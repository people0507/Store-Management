Create database QuanliSanPhamSieuThi
go
Create table Account
	(
	UserName Nvarchar(100) not null,
	Name Nvarchar(100) not null,
	PassWord Nvarchar(1000) not null,
	Role nvarchar(50),
	Born nvarchar(50),
	Sex nvarchar(50),
	Birth Date,
	Contact nvarchar(50),
	)
go

INSERT INTO Account (UserName, Name, PassWord, Role, Born, Sex, Birth, Contact)
VALUES      (N'admin', N'Nguyễn Đăng Nhân', N'1', N'admin', N'Hà Nội', N'Nam', CONVERT(DATETIME, '2002-07-05 00:00:00', 102), N'0999999999')
INSERT INTO Account (UserName, Name, PassWord, Role, Born, Sex, Birth, Contact)
VALUES      (N'staff', N'Hoàng Minh Hùng', N'2', N'staff', N'Hà Nội', N'Nam', CONVERT(DATETIME, '2002-11-22 00:00:00', 102), N'0999999999')

INSERT INTO Account (UserName, Name, PassWord, Role, Born, Sex, Birth, Contact)
VALUES      (N'staff1', N'Nguyễn Hữu Huy', N'3', N'staff1', N'Hà Nội', N'Nam', CONVERT(DATETIME, '2002-08-26 00:00:00', 102), N'0999999999')




CREATE TABLE ListOfProduct
(
	id INT PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO
INSERT INTO ListOfProduct(id, name) 
VALUES(1, N'Bánh')
INSERT INTO ListOfProduct(id, name) 
VALUES(2, N'Rau')
INSERT INTO ListOfProduct(id, name) 
VALUES(3, N'Trái Cây')
INSERT INTO ListOfProduct(id, name) 
VALUES(4, N'Đồ chơi')
INSERT INTO ListOfProduct(id, name) 
VALUES(5, N'Thịt')
INSERT INTO ListOfProduct(id, name) 
VALUES(6, N'Hải Sản')
INSERT INTO ListOfProduct(id, name) 
VALUES(7, N'Mỹ Phẩm')
INSERT INTO ListOfProduct(id, name) 
VALUES(8, N'Kẹo')
INSERT INTO ListOfProduct(id, name) 
VALUES(9, N'Gia vị')
INSERT INTO ListOfProduct(id, name) 
VALUES(10, N'Lương thực')
INSERT INTO ListOfProduct(id, name) 
VALUES(11, N'Đồ Ăn Vặt')
INSERT INTO ListOfProduct(id, name) 
VALUES(12, N'Đồ Uống')
INSERT INTO ListOfProduct(id, name) 
VALUES(13, N'Đồ Gia Dụng')
INSERT INTO ListOfProduct(id, name) 
VALUES(14, N'Văn Phòng Phẩm')






CREATE TABLE Products
(
	idPr INT PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	id INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	amount INT NOT NULL,
	
	FOREIGN KEY (idPr) REFERENCES dbo.ListOfProduct(id)
)
GO

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(1, N'Bánh Ngọt', 1, 10000, 50)
INSERT INTO Products(idPr, name, id, price, amount)
VALUES(2, N'Bánh Mì Ruốc', 1, 8000, 40)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(3, N'Cá Thu', 6, 100000, 30)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(4, N'Bắp Cải', 2, 7000, 20)
INSERT INTO Products(idPr, name, id, price, amount)
VALUES(5, N'Rau Ngót', 2, 8000, 20)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(6, N'Táo Mĩ', 3, 10000, 40)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(7, N'Thịt Lợn', 5, 30000, 35)
INSERT INTO Products(idPr, name, id, price, amount)
VALUES(8, N'Thịt Bò', 5, 40000, 40)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(9, N'Kẹo Socola', 8, 150000, 25)

INSERT INTO Products(idPr, name, id, price, amount)
VALUES(10, N'CoCa', 12, 8000, 50)
INSERT INTO Products(idPr, name, id, price, amount)
VALUES(11, N'Nước Cam', 12, 7000, 45)




Create table Bill4
(
	idBill int identity primary key,
	nameKH nvarchar(100) not null,
	namePr nvarchar(100) not null,
	price float not null,
	amount float not null,
	ngaymua date
)
go

Create table Statistic
(
	nameKH nvarchar(100) not null,
	sumBill float not null,
	ngaymua date
)
go




