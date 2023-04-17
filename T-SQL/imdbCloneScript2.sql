USE master
CREATE DATABASE imdbClone2
GO --sonraki komuttan devam et demek
USE imdbClone2
CREATE TABLE Actors(
	Id int IDENTITY(1,1) NOT NULL,
	[NAME] nvarchar(50) NOT NULL,
	SURNAME nvarchar(50) NOT NULL
)
GO
ALTER TABLE Actors
ADD CONSTRAINT PK_Actors
PRIMARY KEY(Id)


GO
Create TABLE Movies(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NAME] nvarchar(50) NOT NULL,
)
GO
CREATE TABLE MoviesActors(
	MovieId int NOT NULL,
	ActorId int NOT NULL,
	[Role] varchar(50) NULL --varsayýlan deðer NULL'dýr
)
GO
ALTER TABLE MoviesActors
ADD CONSTRAINT PK_Movies_Actors 
PRIMARY KEY(MovieId,ActorId)
GO
ALTER TABLE MoviesActors
ADD CONSTRAINT FK_Movie_Actor
FOREIGN KEY (MovieId)
REFERENCES Movies(Id)

ALTER TABLE MoviesActors
ADD CONSTRAINT FK_Actor_Movie
FOREIGN KEY (ActorId)
REFERENCES Actors(Id)


DROP DATABASE imdbClone2