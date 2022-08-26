CREATE DATABASE [TodoMinimal]
GO

USE [TodoMinimal];
GO

CREATE TABLE [dbo].[TODO](
	[TodoId] [nvarchar](36) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Done] [bit] NOT NULL,
	[LimitDate] [datetime2](7) NOT NULL,
	[Priority] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[TODO] ADD  CONSTRAINT [PK_TODO] PRIMARY KEY CLUSTERED 
(
	[TodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

