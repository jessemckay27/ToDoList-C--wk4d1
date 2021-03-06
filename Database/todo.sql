USE [todo]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 12/13/2016 10:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tasks]    Script Date: 12/13/2016 10:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tasks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[category_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id], [name]) VALUES (1, N'chores')
INSERT [dbo].[categories] ([id], [name]) VALUES (2, N'hobbies')
SET IDENTITY_INSERT [dbo].[categories] OFF
