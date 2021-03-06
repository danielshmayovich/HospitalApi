
USE [Hospital]
GO
/****** Object:  Table [dbo].[SickPeople]    Script Date: 21/09/2016 20:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SickPeople](
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IsFemale] [bit] NOT NULL,
	[WardId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wards]    Script Date: 21/09/2016 20:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wards](
	[Id] [int] IDENTITY(1234,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[InChargePerson] [nvarchar](50) NOT NULL,
	[ManagerPerson] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Wards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SickPeople]  WITH CHECK ADD  CONSTRAINT [FK_SickPeople_Wards] FOREIGN KEY([WardId])
REFERENCES [dbo].[Wards] ([Id])
GO
ALTER TABLE [dbo].[SickPeople] CHECK CONSTRAINT [FK_SickPeople_Wards]
GO
USE [master]
GO
ALTER DATABASE [Hospital] SET  READ_WRITE 
GO
