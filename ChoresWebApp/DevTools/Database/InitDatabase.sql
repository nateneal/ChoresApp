IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Chore')
   BEGIN
   CREATE DATABASE [Chore]
END
GO

USE [Chore]
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name='Chores' and xtype ='U')
BEGIN
    CREATE TABLE Chores(
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name VARCHAR(64)
    )
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id=OBJECT_ID(N'[dbo].[Chores]') AND name='Description')
BEGIN
    ALTER TABLE Chores
    ADD Description VARCHAR(200)
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id=OBJECT_ID(N'[dbo].[Chores]') AND name='IsDeleted')
BEGIN
    ALTER TABLE Chores
    ADD IsDeleted bit
END
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name='Schedules' and xtype ='U')
    BEGIN
        CREATE TABLE Schedules(Id INT PRIMARY KEY IDENTITY (1, 1),
                               ChoreId INT FOREIGN KEY REFERENCES Chores(Id),
                               Begins DATETIME,
                               Ends DATETIME,
                               CronExpression NVARCHAR(200)
        )
    END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id=OBJECT_ID(N'[dbo].[Schedules]') AND name='IsDeleted')
    BEGIN
        ALTER TABLE Schedules
            ADD IsDeleted bit
    END
GO

IF NOT EXISTS (SELECT * FROM Chores)
BEGIN
    INSERT INTO Chores (Name, IsDeleted)
    VALUES ('Init Chore', 0)
END
GO