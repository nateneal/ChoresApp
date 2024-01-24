IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Chore')
   BEGIN
   CREATE DATABASE [Chore]
END

USE [Chore]

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name='Chores' and xtype ='U')
BEGIN
    CREATE TABLE Chores(
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name VARCHAR(64)
    )
END
    