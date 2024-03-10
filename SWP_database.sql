USE [master]
GO
CREATE DATABASE [SWP] 
GO
USE [SWP]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Admin's ID] [nvarchar](50) NOT NULL,
	[Admin's mail] [nvarchar](50) NOT NULL,
	[Admin's password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Admin's ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C_R]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_R](
	[Quotation ID] [nvarchar](10) NOT NULL,
	[Request ID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK] PRIMARY KEY CLUSTERED 
(
	[Request ID] ASC,
	[Quotation ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Construction price quotation]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Construction price quotation](
	[Quotation ID] [nvarchar](10) NOT NULL,
	[Product] [nvarchar](100) NULL,
	[House's type] [nvarchar](100) NULL,
	[Status] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Payment] [nvarchar](100) NULL,
	[Advise] [nvarchar](200) NULL,
	[Customer comment] [nvarchar](200) NULL,
	[Staff Id] [nvarchar](10) NOT NULL,
	[Request Id] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Construction price quotation] PRIMARY KEY CLUSTERED 
(
	[Quotation ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Construction received]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Construction received](
	[Construction received ID] [nvarchar](10) NOT NULL,
	[House's type] [nvarchar](100) NULL,
	[Date] [date] NULL,
	[Price] [float] NULL,
	[Status] [int] NOT NULL,
	[Quotation ID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Construction received_1] PRIMARY KEY CLUSTERED 
(
	[Quotation ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer's Id] [nvarchar](5) NOT NULL,
	[Customer email] [nvarchar](100) NULL,
	[Customer's name] [nvarchar](50) NOT NULL,
	[Login name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone number] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer's Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Link Image]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Link Image](
	[Link Id] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[Post Id] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Link Image] PRIMARY KEY CLUSTERED 
(
	[Link Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Post's ID] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Date] [date] NULL,
	[Staff Id] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Post's ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Request ID] [nvarchar](10) NOT NULL,
	[House's type] [nvarchar](100) NOT NULL,
	[Size] [float] NULL,
	[Theme] [nvarchar](100) NOT NULL,
	[Date] [date] NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Customer Id] [nvarchar](5) NOT NULL,
	[CustomerPhone] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Request ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REQUEST_THEME]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REQUEST_THEME](
	[ThemeId] [nvarchar](10) NOT NULL,
	[Request_ID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_R_T] PRIMARY KEY CLUSTERED 
(
	[ThemeId] ASC,
	[Request_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Staff's ID] [nvarchar](10) NOT NULL,
	[Staff's name] [nvarchar](50) NOT NULL,
	[Staff's email] [nvarchar](50) NOT NULL,
	[Staff password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Staff's ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theme_Table]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theme_Table](
	[Theme] [nvarchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[ThemeId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED 
(
	[ThemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type of house]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type of house](
	[Type name] [nvarchar](100) NOT NULL,
	[Price] [float] NULL,
	[TypeId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Type of house] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Request]    Script Date: 3/10/2024 9:00:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Request](
	[RequestId] [nvarchar](10) NOT NULL,
	[TypeId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Type_Request] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC,
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'1', N'admin@gmail.com', N'admin123456')
GO
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'2', N'me@gmail.com', N'3')
GO
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Product], [House's type], [Status], [Price], [Payment], [Advise], [Customer comment], [Staff Id], [Request Id]) VALUES (N'1', N'Nội thất', N'Nhà phố', 1, 5000000000, N'Tiền mặt', N'Không có lời khuyên gì', N'Không có lời bình gì ở đây', N'1', N'1')
GO
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Product], [House's type], [Status], [Price], [Payment], [Advise], [Customer comment], [Staff Id], [Request Id]) VALUES (N'2', N'Nội thất', N'Nhà phố', 1, 3000000000, N'Chuyển khoản', N'Không có lời khuyên gì', N'Không có lời bình gì ở đây', N'1', N'2')
GO
INSERT [dbo].[Construction received] ([Construction received ID], [House's type], [Date], [Price], [Status], [Quotation ID]) VALUES (N'1', N'Nhà lầu', CAST(N'2025-01-01' AS Date), 5000000, 1, N'1')
GO
INSERT [dbo].[Customer] ([Customer's Id], [Customer email], [Customer's name], [Login name], [Password], [Phone number]) VALUES (N'1', N'nhat@gmail.com', N'Tran Nhat', N'trannhat', N'nhat123', N'0987654321')
GO
INSERT [dbo].[Post] ([Post's ID], [Description], [Date], [Staff Id]) VALUES (N'1', N'Nhà mặt phố', CAST(N'2024-12-12' AS Date), N'1')
GO
INSERT [dbo].[Post] ([Post's ID], [Description], [Date], [Staff Id]) VALUES (N'3', N'Test', CAST(N'2024-02-23' AS Date), N'1')
GO
INSERT [dbo].[Request] ([Request ID], [House's type], [Size], [Theme], [Date], [Status], [Description], [Customer Id], [CustomerPhone]) VALUES (N'1', N'Nhà lầu', 2000, N'Cổ điển', NULL, 1, N'khong co gi', N'1', N'09123456789')
GO
INSERT [dbo].[Request] ([Request ID], [House's type], [Size], [Theme], [Date], [Status], [Description], [Customer Id], [CustomerPhone]) VALUES (N'2', N'Nhà Phố', 1000, N'Hiện đại', NULL, 1, NULL, N'1', N'09876543212')
GO
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'1', N'Nguyễn Tri Phương', N'phuong@gmail.com', N'phuong123')
GO
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'2', N'Nguyễn Bỉnh Khiêm', N'khiem@gmail.com', N'khiem123')
GO
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'3', N'haha', N'@gamil', N'1')
GO
ALTER TABLE [dbo].[C_R]  WITH CHECK ADD  CONSTRAINT [FK_C_R_Construction price quotation1] FOREIGN KEY([Quotation ID])
REFERENCES [dbo].[Construction price quotation] ([Quotation ID])
GO
ALTER TABLE [dbo].[C_R] CHECK CONSTRAINT [FK_C_R_Construction price quotation1]
GO
ALTER TABLE [dbo].[C_R]  WITH CHECK ADD  CONSTRAINT [FK_C_R_Request] FOREIGN KEY([Request ID])
REFERENCES [dbo].[Request] ([Request ID])
GO
ALTER TABLE [dbo].[C_R] CHECK CONSTRAINT [FK_C_R_Request]
GO
ALTER TABLE [dbo].[Construction price quotation]  WITH CHECK ADD  CONSTRAINT [FK_Construction price quotation_Staff] FOREIGN KEY([Staff Id])
REFERENCES [dbo].[Staff] ([Staff's ID])
GO
ALTER TABLE [dbo].[Construction price quotation] CHECK CONSTRAINT [FK_Construction price quotation_Staff]
GO
ALTER TABLE [dbo].[Construction received]  WITH CHECK ADD  CONSTRAINT [FK_Construction received_Construction price quotation] FOREIGN KEY([Quotation ID])
REFERENCES [dbo].[Construction price quotation] ([Quotation ID])
GO
ALTER TABLE [dbo].[Construction received] CHECK CONSTRAINT [FK_Construction received_Construction price quotation]
GO
ALTER TABLE [dbo].[Link Image]  WITH CHECK ADD  CONSTRAINT [FK_Link Image_Post] FOREIGN KEY([Post Id])
REFERENCES [dbo].[Post] ([Post's ID])
GO
ALTER TABLE [dbo].[Link Image] CHECK CONSTRAINT [FK_Link Image_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Staff] FOREIGN KEY([Staff Id])
REFERENCES [dbo].[Staff] ([Staff's ID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Staff]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Customer] FOREIGN KEY([Customer Id])
REFERENCES [dbo].[Customer] ([Customer's Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Customer]
GO
ALTER TABLE [dbo].[REQUEST_THEME]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_THEME_Request] FOREIGN KEY([Request_ID])
REFERENCES [dbo].[Request] ([Request ID])
GO
ALTER TABLE [dbo].[REQUEST_THEME] CHECK CONSTRAINT [FK_REQUEST_THEME_Request]
GO
ALTER TABLE [dbo].[REQUEST_THEME]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_THEME_Theme_Table] FOREIGN KEY([ThemeId])
REFERENCES [dbo].[Theme_Table] ([ThemeId])
GO
ALTER TABLE [dbo].[REQUEST_THEME] CHECK CONSTRAINT [FK_REQUEST_THEME_Theme_Table]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([Request ID])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Request]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Type of house] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type of house] ([TypeId])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Type of house]
GO
