/* 
 * SQL Server Script
 * 
 * In a local environment (for example, with the SQLServerExpress instance 
 * included in the VStudio installation) it will be necessary to create the 
 * database and the user required by the connection string. So, the following
 * steps are needed:
 *
 *     Configure the @Default_DB_Path variable with the path where 
 *     database and log files will be created  
 *
 * This script can be executed from MS Sql Server Management Studio Express,
 * but also it is possible to use a command Line syntax:
 *
 *    > sqlcmd.exe -U [user] -P [password] -I -i SqlServerCreateTables.sql
 *
 */


 /******************************************************************************/
 /*** PATH to store the db files. This path must exists in the local system. ***/
 /******************************************************************************/
 DECLARE @Default_DB_Path as VARCHAR(64)  
 SET @Default_DB_Path = N'C:\SourceCode\DataBase\'
 
USE [master]


/***** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'ecommerce')
DROP DATABASE [ecommerce]


USE [master]


/* DataBase Creation */

								  
DECLARE @sql nvarchar(500)

SET @sql = 
  N'CREATE DATABASE [ecommerce] 
	ON PRIMARY ( NAME = ecommerce, FILENAME = "' + @Default_DB_Path + N'ecommerce.mdf")
	LOG ON ( NAME = ecommerce_log, FILENAME = "' + @Default_DB_Path + N'ecommerce_log.ldf")'

EXEC(@sql)
PRINT N'eCommerce Database created.'
GO

/* 
 * Drop tables.                                                             
 * NOTE: before dropping a table (when re-executing the script), the tables 
 * having columns acting as foreign keys of the table to be dropped must be 
 * dropped first (otherwise, the corresponding checks on those tables could 
 * not be done).                                                            
 */

USE ecommerce

/* Drop Table CommentTag if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[CommentTag]') 
AND type in ('U')) DROP TABLE [CommentTag]
GO

/* Drop Table Tag if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Tag]') 
AND type in ('U')) DROP TABLE [Tag]
GO

/* Drop Table Comment if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Comment]') 
AND type in ('U')) DROP TABLE [Comment]
GO

/* Drop Table OrderItem if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[OrderItem]') 
AND type in ('U')) DROP TABLE [OrderItem]
GO

/* Drop Table Music if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Music]') 
AND type in ('U')) DROP TABLE [Music]
GO

/* Drop Table Book if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Book]') 
AND type in ('U')) DROP TABLE [Book]
GO

/* Drop Table Movie if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Movie]') 
AND type in ('U')) DROP TABLE [Movie]
GO

/* Drop Table Product if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Product]') 
AND type in ('U')) DROP TABLE [Product]
GO

/* Drop Table Category if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Category]') 
AND type in ('U')) DROP TABLE [Category]
GO

/* Drop Table Order if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Order]') 
AND type in ('U')) DROP TABLE [Order]
GO

/* Drop Table Credit Card if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[CreditCard]') 
AND type in ('U')) DROP TABLE [CreditCard]
GO

/* Drop Table User if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[User]') 
AND type in ('U')) DROP TABLE [User]
GO

/*
 * Create tables.
 */

/* User */

CREATE TABLE [User] (
	userId bigint IDENTITY(1,1) NOT NULL,
	login varchar(30) NOT NULL,
	password varchar(64) NOT NULL,
	name varchar(30) NOT NULL,
	surnames varchar(60) NOT NULL,
	postalAddress varchar(60) NOT NULL,
	email varchar(40) NOT NULL,

	CONSTRAINT [PK_User] PRIMARY KEY (userId ASC)
)

PRINT N'Table User created.'
GO

/* Credit Card */

CREATE TABLE CreditCard (
	creditCardId bigint IDENTITY(1,1) NOT NULL, 
	userId bigint NOT NULL,
	type varchar(10) NOT NULL,
	number bigint NOT NULL,
	verifyCode smallint NOT NULL, 
	expDate date NOT NULL,
	isFav bit NOT NULL, /* Boolean */
	
	CONSTRAINT [PK_CreditCard] PRIMARY KEY (creditCardId ASC),
	
	CONSTRAINT [FK_CreditCardUserId] FOREIGN KEY(userId)
		REFERENCES [User] (userId) ON DELETE CASCADE
)

CREATE NONCLUSTERED INDEX IX_FK_CreditCardIndexByUserId
ON creditCard (userId);

PRINT N'Table CreditCard created.'
GO

/* Order */

CREATE TABLE [Order] (
	orderId bigint IDENTITY(1,1) NOT NULL, 
	userId bigint NOT NULL,
	creditCardId bigint NOT NULL,
	address varchar(50) NOT NULL,
	orderDate date NOT NULL,
	price float NOT NULL,
	
	CONSTRAINT [PK_Order] PRIMARY KEY (orderId ASC),
	
	CONSTRAINT [FK_OrderUserId] FOREIGN KEY(userId)
		REFERENCES [User] (userId) ON DELETE CASCADE,
	CONSTRAINT [FK_OrderCreditCardId] FOREIGN KEY(creditCardId)
		REFERENCES [CreditCard] (creditCardId)
)

CREATE NONCLUSTERED INDEX IX_FK_OrderIndexByUserId
ON [Order] (userId);

PRINT N'Table Order created.'
GO

/* Category */

CREATE TABLE Category (
	categoryId bigint IDENTITY(1,1) NOT NULL,
	visualName varchar(30) NOT NULL,
	
	CONSTRAINT [PK_Category] PRIMARY KEY (categoryId ASC),
)

PRINT N'Table Category created.'
GO

/* Product */

CREATE TABLE Product (
	productId bigint IDENTITY(1,1) NOT NULL,
	categoryId bigint DEFAULT NULL,
	name varchar(40) NOT NULL,
	unitPrice float NOT NULL,
	productDate date NOT NULL,
	stockUnits int NOT NULL,
	type varchar(30),
	
	CONSTRAINT [PK_Product] PRIMARY KEY (productId ASC),
	
	CONSTRAINT [FK_ProductCategoryId] FOREIGN KEY(categoryId)
		REFERENCES Category (categoryId) ON DELETE CASCADE
)

CREATE NONCLUSTERED INDEX IX_FK_ProductIndexByCategoryId
ON Product (categoryId);

PRINT N'Table Product created.'
GO

/* Movie */

CREATE TABLE Movie (
	productId bigint NOT NULL,
	director varchar(40) NOT NULL,
	movieDate date NOT NULL,
	
	CONSTRAINT [PK_Movie] PRIMARY KEY (productId ASC),
	
	CONSTRAINT [FK_MovieProductId] FOREIGN KEY(productId)
		REFERENCES Product (productId) ON DELETE CASCADE
)

PRINT N'Table Movie created.'
GO

/* Book */

CREATE TABLE Book (
	productId bigint NOT NULL,
	isbn varchar(13) NOT NULL,
	editionNumber int NOT NULL,
	author varchar(40) NOT NULL,
	
	CONSTRAINT [PK_Book] PRIMARY KEY (productId ASC),
	
	CONSTRAINT [FK_BookProductId] FOREIGN KEY(productId)
		REFERENCES Product (productId) ON DELETE CASCADE
)

PRINT N'Table Book created.'
GO

/* Music */

CREATE TABLE Music (
	productId bigint NOT NULL,
	album varchar(25) NOT NULL,
	artist varchar(40) NOT NULL,
	
	CONSTRAINT [PK_Music] PRIMARY KEY (productId ASC),
	
	CONSTRAINT [FK_MusicProductId] FOREIGN KEY(productId)
		REFERENCES Product (productId) ON DELETE CASCADE
)

PRINT N'Table Music created.'
GO

/* Order Item */

CREATE TABLE OrderItem (
	orderItemId bigint IDENTITY(1,1) NOT NULL, 
	productId bigint NOT NULL,
	orderId bigint NOT NULL,
	units int NOT NULL,
	unitPrice float NOT NULL,
	
	CONSTRAINT [PK_OrderItem] PRIMARY KEY (orderItemId ASC),
	
	CONSTRAINT [FK_OrderItemProductId] FOREIGN KEY(productId)
		REFERENCES Product (productId) ON DELETE CASCADE,

	CONSTRAINT [FK_OrderItemOrderId] FOREIGN KEY(orderId)
		REFERENCES [Order] (orderId) ON DELETE CASCADE
)

CREATE NONCLUSTERED INDEX IX_FK_OrderItemIndexByOrderId
ON OrderItem (orderId);

PRINT N'Table Order Item created.'
GO

/* Comment */

CREATE TABLE Comment  (
	commentId bigint IDENTITY(1,1) NOT NULL,
	userId bigint NOT NULL,
	productId bigint NOT NULL,
	body varchar(100) NOT NULL,
	commentDate date NOT NULL,
	
	CONSTRAINT [PK_Comment] PRIMARY KEY (commentId ASC),
	
	CONSTRAINT [FK_CommentProductId] FOREIGN KEY(productId)
		REFERENCES Product (productId) ON DELETE CASCADE,

	CONSTRAINT [FK_CommentUserId] FOREIGN KEY(userId)
		REFERENCES [User] (userId) ON DELETE CASCADE
)

PRINT N'Table Comment created.'
GO

/* Tag */

CREATE TABLE Tag  (
	tagId bigint IDENTITY(1,1) NOT NULL,
	name varchar(20),
	
	CONSTRAINT [PK_Tag] PRIMARY KEY (tagId ASC)
)

PRINT N'Table Tag created.'
GO

/* Comment Tag */

CREATE TABLE CommentTag  (
	commentId bigint NOT NULL,
	tagId bigint NOT NULL,
	
	CONSTRAINT [PK_CommentTag] PRIMARY KEY (commentId ASC, tagId ASC),
	
	CONSTRAINT [FK_CommentTagCommentId] FOREIGN KEY(commentId)
		REFERENCES Comment (commentId) ON DELETE CASCADE,

	CONSTRAINT [FK_CommentTagId] FOREIGN KEY(tagId)
		REFERENCES Tag (tagId) ON DELETE CASCADE
)

PRINT N'Table Comment Tag created.'
GO

PRINT N'Done'