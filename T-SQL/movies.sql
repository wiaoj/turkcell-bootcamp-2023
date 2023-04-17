USE [IMDBCLONE]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 17.04.2023 20:32:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](250) NOT NULL,
	[Description] [nvarchar](350) NULL,
	[Year] [int] NULL,
	[Rating] [float] NULL,
	[IsWatched] [bit] NULL,
	[DirectorId] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
GO

ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Directors]
GO


