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
 
USE ecommerce

/* Populate User */

/* User Admin*/
INSERT INTO  [User] (login, password, name, surnames, postalAddress, email, language, country)
VALUES ('admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', 'Admin', 'Admin', 'Admin', 'admin@admin.com', 'es', 'ES');

/* Populate Credit Card */

/* Credit Card 1 */
INSERT INTO CreditCard (userId, type, number, verifyCode, expDate, isFav)
VALUES (1, 'VISA', 999999999999, 999, '27/03/2022', 1);

/* Credit Card 1 */
INSERT INTO CreditCard (userId, type, number, verifyCode, expDate, isFav)
VALUES (1, 'Master', 111111111111, 111, '02/11/2023', 1);

/* Populate sCategory */

INSERT INTO Category (visualName)
VALUES ('New');

INSERT INTO Category (visualName)
VALUES ('Sale');

/* Populate Products */

/* Product 1 Music */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'Energize', 9.99, CURRENT_TIMESTAMP, 10, 'Music');

INSERT INTO Music (productId, album, artist)
VALUES (1, 'Basiel EP', 'Amelie Lens');

/* Product 2 Music */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (1, 'Slay3r', 12.99, CURRENT_TIMESTAMP, 50, 'Music');

INSERT INTO Music (productId, album, artist)
VALUES (2, 'Whole Lotta Red', 'Playboi Carti');

/* Product 3 Movie */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (1, 'Tenet', 19.99, CURRENT_TIMESTAMP, 10, 'Movie');

INSERT INTO Movie (productId, director, movieDate)
VALUES (3, 'Christopher Nolan', '26/08/2020');

/* Product 4 Book */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, '1984', 8.99, CURRENT_TIMESTAMP, 5, 'Book');

INSERT INTO Book (productId, isbn, editionNumber, author)
VALUES (4, '01234567890', 5, 'George Orwell');

/* Product 5 Book */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'I, Robot', 7.99, CURRENT_TIMESTAMP, 8, 'Book');

INSERT INTO Book (productId, isbn, editionNumber, author)
VALUES (5, '09876543210', 5, 'Isaac Asimov');

/* Product 6 Book */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'The Girl With The Dragon Tattoo', 7.99, CURRENT_TIMESTAMP, 8, 'Book');

INSERT INTO Book (productId, isbn, editionNumber, author)
VALUES (6, '09753124680', 5, 'Stieg Larsson');

/* Product 7 Movie */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'A Clockwork Orange', 29.99, CURRENT_TIMESTAMP, 10, 'Movie');

INSERT INTO Movie (productId, director, movieDate)
VALUES (7, 'Stanley Kubrick', '16/06/1975');

/* Product 8 Movie */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'The Virgin Suicides', 9.99, CURRENT_TIMESTAMP, 10, 'Movie');

INSERT INTO Movie (productId, director, movieDate)
VALUES (8, 'Sofia Coppola', '05/05/2000');

/* Product 9 Movie */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'Antichrist', 9.99, CURRENT_TIMESTAMP, 10, 'Movie');

INSERT INTO Movie (productId, director, movieDate)
VALUES (9, 'Lars von Trier', '21/08/2009');

/* Product 10 Music */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (1, '20 M', 9.99, CURRENT_TIMESTAMP, 50, 'Music');

INSERT INTO Music (productId, album, artist)
VALUES (10, '#TBT', 'yen5k');

/* Product 11 Music */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (1, 'Hero of My Story 3style3',199.99, CURRENT_TIMESTAMP, 50, 'Music');

INSERT INTO Music (productId, album, artist)
VALUES (11, '333', 'Bladee');

/* Product 12 Music */
INSERT INTO Product (categoryId, name, unitPrice, productDate, stockUnits, type)
VALUES (2, 'Bohemian Rhapsody', 14.99, CURRENT_TIMESTAMP, 50, 'Music');

INSERT INTO Music (productId, album, artist)
VALUES (12, 'A Night At The Opera', 'Queen');


