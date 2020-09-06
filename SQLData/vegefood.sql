create database VegeFood
go
use VegeFood
go

create table Users(
    Id int IDENTITY(1, 1) primary key,
    Name nvarchar(100) not null,
	Username nvarchar(100) not null,
    Password nvarchar(200) not null,
	Image nvarchar(200),
    Birthday datetime,
    Sex varchar(10) not null,
    Phone varchar(50) not null,
    Address nvarchar(50) not null,
	Type nvarchar(10) not null,
	CreateAt datetime not null,
	UpdateAt datetime not null,
	LastLogin datetime not null,
    Node nvarchar(100),
	Status nvarchar(10) not null
)

create table Category(
    Id int IDENTITY(1, 1) primary key,
	Type nvarchar(50) not null,
	Description nvarchar(100),
	Node nvarchar(100)
)

create table Products(
    Id int IDENTITY(1, 1) primary key,
	CategoryId int not null,
	Name nvarchar(50) not null,
	Image nvarchar(100) not null,
	Amount int not null,
	Price int not null,
	Sale int not null,
	Description nvarchar(100),
	Status nvarchar(10)
)

