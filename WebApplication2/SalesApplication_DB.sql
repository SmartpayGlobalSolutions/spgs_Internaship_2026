CREATE DATABASE SalesApplication
GO

CREATE TABLE Users (
userId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
userName VARCHAR(50) NOT NULL UNIQUE,
firstName VARCHAR(50) NULL,
lastName VARCHAR(50) NULL,
emailAddress VARCHAR(50) NOT NULL UNIQUE,
[password] NVARCHAR(20) NOT NULL,
refDate DATETIME DEFAULT getdate(),
[status] TINYINT DEFAULT 1 
)
GO

INSERT INTO Users (userName,firstName,lastName,emailAddress,password)
VALUES ('Rauf','Abdul','Rauf','abdul.rauf@smartpaygs.com','123123')
GO

SELECT * FROM Users
GO

