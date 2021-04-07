--database name
use Sprint1
Go

---drop queries---

drop table Admin
Go
drop table Shipping
Go
drop table OrderIngredient
Go
drop table CartRepository
Go
drop table Cart
Go
drop table Ingredient
Go
drop table Recipe
Go
drop table Customer
Go

------------------------------
--Admin table
CREATE TABLE Admin
( 
	AdminId int Primary Key identity(1, 1),
	UserName Varchar(50) Unique NOT NULL,
	Password Varchar(30) NOT NULL,
	SecurityQuestion Varchar(100) NOT NULL,
	SecurityAnswer Varchar(100) NOT NULL
);

--Customer table
create table Customer  
(
	CustomerId Int primary key identity(1, 1),
	Name Varchar(50) Not null,
	Email Varchar(100) Unique Not null,
	MobileNumber Varchar(13) Unique Not null,
	UserName Varchar(50) Unique Not null,
	Password Varchar(50) Not null,
	Address Varchar(100) Not null, 
);

--Recipe table
create table Recipe
(
	RecipeId int primary key identity(1, 1),
	Name Varchar(50) not null,
	Description Varchar(300)
);

--Ingredient table
create table Ingredient
(
	IngredientId int primary key identity(1, 1),
	Name Varchar(50) not null,
	RecipeId int references Recipe(RecipeId),
	ManufacturerName varchar(70),
	ManufacturerDate Datetime,
	Price decimal(18,2),
	ExpiryDate Datetime,
	Description Text not null
);

--Cart table
create table Cart
(
	CartId int primary key identity(1, 1),
	CustomerID int references Customer(CustomerId),
	IngredientID int references Ingredient(IngredientId) on delete cascade on update cascade,
	IngredientQuantity decimal(18,2),
	Amount decimal(18,2)
);
--alter table query to add check constraint
alter table Cart
add Check(IngredientQuantity >= 1);

--CartRepository table
create table CartRepository
(
	CartId int primary key identity(1, 1),
	CustomerID int references Customer(CustomerId),
	IngredientID int references Ingredient(IngredientId) on delete cascade on update cascade  ,
	IngredientQuantity decimal(18,2),
	Amount decimal(18,2)
);

--OrderIngredient Table
create table OrderIngredient
(
	OrderId int PRIMARY KEY identity(1, 1),
	CustomerId int FOREIGN KEY REFERENCES Customer(CustomerId),
	DateOfOrder datetime not null,
	MobileNumber varchar(20) not null,
	DeliveryAddress varchar(100),
	TotalBillAmount decimal(18,2),
	NoOfIngredients int,
	GrandTotal decimal(18,2)
);

--Shipping table
create table Shipping
(
	ShippingNumber int PRIMARY KEY identity(1, 1),
	OrderId int FOREIGN KEY REFERENCES OrderIngredient(OrderId) not null,
	ExpectedDeliveryDate datetime not null
);

--select queries for all tables
select * from Admin
Go
select * from Shipping
Go
select * from OrderIngredient
Go
select * from Cart
Go
select * from CartRepository
Go
select * from Ingredient
Go
select * from Recipe
Go
select * from Customer
Go


------ STORED PROCEDURE FOR ADMIN-------------------------------------->
------------------------------------------------------------------------>
-- Login for Admin

--query to create procedure 
create procedure LoginAdmin
(
	@username varchar(50),
	@password varchar(15)
)
as 
BEGIN
	--username and password parameter value should match with database values
	select UserName, Password from Admin where UserName = @username and Password = @password 
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------


-- Forgot passord for Admin

--query to create procedure 
create procedure ForgotPasswordAdmin
(
	@username varchar(50) 
)
as 
BEGIN
	--username parameter value should match with database value
	select * from Admin where UserName = @username 
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- Change passord for Admin

--query to create procedure 

create procedure ChangePasswordAdminusing
(
	@username varchar(50) output,
	@password varchar(30) output,
	@securityquestion Varchar(100) output, 
	@securityanswer Varchar(100) output
)
as 
BEGIN
	--set changed password
	update Admin set Password = @password where UserName = @username and SecurityQuestion=@securityquestion and  SecurityAnswer=@securityanswer;
END
Go

---------------------------------**********************************--------------------------------------------
-----------------------------------------INSERT PROCEDURES FOR ADMIN-------------------------------------------

-- INSERT PROCEDURE for Admin

--query to create procedure 
create procedure AddAdmin
(
	@username varchar(50),
	@password varchar(30),
	@securityquestion varchar(100),
	@securityanswer varchar(100)
)
as 
BEGIN
	--insert values into Admin table
	insert into Admin (UserName, Password, SecurityQuestion, SecurityAnswer) 
	values (@username, @password, @securityquestion, @securityanswer);
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- INSERT PROCEDURE for Recipe

--query to create procedure 
create procedure AddRecipe
(
	@name varchar(50),
	@description varchar(300)
)
as 
BEGIN
	--insert values into Recipe table
	insert into Recipe  
	values (@name, @description);
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- INSERT PROCEDURE for Ingredient

--query to create procedure 
create procedure AddIngredient
(
	
	@name varchar(50),
	@recipeid int,
	@manufacturername varchar(70),
	@manufacturerdate datetime,
	@price decimal(18, 2),
	@expirydate datetime,
	@description text
)
as 
BEGIN

	--insert values into Ingredient table
	insert into Ingredient (Name, RecipeId, ManufacturerName, ManufacturerDate, Price, ExpiryDate, Description) 
	values ( @name, @recipeid, @manufacturername, @manufacturerdate, @price, @expirydate, @description);

END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------DELETE PROCEDURES-------------------------------------------
--Delete Recipe
create procedure DeleteRecipe
(
	@recipeId int
)
as
	delete Recipe where RecipeId = @recipeId

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Delete ingredient

create procedure DeleteIngredient
(
	@ingredientid int
)
as 
BEGIN

	--delete values from Ingredient table
	delete from Ingredient where IngredientId = @ingredientid;

END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------UPDATE PROCEDURES-------------------------------------------

--Update Recipe
create procedure UpdateRecipe
(   
	@recipeId int,
	@name varchar(50),
	@description varchar(300)
)
as 

	update Recipe set name = @Name, description = @description where RecipeId = @recipeId


----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Update Ingredient
create procedure UpdateIngredient
(
	@name varchar(50),
	@ingredientid int,
	@recipeid int,
	@manufacturername varchar(70),
	@manufacturerdate datetime,
	@price decimal(18, 2),
	@expirydate datetime,
	@description text
)
AS
BEGIN

	--update values from Ingredient table
	update Ingredient set Name= @name , RecipeId = @recipeid, ManufacturerName = @manufacturername, ManufacturerDate= @manufacturerdate, Price = @price, ExpiryDate= @expirydate, Description=@description
	where IngredientId= @ingredientid ;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Update Shipping details
create procedure  AdminShippingDetailsUpdate
(   
	@shippingNumber int,
	@ExpectedDeliveryDate datetime
)
as 
BEGIN
	update  Shipping set  ExpectedDeliveryDate = @ExpectedDeliveryDate where ShippingNumber = @shippingNumber

END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------SEARCH PROCEDURES-------------------------------------------

--Search Recipes
create procedure SearchRecipe
(
	@recipeId int 
	
)
as
	select  recipeid, name, description from Recipe where  RecipeId = @recipeId 

Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Search Ingredient
create procedure SearchIngredient
(
	@ingredientid int
)
as
BEGIN
select IngredientId, Name, RecipeId, ManufacturerName, ManufacturerDate,Price, ExpiryDate, Description  from Ingredient where IngredientId = @ingredientid 
END

---------------------------------**********************************-------------------------------------------
-----------------------------------------VIEW OR GET PROCEDURES-------------------------------------------
--Get Recipe
create procedure GetRecipe
as
select * from Recipe

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Get Ingredient
create procedure GetIngredient
as
select * from Ingredient

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Admin order details
create procedure AdminOrderManager
as 
select * from OrderIngredient
go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--View Shipping details to Admin

create procedure AdminViewShippingDetails
as
BEGIN
	select * from  Shipping ;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

----------------------------------------------------------------------------
----------------------------------------------------------------------------

------ STORED PROCEDURE FOR CUSTOMER-------------------------------------->
------------------------------------------------------------------------>
-- Login for Customer

--query to create procedure 
create procedure LoginCustomer
(
	@username varchar(50),
	@password varchar(15)
)
as 
BEGIN
	--username and password parameter value should match with database values
	select UserName, Password from Customer where UserName = @username and Password = @password 
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--query to create procedure 

create procedure ForgotPasswordCustomer
(
	@username varchar(50) 
)
as 
BEGIN
	--username parameter value should match with database value
	select * from Customer where UserName = @username 
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- Change passord for Customer

--query to create procedure 
create procedure ChangePasswordCustomer
(
	@username varchar(50) output,
	@password varchar(30) output,
	@mobilenumber  varchar(15) output
)
as 
BEGIN
	--set changed password
	update Customer set Password = @password where UserName = @username and MobileNumber=@mobilenumber
END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------INSERT PROCEDURES FOR CUSTOMER-------------------------------------------

-- INSERT PROCEDURE for Customer

--query to create procedure 
create procedure AddCustomer
(
	@name varchar(50),
	@email varchar(100),
	@mobilenumber varchar(13),
	@username varchar(50),
	@password varchar(50),
	@address varchar(100)
)
as 
BEGIN
	--insert values into customer table
	insert into Customer (Name, Email, MobileNumber, UserName, Password, Address) 
	values (@name, @email, @mobilenumber, @username, @password, @address);
END
Go


----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- INSERT PROCEDURE for AddToCart

--query to create procedure 
create procedure AddToCart
(
	@username varchar(50),
	@CustomerID int out,
	@IngredientID int,
	@IngredientQuantity decimal(18, 2),
	@amount decimal(18, 2) 
)
as 
BEGIN
	select @CustomerID = CustomerID from Customer where username = @username;
	
	--insert values into Cart table
	insert into Cart (CustomerID, IngredientID, IngredientQuantity, Amount) 
	values (@CustomerID, @IngredientID, @IngredientQuantity, @amount);

	insert into CartRepository (CustomerID, IngredientID, IngredientQuantity, Amount) 
	values (@CustomerID, @IngredientID, @IngredientQuantity, @amount);
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- INSERT PROCEDURE for Order

--query to create procedure 
create proc PlaceOrder
(
	@username varchar(50),
	@MobileNumber varchar(20),
	@DeliveryAddress varchar(100),
	@TotalBillAmount decimal(18, 2),
	@GrandTotal decimal(18, 2) 
)
as
BEGIN
	declare @CustomerID int;
	select @CustomerID = CustomerID from Customer where username = @username;

	declare @DateOfOrder datetime;
	set @DateOfOrder = getdate();

	declare @NoOfIngredients int;
	select @NoOfIngredients = count(IngredientID) from Cart where CustomerID = @CustomerID; 
	
	--declare @DateOfOrder int;

	insert into  OrderIngredient 
	values( @CustomerID, @DateOfOrder, 
	@MobileNumber, @DeliveryAddress, 
	@TotalBillAmount, @NoOfIngredients, @GrandTotal);

	delete from cart where CustomerID = @CustomerID;

	declare @id int;
	set @id = @@identity;

	declare @expected_date date;
	set @expected_date = dateadd(DD, 5, getdate()); 

	insert into shipping(OrderId, ExpectedDeliveryDate) values (@id, @expected_date);
END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------VIEW PROCEDURES-------------------------------------------
--View ingredients

--create procedure
create proc ViewAllIngredients
(
	@id int
)
as
BEGIN
	select * from Ingredient where RecipeId = @id;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--View Recipes

--create procedure
create proc GetAllRecipes
as
BEGIN
	select * from Recipe;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--View Recipes

--create procedure
create proc ViewAllRecipes
(
	@recipeid int
)
as
BEGIN
	select * from Recipe where RecipeId = @recipeid;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--Customer Carts

--create procedure
create proc CustomerCarts1
(
	@username varchar(50)
)
as
BEGIN
	declare @CustomerID int;
	select @CustomerID = CustomerID from Customer where username = @username;

	select * from Cart where CustomerID = @CustomerID;
END
Go
----------------------------------------------------------------------------
----------------------------------------------------------------------------

--View Carts

--create procedure
create proc ViewMyCarts
(
	@username varchar(50)
)
as
BEGIN
	select c.CartId 'Cart Id', ing.Name 'Ingredient Name', c.IngredientQuantity 'Ingredient Quantity',ing.Price 'Price', c.Amount 'Amount'
	from Cart c inner join Ingredient ing on ing.IngredientId = c.IngredientID 
	inner join Customer cust on cust.CustomerId = c.CustomerID and cust.UserName = @username;
END
Go

----------------------------------------------------------------------------
----------------------------------------------------------------------------

--View Shipping details to Customer

--create procedure
create proc ViewShippingDetails
(
	@username varchar(30)
)
as
BEGIN
	declare @CustomerID int;
	select @CustomerID = CustomerID from Customer where username = @username;

	select top 1 ShippingNumber, OrderId, ExpectedDeliveryDate from Shipping 
	where orderid in (select orderid from OrderIngredient where customerid = @CustomerID)
	order by ShippingNumber desc;
END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------UPDATE PROCEDURES-------------------------------------------

--Update Cart

--create procedure
create proc UpdateCart
(
	@cartid int,
	@quantity decimal(18, 2),
	@amount decimal(18, 2)
)
as 
BEGIN
	update Cart set IngredientQuantity = @quantity, Amount = @amount where CartId = @cartid;
	update CartRepository set IngredientQuantity = @quantity, Amount = @amount where CartId = @cartid;
END
Go

---------------------------------**********************************-------------------------------------------
-----------------------------------------DELETE PROCEDURES-------------------------------------------

--Delete Cart

--create procedure
create proc DeleteCart
(
	@cartid int
)
as 
BEGIN
	delete from Cart where CartId = @cartid;
	delete from CartRepository where CartId = @cartid;
END
Go

---------------------------------**********************************-------------------------------------------
---------------------------------**********************************-------------------------------------------





