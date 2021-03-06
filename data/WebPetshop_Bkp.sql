USE [WebPetshop]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[IdAddress] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Complement] [varchar](100) NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[District] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](5) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](25) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](25) NULL,
 CONSTRAINT [Pk_Address] PRIMARY KEY CLUSTERED 
(
	[IdAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[IdAnimal] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Specie] [varchar](35) NOT NULL,
	[Description] [text] NULL,
	[Birthdate] [date] NULL,
	[Amount] [int] NULL,
	[Price] [decimal](12, 2) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](25) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](25) NULL,
 CONSTRAINT [Pk_Animal] PRIMARY KEY CLUSTERED 
(
	[IdAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[IdContact] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[TypeId] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](25) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](25) NULL,
 CONSTRAINT [Pk_Contact] PRIMARY KEY CLUSTERED 
(
	[IdContact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[Total] [decimal](12, 2) NOT NULL,
	[Situation] [varchar](1) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](25) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](25) NULL,
 CONSTRAINT [Pk_Order] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersItem]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersItem](
	[IdOrderItem] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[AnimalType] [int] NULL,
	[AnimalId] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[Amount] [int] NOT NULL,
	[PriceUnit] [decimal](12, 2) NOT NULL,
 CONSTRAINT [Pk_OrderItem] PRIMARY KEY CLUSTERED 
(
	[IdOrderItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[IdPerson] [int] IDENTITY(1,1) NOT NULL,
	[TypePerson] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SocialName] [varchar](150) NULL,
	[Gender] [int] NULL,
	[BirthDate] [date] NULL,
	[Document1] [varchar](25) NOT NULL,
	[Document2] [varchar](25) NULL,
	[Document3] [varchar](25) NULL,
	[AddressId] [int] NOT NULL,
	[MotherName] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](25) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](25) NULL,
 CONSTRAINT [Pk_Person] PRIMARY KEY CLUSTERED 
(
	[IdPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[IdUserProfile] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](35) NOT NULL,
	[Initials] [varchar](5) NOT NULL,
	[Description] [text] NULL,
	[AddDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [Pk_UserProfile] PRIMARY KEY CLUSTERED 
(
	[IdUserProfile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSys]    Script Date: 18/10/2018 19:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSys](
	[IdUserSys] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](25) NOT NULL,
	[Name] [varchar](35) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Mail] [varchar](100) NULL,
	[Reminder] [varchar](100) NULL,
	[PerfilId] [int] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [Pk_UserSys] PRIMARY KEY CLUSTERED 
(
	[IdUserSys] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([IdAddress], [TypeId], [Name], [Number], [Complement], [ZipCode], [District], [City], [State], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, N'Rua Gil Vicente', N'223', NULL, N'09110-120', N'Silveira', N'Santo André', N'SP', CAST(N'2018-10-17T09:35:00.000' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Address] ([IdAddress], [TypeId], [Name], [Number], [Complement], [ZipCode], [District], [City], [State], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (3, 1, N'Rua Maria Aparecida Marchi Redondo', N'862', NULL, N'14803-876', N'Jardim Salto Grande', N'Araraquara', N'SP', CAST(N'2018-10-17T12:33:35.747' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Address] ([IdAddress], [TypeId], [Name], [Number], [Complement], [ZipCode], [District], [City], [State], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (5, 1, N'Rua Vito Fortunato', N'434', N'Bloco B, Apto.203', N'03514-030', N'Vila Matilde', N'São Paulo', N'SP', CAST(N'2018-10-18T09:43:21.760' AS DateTime), N'Uadmin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Animal] ON 

INSERT [dbo].[Animal] ([IdAnimal], [TypeId], [Specie], [Description], [Birthdate], [Amount], [Price], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, N'Labrador', NULL, NULL, 8, CAST(0.00 AS Decimal(12, 2)), CAST(N'2018-10-16T16:35:00.000' AS DateTime), N'Uadmin', CAST(N'2018-10-18T18:40:19.327' AS DateTime), N'Uadmin')
INSERT [dbo].[Animal] ([IdAnimal], [TypeId], [Specie], [Description], [Birthdate], [Amount], [Price], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (2, 1, N'Buldogue', N'Filhote recém nascido', CAST(N'2018-10-06' AS Date), 3, CAST(0.00 AS Decimal(12, 2)), CAST(N'2018-10-17T08:43:35.327' AS DateTime), N'Uadmin', CAST(N'2018-10-18T18:40:19.327' AS DateTime), N'Uadmin')
INSERT [dbo].[Animal] ([IdAnimal], [TypeId], [Specie], [Description], [Birthdate], [Amount], [Price], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (3, 3, N'Perça', N'Gato perça 1 ano', CAST(N'2017-09-11' AS Date), 1, CAST(0.00 AS Decimal(12, 2)), CAST(N'2018-10-17T09:06:54.423' AS DateTime), N'Uadmin', CAST(N'2018-10-18T18:49:32.243' AS DateTime), N'Uadmin')
INSERT [dbo].[Animal] ([IdAnimal], [TypeId], [Specie], [Description], [Birthdate], [Amount], [Price], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (4, 1, N'Beagle', N'Filhote de Beagle', CAST(N'2018-09-20' AS Date), 4, CAST(30.00 AS Decimal(12, 2)), CAST(N'2018-10-18T08:57:58.497' AS DateTime), N'Uadmin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Animal] OFF
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (1, 1, 0, N'(11)3675-1452', CAST(N'2018-10-17T09:35:00.000' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (2, 1, 1, N'(11)99684-9617', CAST(N'2018-10-17T09:35:00.000' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (3, 1, 2, N'ninaelainehadassapereira-93@adiretoria.com.br', CAST(N'2018-10-17T09:35:00.000' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (7, 3, 0, N'(16)3922-4397', CAST(N'2018-10-17T12:33:35.747' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (8, 3, 1, N'(16)98756-7305', CAST(N'2018-10-17T12:33:35.747' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (9, 3, 2, N'mariayasminduarte@bol.com.br', CAST(N'2018-10-17T12:33:35.747' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (13, 5, 0, N'(11)2642-934', CAST(N'2018-10-18T09:43:21.760' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (14, 5, 1, N'(11)98363-8817', CAST(N'2018-10-18T09:43:21.760' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Contact] ([IdContact], [PersonId], [TypeId], [Description], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (15, 5, 2, N'iagoruansgoncalves@ig.com.br', CAST(N'2018-10-18T09:43:21.760' AS DateTime), N'Uadmin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([IdOrder], [Type], [PersonId], [Total], [Situation], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (1, 2, 5, CAST(0.00 AS Decimal(12, 2)), N'F', CAST(N'2018-10-18T13:42:03.467' AS DateTime), N'Uadmin', CAST(N'2018-10-18T18:40:19.327' AS DateTime), N'Uadmin')
INSERT [dbo].[Orders] ([IdOrder], [Type], [PersonId], [Total], [Situation], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (2, 2, 3, CAST(0.00 AS Decimal(12, 2)), N'F', CAST(N'2018-10-18T18:49:02.487' AS DateTime), N'Uadmin', CAST(N'2018-10-18T18:49:32.243' AS DateTime), N'Uadmin')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[OrdersItem] ON 

INSERT [dbo].[OrdersItem] ([IdOrderItem], [OrderId], [AnimalType], [AnimalId], [ProductId], [Price], [Amount], [PriceUnit]) VALUES (1, 1, 1, 2, NULL, CAST(0.00 AS Decimal(12, 2)), 1, CAST(0.00 AS Decimal(12, 2)))
INSERT [dbo].[OrdersItem] ([IdOrderItem], [OrderId], [AnimalType], [AnimalId], [ProductId], [Price], [Amount], [PriceUnit]) VALUES (2, 1, 1, 1, NULL, CAST(0.00 AS Decimal(12, 2)), 1, CAST(0.00 AS Decimal(12, 2)))
INSERT [dbo].[OrdersItem] ([IdOrderItem], [OrderId], [AnimalType], [AnimalId], [ProductId], [Price], [Amount], [PriceUnit]) VALUES (3, 2, 3, 3, NULL, CAST(0.00 AS Decimal(12, 2)), 1, CAST(0.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[OrdersItem] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([IdPerson], [TypePerson], [Name], [SocialName], [Gender], [BirthDate], [Document1], [Document2], [Document3], [AddressId], [MotherName], [FatherName], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (1, 0, N'Nina Elaine Hadassa Pereira', NULL, 0, CAST(N'1988-05-04' AS Date), N'390.578.778-48', N'25.753.504-4', NULL, 1, N'Silvana Rebeca', N'Márcio Calebe Lucas Pereira', CAST(N'2018-10-17T09:35:00.000' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Person] ([IdPerson], [TypePerson], [Name], [SocialName], [Gender], [BirthDate], [Document1], [Document2], [Document3], [AddressId], [MotherName], [FatherName], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (3, 0, N'Maria Yasmin Duarte', NULL, 0, CAST(N'1988-04-27' AS Date), N'675.199.658-64', N'30.096.283-6', NULL, 3, N'Lavínia Mariah Conceição', N'Arthur Danilo Duarte', CAST(N'2018-10-17T12:33:35.747' AS DateTime), N'Uadmin', NULL, NULL)
INSERT [dbo].[Person] ([IdPerson], [TypePerson], [Name], [SocialName], [Gender], [BirthDate], [Document1], [Document2], [Document3], [AddressId], [MotherName], [FatherName], [AddDate], [AddUser], [UpdateDate], [UpdateUser]) VALUES (5, 0, N'Iago Ruan Sebastião Gonçalves', NULL, 1, CAST(N'1984-02-13' AS Date), N'029.059.588-63', N'33.656.034-5', NULL, 5, N'Vera Fabiana', N'Edson Paulo Gonçalves', CAST(N'2018-10-18T09:43:21.760' AS DateTime), N'Uadmin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([IdUserProfile], [Name], [Initials], [Description], [AddDate], [UpdateDate]) VALUES (1, N'Administrador', N'ADM', N'Perfil de administrador do Sistema', CAST(N'2018-10-16T16:15:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
SET IDENTITY_INSERT [dbo].[UserSys] ON 

INSERT [dbo].[UserSys] ([IdUserSys], [Login], [Name], [Password], [Mail], [Reminder], [PerfilId], [AddDate], [UpdateDate]) VALUES (1, N'Uadmin', N'Administrador Sistema', N'adm123', NULL, NULL, 1, CAST(N'2018-10-16T16:30:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UserSys] OFF
ALTER TABLE [dbo].[Animal] ADD  DEFAULT ((1)) FOR [Amount]
GO
ALTER TABLE [dbo].[OrdersItem] ADD  DEFAULT ((1)) FOR [Amount]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [Fk_Person_Contact] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [Fk_Person_Contact]
GO
ALTER TABLE [dbo].[OrdersItem]  WITH CHECK ADD  CONSTRAINT [Fk_Order_OrderItem] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([IdOrder])
GO
ALTER TABLE [dbo].[OrdersItem] CHECK CONSTRAINT [Fk_Order_OrderItem]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [Fk_Address_Person] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([IdAddress])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [Fk_Address_Person]
GO
ALTER TABLE [dbo].[UserSys]  WITH CHECK ADD  CONSTRAINT [Fk_Perfil_UserSys] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[UserProfile] ([IdUserProfile])
GO
ALTER TABLE [dbo].[UserSys] CHECK CONSTRAINT [Fk_Perfil_UserSys]
GO
