--Drop Statements--
drop table ItemLocation;
drop table ProductOrder;
drop table [Order];
drop table Item;
drop table Product;
drop table [Location];
drop table Customer;

--Create Table Statements--
create table Customer
(
	CustID int identity(0,1) primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	PhoneNumber varchar(12) not null
);
create table [Location]
(
	LocationID int identity(0,1) primary key,
	[Address] varchar(50) not null,
	[State] varchar(2) not null,
	[LocationName] varchar(50) not null
);
create table Product
(
	ProductID int identity(0,1) primary key,
	ProductName varchar(50) not null,
	Price decimal not null,
	[Description] varchar(100) not null
);
create table Item
(
	ItemID int identity(0,1) primary key,
	Quantity int not null,
	ProductID int Foreign Key(ProductID) References Product(ProductID) not null,
	LocationID int Foreign Key(LocationID) References [Location](LocationID) not null,
);
create table [Order]
(
	OrderID int identity(0,1) primary key,
	Total decimal not null,
	[Date] datetime not null,
	CustID int foreign key(CustID) references Customer(CustID),
	LocationID int foreign key(LocationID) references Location(LocationID)
);
create table ProductOrder
(
	ProductID int not null,
	OrderID int not null,
	Quantity int not null,
	Constraint ProductOrderPK Primary Key(ProductID, OrderID),
	Constraint ProductOrderFK1 foreign key(ProductID) references Product(ProductID),
	Constraint ProductOrderFK2 foreign key(OrderID) references [Order](OrderID)
);
create table ItemLocation
(
	ItemID int not null,
	LocationID int not null,
	Constraint ItemLocationPK primary key(ItemID, LocationID),
	Constraint ItemLocationFK1 foreign key(ItemID) references Item(ItemID),
	Constraint ItemLocationFK2 foreign key(LocationID) references [Location](LocationID)
);
--Insert Statements--
insert into Product values ('Atomic Bent Chetler 120 Skis', 749.99, 'Top quality powder skis that are light, versatile, and perfectly conceived');
insert into Product values ('Rosingol Twin Tip Skis', 549.99, 'Amazing twin tip skis that are perfect for intermediate/expert riders');
insert into Product values ('Black Crows Justis Skis', 959.90, 'Provide all mountain excellence in a sturdy, directional frame');
insert into Product values ('Nordica Promachine 130 Ski Boots', 749.99, 'High performance boots that do not feel like meat grinders.');
insert into Product values ('Rossingol Evo 70 Ski Boots', 219.95, 'Built with comfort and focused features for smooth ride');

insert into [Location] values ('123 Ski Way', 'VA', 'Ski Virginia');
insert into [Location] values ('52 Mountain Rd', 'VT', 'Sugarbush');

insert into Item values (20, 0, 0);
insert into Item values (15, 1, 0);
insert into Item values (20, 2, 0);
insert into Item values (25, 3, 0);
insert into Item values (10, 4, 0);

insert into Item values (18, 0, 1);
insert into Item values (20, 1, 1);
insert into Item values (20, 3, 1);

Select Product.ProductName, Item.Quantity from Product inner join Item On Product.ProductID = Item.ProductID Where Item.LocationID = 0;

Select * From Customer;
Select * From [Location];
Select * From [Order];
Select * From ProductOrder;
Select * From Product;
Select * From Item;

