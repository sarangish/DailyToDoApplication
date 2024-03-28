# ToDoApplication - Database structure to create in MS Sql Sever

CREATE TABLE [dbo].[ToDoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[IsComplete] [bit] NOT NULL,
	[TimeLeft] [time](7) NULL,
 CONSTRAINT [PK_ToDoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
