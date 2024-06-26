use master
go
create database [SWP]
go
USE [SWP]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[comboDesign]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comboDesign](
	[ComboId] [nvarchar](10) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
	[Describe] [nvarchar](200) NULL,
	[unit_price] [float] NULL,
 CONSTRAINT [PK_comboDesign] PRIMARY KEY CLUSTERED 
(
	[ComboId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Construction price quotation]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Construction price quotation](
	[Quotation ID] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Construction received]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[Cus_Con]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[houseTypeOption]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[houseTypeOption](
	[houseTypeId] [nvarchar](10) NOT NULL,
	[houseType] [nvarchar](100) NULL,
	[houseTypePrice] [float] NULL,
	[comboDesignId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_houseTypeOption] PRIMARY KEY CLUSTERED 
(
	[houseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[PostDetail]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[PostImg]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[Req_Com]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Req_Com](
	[RequestId] [nvarchar](50) NOT NULL,
	[ComboId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Request_Combo] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC,
	[ComboId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestID] [nvarchar](50) NOT NULL,
	[House's type] [nvarchar](100) NOT NULL,
	[areaSquareValue] [float] NULL,
	[name] [nvarchar](100) NOT NULL,
	[QuotationId] [nvarchar](10) NOT NULL,
	[unit_price] [float] NULL,
	[describe] [nvarchar](MAX) NULL,
	[houseTypePrice] [float] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request_unit]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request_unit](
	[UnitId] [nvarchar](10) NOT NULL,
	[Request_ID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_R_T] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC,
	[Request_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[Type of house]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type of house](
	[TypeId] [nvarchar](10) NOT NULL,
	[Type name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Type of house] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Request]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Request](
	[RequestId] [nvarchar](50) NOT NULL,
	[TypeId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Type_Request] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC,
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 4/5/2024 11:15:55 AM ******/
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
/****** Object:  Table [dbo].[UrlPath]    Script Date: 4/5/2024 11:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrlPath](
	[Url_Id] [nvarchar](10) NOT NULL,
	[title] [nvarchar](100) NULL,
	[url] [nvarchar](max) NULL,
	[imgurl] [nvarchar](max) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_UrlPath] PRIMARY KEY CLUSTERED 
(
	[Url_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'1', N'admin@gmail.com', N'admin123456')
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'2', N'me@gmail.com', N'3')
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'3', N'test@gmail.com', N'1')
INSERT [dbo].[Admin] ([Admin's ID], [Admin's mail], [Admin's password]) VALUES (N'4', N'string', N'string')
GO
INSERT [dbo].[comboDesign] ([ComboId], [TypeName], [Describe], [unit_price]) VALUES (N'A', N'Cozy Cottage', N'Ngôi nhà nhỏ kiểu nông thôn một phòng ngủ duyên dáng nép mình trong một khu phố thanh bình, có phòng khách ấm cúng, nhà bếp nhỏ gọn và khu vườn cổ kính.', 2464950000)
GO
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Status], [Staff Id], [customerName], [phoneNumber], [projectAddress], [quotationDate], [CustomerId]) VALUES (N'1', N'1', N'1', N'Thu Hằng', N'099999999999', N'Phố Mã', CAST(N'2023-12-12' AS Date), N'1')
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Status], [Staff Id], [customerName], [phoneNumber], [projectAddress], [quotationDate], [CustomerId]) VALUES (N'2', N'1', N'1', N'Ngân Kim', N'098888888888', N'Phố Hàng', CAST(N'2023-01-12' AS Date), N'1994')
INSERT [dbo].[Construction price quotation] ([Quotation ID], [Status], [Staff Id], [customerName], [phoneNumber], [projectAddress], [quotationDate], [CustomerId]) VALUES (N'538059', N'Still on going', N'1', N'Thu Hằng', N'099999999999', N'Phố Mã', CAST(N'2024-04-02' AS Date), N'1')
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
INSERT [dbo].[Request] ([RequestID], [House's type], [areaSquareValue], [name], [QuotationId], [unit_price], [describe], [houseTypePrice]) VALUES (N'1', N'Nhà lầu', 2000, N'Cổ điển', N'1', NULL, NULL, NULL)
INSERT [dbo].[Request] ([RequestID], [House's type], [areaSquareValue], [name], [QuotationId], [unit_price], [describe], [houseTypePrice]) VALUES (N'2', N'Nhà Phố', 1000, N'Hiện đại', N'1', NULL, NULL, NULL)
INSERT [dbo].[Request] ([RequestID], [House's type], [areaSquareValue], [name], [QuotationId], [unit_price], [describe], [houseTypePrice]) VALUES (N'2.4.2024ID.27557', N'Nhà cổ', 5000, N'Biệt thự', N'538059', NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'1', N'Nguyễn Tri Phương', N'phuong@gmail.com', N'phuong123')
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'2', N'Nguyễn Bỉnh Khiêm', N'khiem@gmail.com', N'khiem123')
INSERT [dbo].[Staff] ([Staff's ID], [Staff's name], [Staff's email], [Staff password]) VALUES (N'3', N'huaw', N'kingen@gmail.com', N'kingmen')
GO
INSERT [dbo].[UrlPath] ([Url_Id], [title], [url], [imgurl], [description]) VALUES (N'1', N'Nội Thất Nhà Phố', N'/Thi_Công_nội_thất_nhà_phố', N'./assets/img-thicong/np5.jpg', N'Nội Thất Nhà Phố đẹp ')
INSERT [dbo].[UrlPath] ([Url_Id], [title], [url], [imgurl], [description]) VALUES (N'2', N'Nội Thất Biệt Thự', N'/Thi_Công_nội_thất_biệt_thự', N'./assets/img-thicong/bt1.jpg', N'Nội Thất đẹp ')
INSERT [dbo].[UrlPath] ([Url_Id], [title], [url], [imgurl], [description]) VALUES (N'3', N'Nội Thất Văn Phòng', N'/Thi_Công_nội_thất_văn_phòng', N'./assets/img-thicong/vp2.jpeg', N'Nội Thất đẹp ')
INSERT [dbo].[UrlPath] ([Url_Id], [title], [url], [imgurl], [description]) VALUES (N'4', N'Nội Thất Chung Cư', N'/Thi_Công_nội_thất_chung_cư', N'https://spacet-release.s3.ap-southeast-1.amazonaws.com/img/blog/2023-01-05/15-mau-thiet-ke-noi-that-chung-cu-nho-tien-nghi-va-toi-uu-dien-tich-63b69207b8f8826f0f13fd38.webp', N'Nhà đẹp')
INSERT [dbo].[UrlPath] ([Url_Id], [title], [url], [imgurl], [description]) VALUES (N'5', N'Lunaria', N'/ProjectDoneDetails/5', N'./assets/postDetails/PostDetails6.jfif', N'nhà đẹp')
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
ALTER TABLE [dbo].[houseTypeOption]  WITH CHECK ADD  CONSTRAINT [FK_houseTypeOption_comboDesign] FOREIGN KEY([comboDesignId])
REFERENCES [dbo].[comboDesign] ([ComboId])
GO
ALTER TABLE [dbo].[houseTypeOption] CHECK CONSTRAINT [FK_houseTypeOption_comboDesign]
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
ALTER TABLE [dbo].[Req_Com]  WITH CHECK ADD  CONSTRAINT [FK_Req_Com_comboDesign] FOREIGN KEY([ComboId])
REFERENCES [dbo].[comboDesign] ([ComboId])
GO
ALTER TABLE [dbo].[Req_Com] CHECK CONSTRAINT [FK_Req_Com_comboDesign]
GO
ALTER TABLE [dbo].[Req_Com]  WITH CHECK ADD  CONSTRAINT [FK_Req_Com_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestID])
GO
ALTER TABLE [dbo].[Req_Com] CHECK CONSTRAINT [FK_Req_Com_Request]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Construction price quotation] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[Construction price quotation] ([Quotation ID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Construction price quotation]
GO
ALTER TABLE [dbo].[Request_unit]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_UNIT_Request] FOREIGN KEY([Request_ID])
REFERENCES [dbo].[Request] ([RequestID])
GO
ALTER TABLE [dbo].[Request_unit] CHECK CONSTRAINT [FK_REQUEST_UNIT_Request]
GO
ALTER TABLE [dbo].[Request_unit]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_UNIT_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[Request_unit] CHECK CONSTRAINT [FK_REQUEST_UNIT_Unit]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestID])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Request]
GO
ALTER TABLE [dbo].[Type_Request]  WITH CHECK ADD  CONSTRAINT [FK_Type_Request_Type of house] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type of house] ([TypeId])
GO
ALTER TABLE [dbo].[Type_Request] CHECK CONSTRAINT [FK_Type_Request_Type of house]
GO
