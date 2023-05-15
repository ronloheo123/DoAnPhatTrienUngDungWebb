Create database WebsiteBanHang
Use WebsiteBanHang

Create Table Brand
(
	Id int identity(1,1) Primary Key,
	Name nvarchar(100),
	Avatar nvarchar(100),
	Slug varchar(100),
	ShowOnHomePage bit,
	DisplayOder int,
	CreatedOnUtc datetime,
	UpdatedOnUtc datetime,
	Deleted bit 
)
INSERT INTO Brand VALUES
('Apple','apple.jpg','apple',1,1,NULL,NULL,0),
('SamSung','samsung.jpg','samsung',1,2,NULL,NULL,0),
('Xiaomi','xiaomi.jpg','xiaomi',1,3,NULL,NULL,0)

Create Table Category
(
	Id int identity(1,1) Primary Key,
	Name nvarchar(100),
	Avatar nchar(100),
	Slug varchar(100),
	ShowOnHomePage bit,
	DisplayOder int,
	Deleted bit,
	CreatedOnUtc datetime,
	UpdateOnUtc datetime
)
INSERT INTO Category VALUES
(N'Điện Thoại','Phone.jpg','dien-thoai',1,1,0,NUll,NULL),
(N'Máy Tính','Latop.jpg','may-tinh',1,2,0,NULL,NULL),
(N'Máy Tính Bảng','Ipad.jpg','may-tinh-bang',1,3,0,NULL,NULL),
(N'Phụ Kiện','PhuKien.jpg','phu-kien',1,4,0,NULL,NULL),
(N'Đông Hồ Thông Minh','donghothongminh.jpg','dong-ho-thong-minh',1,5,0,NULL,NULL),
(N'Đồng Hồ Thời Trang','donghothoitrang.jpg','dong-ho-thoi-trang',1,6,0,NULL,NULL)

Create Table Orders
(
	Id int identity(1,1) Primary Key,
	Name nvarchar(100),
	ProductId int,
	Price float,
	Status int,
	CreatedOnUtc datetime
)


Create Table Product
(
	Id int identity(1,1) Primary Key,
	Name nvarchar(100),
	Avatar nchar(100),
	CategoryId int,
	ShortDes nvarchar(100),
	FullDescription nvarchar(500),
	Price float,
	PriceDiscount float,
	TypeId int,
	Slug varchar(50),
	BrandId int,
	Deleted bit,
	ShowOnHomePage bit,
	DisplayOrder int,
	CreatedOnUtc datetime,
	UpdatedOnUtc datetime,
)
INSERT INTO Product VALUES
('Iphone 6','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('Iphone 7','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('Iphone 8','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('Iphone 10','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('Iphone 11','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('SamSung 1','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('SamSung 2','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('SamSung 3','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL),
('SamSung 4','iphone12.jpg',1,N'mô tả ngắn',N'mô tả dài',6000000,5000000,1,'iphone6',1,0,1,1,NULL,NULL)
UPDATE Product
SET BrandId = '2'
WHERE ID = 7;






DELETE FROM Product WHERE Id=1;

Create Table Users
(
	Id int identity(1,1) Primary Key,
	FristName varchar(50),
	LastName varchar(50),
	Email varchar(50),
	Password varchar(50),
	IsAdmin bit
)