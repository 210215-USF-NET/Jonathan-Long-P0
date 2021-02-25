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
	PhoneNumber varchar(10) not null
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
	ProductName varchar(20) not null,
	Price decimal not null,
	[Description] varchar(50) not null
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