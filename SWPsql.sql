use master
go
create database [SWP]
go
USE [SWP]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/28/2024 11:21:20 AM ******/
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
/****** Object:  Table [dbo].[Construction price quotation]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Construction price quotation](
	[Quotation ID] [nvarchar](10) NOT NULL,
	[Status] [int] NOT NULL,
	[Staff Id] [nvarchar](10) NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[phoneNumber] [nvarchar](12) NOT NULL,
	[projectAddress] [nvarchar](100) NOT NULL,
	[quotationDate] [date] NOT NULL,
	[CustomerId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Construction price quotation] PRIMARY KEY CLUSTERED 
(
	[Quotation ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Construction received]    Script Date: 3/28/2024 11:21:20 AM ******/
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
/****** Object:  Table [dbo].[Cus_Con]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cus_Con](
	[CustomerId] [nvarchar](10) NOT NULL,
	[QuotationId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Customer_QuotationId] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[QuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer's Id] [nvarchar](10) NOT NULL,
	[Customer email] [nvarchar](100) NULL,
	[Customer's name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone number] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer's Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Post's ID] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Date] [date] NULL,
	[Staff Id] [nvarchar](10) NOT NULL,
	[imgLink] [nvarchar](max) NULL,
	[title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Post's ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostDetail]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostDetail](
	[PostDetailId] [nvarchar](10) NOT NULL,
	[Details] [nvarchar](300) NULL,
	[postId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PostDetail] PRIMARY KEY CLUSTERED 
(
	[PostDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostImg]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostImg](
	[Link Id] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[PostId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Link Image] PRIMARY KEY CLUSTERED 
(
	[Link Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Request ID] [nvarchar](10) NOT NULL,
	[House's type] [nvarchar](100) NOT NULL,
	[Size] [float] NULL,
	[Unit] [nvarchar](100) NOT NULL,
	[QuotationId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Request ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REQUEST_UNIT]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REQUEST_UNIT](
	[UnitId] [nvarchar](10) NOT NULL,
	[Request_ID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_R_T] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC,
	[Request_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/28/2024 11:21:20 AM ******/
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
/****** Object:  Table [dbo].[Type of house]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type of house](
	[TypeId] [nvarchar](10) NOT NULL,
	[Type name] [nvarchar](100) NOT NULL,
	[PriceEstimateCaculateType] [float] NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Type of house] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Request]    Script Date: 3/28/2024 11:21:20 AM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 3/28/2024 11:21:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [nvarchar](10) NOT NULL,
	[Unit] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'1', N'admin@gmail.com', N'admin123456')
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'2', N'me@gmail.com', N'3')
GO
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Status], [Staff Id], [customerName], [phoneNumber], [projectAddress], [quotationDate], [CustomerId]) VALUES (N'1', 1, N'1', N'Thu Hằng', N'099999999999', N'Phố Mã', CAST(N'2023-12-12' AS Date), N'1')
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Status], [Staff Id], [customerName], [phoneNumber], [projectAddress], [quotationDate], [CustomerId]) VALUES (N'2', 1, N'1', N'Ngân Kim', N'098888888888', N'Phố Hàng', CAST(N'2023-01-12' AS Date), N'1994')
GO
INSERT [dbo].[Construction received] ([Construction received ID], [House's type], [Date], [Price], [Status], [Quotation ID]) VALUES (N'1', N'Nhà lầu', CAST(N'2025-01-01' AS Date), 5000000, 1, N'1')
GO
INSERT [dbo].[Customer] ([Customer's Id], [Customer email], [Customer's name], [Password], [Phone number]) VALUES (N'1', N'nhat@gmail.com', N'Tran Nhat', N'nhat123', N'0987654321')
INSERT [dbo].[Customer] ([Customer's Id], [Customer email], [Customer's name], [Password], [Phone number]) VALUES (N'1994', N'hong', N'hong@gmail.com', N'hong123', N'')
INSERT [dbo].[Customer] ([Customer's Id], [Customer email], [Customer's name], [Password], [Phone number]) VALUES (N'5105', N'hung@gmail.com', N'Tran Hung', N'hung123', N'0999999999')
GO
INSERT [dbo].[Post] ([Post's ID], [Description], [Date], [Staff Id], [imgLink], [title]) VALUES (N'1', N'Nhà mặt phố', CAST(N'2024-12-12' AS Date), N'1', NULL, N'Nhà phố')
INSERT [dbo].[Post] ([Post's ID], [Description], [Date], [Staff Id], [imgLink], [title]) VALUES (N'3', N'des', CAST(N'2024-03-13' AS Date), N'1', NULL, N'Des')
GO
INSERT [dbo].[PostImg] ([Link Id], [Link], [PostId]) VALUES (N'1', N'/images', N'1')
INSERT [dbo].[PostImg] ([Link Id], [Link], [PostId]) VALUES (N'2', N'/images', N'1')
GO
INSERT [dbo].[Request] ([Request ID], [House's type], [Size], [Unit], [QuotationId]) VALUES (N'1', N'Nhà lầu', 2000, N'Cổ điển', N'1')
INSERT [dbo].[Request] ([Request ID], [House's type], [Size], [Unit], [QuotationId]) VALUES (N'2', N'Nhà Phố', 1000, N'Hiện đại', N'1')
GO
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'1', N'Nguyễn Tri Phương', N'phuong@gmail.com', N'phuong123')
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'2', N'Nguyễn Bỉnh Khiêm', N'khiem@gmail.com', N'khiem123')
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'3', N'huaw', N'kingen@gmail.com', N'kingmen')
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
ALTER TABLE [dbo].[Cus_Con]  WITH CHECK ADD  CONSTRAINT [FK_Cus_Con_Construction price quotation] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[Construction price quotation] ([Quotation ID])
GO
ALTER TABLE [dbo].[Cus_Con] CHECK CONSTRAINT [FK_Cus_Con_Construction price quotation]
GO
ALTER TABLE [dbo].[Cus_Con]  WITH CHECK ADD  CONSTRAINT [FK_Cus_Con_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Customer's Id])
GO
ALTER TABLE [dbo].[Cus_Con] CHECK CONSTRAINT [FK_Cus_Con_Customer]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Staff] FOREIGN KEY([Staff Id])
REFERENCES [dbo].[Staff] ([Staff's ID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Staff]
GO
ALTER TABLE [dbo].[PostDetail]  WITH CHECK ADD  CONSTRAINT [FK_PostDetail_Post] FOREIGN KEY([postId])
REFERENCES [dbo].[Post] ([Post's ID])
GO
ALTER TABLE [dbo].[PostDetail] CHECK CONSTRAINT [FK_PostDetail_Post]
GO
ALTER TABLE [dbo].[PostImg]  WITH CHECK ADD  CONSTRAINT [FK_Link Image_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Post's ID])
GO
ALTER TABLE [dbo].[PostImg] CHECK CONSTRAINT [FK_Link Image_Post]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Construction price quotation] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[Construction price quotation] ([Quotation ID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Construction price quotation]
GO
ALTER TABLE [dbo].[REQUEST_UNIT]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_UNIT_Request] FOREIGN KEY([Request_ID])
REFERENCES [dbo].[Request] ([Request ID])
GO
ALTER TABLE [dbo].[REQUEST_UNIT] CHECK CONSTRAINT [FK_REQUEST_UNIT_Request]
GO
ALTER TABLE [dbo].[REQUEST_UNIT]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_UNIT_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[REQUEST_UNIT] CHECK CONSTRAINT [FK_REQUEST_UNIT_Unit]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Request1] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([Request ID])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Request1]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Type of house] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type of house] ([TypeId])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Type of house]
GO
