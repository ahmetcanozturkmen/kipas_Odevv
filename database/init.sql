IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PersonnelDb')
BEGIN
    CREATE DATABASE PersonnelDb;
END
GO

USE PersonnelDb;
GO


IF OBJECT_ID('dbo.Personel', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Personel;
END
GO

CREATE TABLE Personel (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    Title NVARCHAR(20) NULL,

    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,

    BirthDate DATE NULL,

    Position NVARCHAR(100) NULL,

    HireDate DATE NULL,

    State NVARCHAR(50) NULL,
    Address NVARCHAR(250) NULL,

    Notes NVARCHAR(1000) NULL,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO

INSERT INTO Personel
(Title, FirstName, LastName, BirthDate, Position, HireDate, State, Address, Notes)
VALUES
('Mr.', 'Ahmet', 'Yılmaz', '1995-03-12', 'Yazılım', '2022-06-01', 'Gaziantep', 'Şahinbey', 'Çalışıyor.'),
('Ms.', 'Ayşe', 'Demir', '1992-11-05', 'Mühendis', '2021-04-15', 'İstanbul', 'Kadıköy', 'Çalışıyor '),
('Mrs.', 'Elif', 'Kaya', '1988-07-22', 'Satış Danışmanı', '2019-09-10', 'Ankara', 'Çankaya', 'İşe alım sürecinde');
GO
