use VegeFood

insert into Users(Name, Age, Username, Password, Image, Birthday, Email, Sex, Phone, Address, Type, CreateAt, UpdateAt, LastLogin, Node, Status)
values (N'Pham Hong Phuc', 21, N'username1', 'f553cae45493a747aaf42114f0478ed1336cae5d0001ad370627b4bcde115732', N'/wwwroot/images/user/person_1.jpg', '1999-12-04', N'phamhongphuc@gmail.com', 'male', '123456789', N'Hai Duong', 'admin', GETDATE(), GETDATE(), GETDATE(), null, N'enable'),
       (N'Nguyen Hong Phuc', 20, N'username2', 'f553cae45493a747aaf42114f0478ed1336cae5d0001ad370627b4bcde115732', N'/wwwroot/images/user/person_2.jpg', '2000-01-01', N'nguyenhongphuc@gmail.com', 'male', '987654321', N'Thanh Hoa', 'user', GETDATE(), GETDATE(), GETDATE(), null, N'enable'),
	   (N'Truong Hong Phuc', 30, N'username3', 'f553cae45493a747aaf42114f0478ed1336cae5d0001ad370627b4bcde115732', N'/wwwroot/images/user/person_3.jpg', '1990-03-04', N'truonghongphuc@gmail.com', 'male', '135798642', N'Ha Noi', 'user', GETDATE(), GETDATE(), GETDATE(), null, N'enable'),
	   (N'Vu Hong Phuc', 40, N'username4', 'f553cae45493a747aaf42114f0478ed1336cae5d0001ad370627b4bcde115732', N'wwwroot/images/user/person_4.jpg', '1980-04-05', N'vuhongphuc@gmail.com', 'male', '112233447', N'Hoa Binh', 'user', GETDATE(), GETDATE(), GETDATE(), null, N'enalbe')

insert into Category(Type, Description, Node)
values (N'fruits', null, null),
       (N'juices', null, null),
	   (N'vegetable', null, null),
	   (N'dried', null, null)

insert into Products(CategoryId, Name, Image, Amount, Price, Sale, Description, Status)
values (1, N'product1', N'/wwwroot/images/product/product-1.jpg', 100, 100000, 10, null, 'enable'),
       (2, N'product2', N'/wwwroot/images/product/product-2.jpg', 150, 250000, 5, null, 'enable'),
	   (3, N'product3', N'/wwwroot/images/product/product-3.jpg', 20, 300000, 20, null, 'enable'),
       (4, N'product4', N'/wwwroot/images/product/product-4.jpg', 40, 2500000, 30, null, 'enable'),
	   (1, N'product5', N'/wwwroot/images/product/product-5.jpg', 300, 1000000, 40, null, 'enable'),
       (2, N'product6', N'/wwwroot/images/product/product-6.jpg', 150, 250000, 15, null, 'enable'),
	   (3, N'product7', N'/wwwroot/images/product/product-7.jpg', 100, 100000, 10, null, 'enable'),
       (4, N'product8', N'/wwwroot/images/product/product-8.jpg', 150, 250000, 5, null, 'enable'),
	   (1, N'product9', N'/wwwroot/images/product/product-9.jpg', 100, 100000, 10, null, 'enable')
