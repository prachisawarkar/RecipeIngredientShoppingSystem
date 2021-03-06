USE [master]
GO
/****** Object:  Database [Sprint1]    Script Date: 04-04-2021 22:50:31 ******/
CREATE DATABASE [Sprint1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sprint1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Sprint1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sprint1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Sprint1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sprint1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sprint1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sprint1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sprint1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sprint1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sprint1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sprint1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sprint1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sprint1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sprint1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sprint1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sprint1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sprint1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sprint1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sprint1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sprint1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sprint1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sprint1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sprint1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sprint1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sprint1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sprint1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sprint1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sprint1] SET RECOVERY FULL 
GO
ALTER DATABASE [Sprint1] SET  MULTI_USER 
GO
ALTER DATABASE [Sprint1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sprint1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sprint1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sprint1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sprint1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sprint1', N'ON'
GO
USE [Sprint1]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 04-04-2021 22:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[SecurityQuestion] [varchar](100) NOT NULL,
	[SecurityAnswer] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[IngredientID] [int] NULL,
	[IngredientQuantity] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartRepository]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartRepository](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[IngredientID] [int] NULL,
	[IngredientQuantity] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[MobileNumber] [varchar](13) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredient](
	[IngredientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[RecipeId] [int] NULL,
	[ManufacturerName] [varchar](70) NULL,
	[ManufacturerDate] [datetime] NULL,
	[Price] [decimal](18, 2) NULL,
	[ExpiryDate] [datetime] NULL,
	[Description] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderIngredient](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[DateOfOrder] [datetime] NOT NULL,
	[MobileNumber] [varchar](20) NOT NULL,
	[DeliveryAddress] [varchar](100) NULL,
	[TotalBillAmount] [decimal](18, 2) NULL,
	[NoOfIngredients] [int] NULL,
	[GrandTotal] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipe](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shipping]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipping](
	[ShippingNumber] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ExpectedDeliveryDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ShippingNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredient] ([IngredientId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartRepository]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CartRepository]  WITH CHECK ADD FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredient] ([IngredientId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([RecipeId])
GO
ALTER TABLE [dbo].[OrderIngredient]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Shipping]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderIngredient] ([OrderId])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD CHECK  (([IngredientQuantity]>=(1)))
GO
/****** Object:  StoredProcedure [dbo].[AddAdmin]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddAdmin]
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

GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddCustomer]
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

GO
/****** Object:  StoredProcedure [dbo].[AddIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddIngredient]
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

GO
/****** Object:  StoredProcedure [dbo].[AddRecipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- INSERT PROCEDURE for Recipe

--query to create procedure 
create procedure [dbo].[AddRecipe]
(
	@name varchar(50),
	@description varchar(300)
)
as 
BEGIN

	--insert values into Recipe table
	insert into Recipe (Name, Description) 
	values (@name, @description);

END

GO
/****** Object:  StoredProcedure [dbo].[AddToCart]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddToCart]
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

GO
/****** Object:  StoredProcedure [dbo].[AdminOrderManager]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AdminOrderManager]
as 
select * from OrderIngredient

GO
/****** Object:  StoredProcedure [dbo].[AdminShippingDetailsUpdate]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[AdminShippingDetailsUpdate]
(   @shippingNumber int,
	
	@ExpectedDeliveryDate datetime
)
as 
BEGIN
	update  Shipping set  ExpectedDeliveryDate = @ExpectedDeliveryDate where ShippingNumber = @shippingNumber

END

GO
/****** Object:  StoredProcedure [dbo].[AdminViewShippingDetails]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AdminViewShippingDetails]
as
BEGIN
	select * from  Shipping ;
END

GO
/****** Object:  StoredProcedure [dbo].[ChangePasswordAdmin]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------

-- Change passord for Admin

--query to create procedure 
create procedure [dbo].[ChangePasswordAdmin]
(
	@username varchar(50) output,
	@password varchar(30) output
)
as 
BEGIN
	--set changed password
	update Admin set Password = @password where UserName = @username
END

GO
/****** Object:  StoredProcedure [dbo].[ChangePasswordAdminusing]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChangePasswordAdminusing]
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

GO
/****** Object:  StoredProcedure [dbo].[ChangePasswordCustomer]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChangePasswordCustomer]
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

GO
/****** Object:  StoredProcedure [dbo].[CustomerCarts1]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CustomerCarts1]
(
	@username varchar(50)
)
as
BEGIN
	declare @CustomerID int;
	select @CustomerID = CustomerID from Customer where username = @username;

	select * from Cart where CustomerID = @CustomerID;
END
--s
GO
/****** Object:  StoredProcedure [dbo].[DeleteCart]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteCart]
(
	@cartid int
)
as 
BEGIN
	delete from Cart where CartId = @cartid;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteIngredient]
(
	@ingredientid int
)
as 
BEGIN

	--delete values from Ingredient table
	delete from Ingredient where IngredientId = @ingredientid;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteRecipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteRecipe]
(
	@recipeId int
)
as
	delete Recipe where RecipeId = @recipeId

GO
/****** Object:  StoredProcedure [dbo].[ForgotPasswordAdmin]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ForgotPasswordAdmin]
(
	@username varchar(50) 
)
as 
BEGIN
	--username parameter value should match with database value
	select * from Admin where UserName = @username 
END

GO
/****** Object:  StoredProcedure [dbo].[ForgotPasswordCustomer]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ForgotPasswordCustomer]
(
	@username varchar(50) 
)
as 
BEGIN
	--username parameter value should match with database value
	select * from Customer where UserName = @username 
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllRecipes]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllRecipes]
as
BEGIN
	select * from Recipe;
END

GO
/****** Object:  StoredProcedure [dbo].[GetIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetIngredient]
as
select * from Ingredient

GO
/****** Object:  StoredProcedure [dbo].[GetRecipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetRecipe]
as
select * from Recipe
GO
/****** Object:  StoredProcedure [dbo].[LoginAdmin]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoginAdmin]
(
	@username varchar(50),
	@password varchar(15)
)
as 
BEGIN
	--username and password parameter value should match with database values
	select UserName, Password from Admin where UserName = @username and Password = @password 
END

GO
/****** Object:  StoredProcedure [dbo].[LoginCustomer]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoginCustomer]
(
	@username varchar(50),
	@password varchar(15)
)
as 
BEGIN
	--username and password parameter value should match with database values
	select UserName, Password from Customer where UserName = @username and Password = @password 
END

GO
/****** Object:  StoredProcedure [dbo].[PlaceOrder]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PlaceOrder]
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

GO
/****** Object:  StoredProcedure [dbo].[SearchIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SearchIngredient]
(
	@ingredientid int
)
as
BEGIN
select IngredientId, Name, RecipeId, ManufacturerName, ManufacturerDate,Price, ExpiryDate, Description  from Ingredient where IngredientId = @ingredientid 
END
GO
/****** Object:  StoredProcedure [dbo].[SearchRecipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SearchRecipe]
(
	@recipeId int 
	
)
as
	select  recipeid, name, description from Recipe where  RecipeId = @recipeId 


GO
/****** Object:  StoredProcedure [dbo].[UpdateCart]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCart]
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

GO
/****** Object:  StoredProcedure [dbo].[UpdateIngredient]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateIngredient]
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

GO
/****** Object:  StoredProcedure [dbo].[UpdateRecipe]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateRecipe]
(   
	@recipeId int,
	@name varchar(50),
	@description varchar(300)
)
as 

	update Recipe set name = @Name, description = @description where RecipeId = @recipeId
GO
/****** Object:  StoredProcedure [dbo].[ViewAllIngredients]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ViewAllIngredients]
(
	@id int
)
as
BEGIN
	select * from Ingredient where RecipeId = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[ViewAllRecipes]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ViewAllRecipes]
(
	@recipeid int
)
as
BEGIN
	select * from Recipe where RecipeId = @recipeid;
END

GO
/****** Object:  StoredProcedure [dbo].[ViewMyCarts]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ViewMyCarts]
(
	@username varchar(50)
)
as
BEGIN
	select c.CartId 'Cart Id', ing.Name 'Ingredient Name', c.IngredientQuantity 'Ingredient Quantity',ing.Price 'Price', c.Amount 'Amount'
	from Cart c inner join Ingredient ing on ing.IngredientId = c.IngredientID 
	inner join Customer cust on cust.CustomerId = c.CustomerID and cust.UserName = @username;
END

GO
/****** Object:  StoredProcedure [dbo].[ViewShippingDetails]    Script Date: 04-04-2021 22:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ViewShippingDetails]
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

GO
USE [master]
GO
ALTER DATABASE [Sprint1] SET  READ_WRITE 
GO
