USE [TirCache]


SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


CREATE TABLE [dbo].PointsOfInterest(
	[Id] INT NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Longitude] [nvarchar](max) NOT NULL,
	[Latitude] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Zipcode] [nvarchar](max) NOT NULL,
	[Town] [nvarchar](max) NOT NULL,
	PRIMARY KEY( Id ));