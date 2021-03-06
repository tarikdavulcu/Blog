USE [MyBlog]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 15.9.2021 13:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[Resim] [nvarchar](250) NULL,
	[Baslik] [nvarchar](250) NULL,
	[AltBaslik] [nvarchar](250) NULL,
	[Icerik] [ntext] NULL,
	[PostTarihi] [datetime] NULL,
	[KullaniciID] [int] NULL,
	[SeoLink] [nvarchar](250) NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 15.9.2021 13:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[Mail] [nvarchar](250) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 15.9.2021 13:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[Aciklama] [nvarchar](250) NULL,
	[SiraNo] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesajlar]    Script Date: 15.9.2021 13:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesajlar](
	[MesajID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](250) NULL,
	[Mail] [nvarchar](250) NULL,
	[Telefon] [nvarchar](11) NULL,
	[Mesaj] [ntext] NULL,
 CONSTRAINT [PK_Mesajlar] PRIMARY KEY CLUSTERED 
(
	[MesajID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteAyarlari]    Script Date: 15.9.2021 13:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteAyarlari](
	[SiteAyarID] [int] IDENTITY(1,1) NOT NULL,
	[SiteLogo] [nvarchar](50) NULL,
	[SiteFavicon] [nvarchar](50) NULL,
	[SiteTitle] [nvarchar](50) NULL,
	[SiteTwitter] [nvarchar](50) NULL,
	[SiteFacebook] [nvarchar](50) NULL,
	[SiteInstagram] [nvarchar](50) NULL,
	[SiteGithub] [nvarchar](50) NULL,
	[SiteLinkedin] [nvarchar](50) NULL,
	[SiteCopyright] [nvarchar](50) NULL,
	[SiteAnasayfaResim] [nvarchar](50) NULL,
	[SiteAnasayfa] [nvarchar](50) NULL,
	[SiteAnasayfaAltBaslik] [nvarchar](50) NULL,
	[SiteHakkimdaResim] [nvarchar](50) NULL,
	[SiteHakkimda] [nvarchar](50) NULL,
	[SiteHakkimdaAltBaslik] [nvarchar](50) NULL,
	[SiteHakkimdaAciklama] [nvarchar](50) NULL,
	[SiteIletisimResim] [nvarchar](50) NULL,
	[SiteIletisim] [nvarchar](50) NULL,
	[SiteIletisimAltBaslik] [nvarchar](50) NULL,
	[SiteIletisimAciklama] [nvarchar](50) NULL,
	[SiteLinki] [nvarchar](50) NULL,
	[SiteAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_SiteAyarlari] PRIMARY KEY CLUSTERED 
(
	[SiteAyarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogID], [Resim], [Baslik], [AltBaslik], [Icerik], [PostTarihi], [KullaniciID], [SeoLink]) VALUES (5, N'Content/img/BlogResim/merhaba-dunya-.jpeg', N'Merhaba Dünya ', N'Hello World', N'                                                                                                                                                                                                                                                                                                                                                                                                                                                        Merhaba Dünya
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        ', CAST(N'2020-07-17T00:00:00.000' AS DateTime), 1, N'merhaba   ')
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Mail]) VALUES (1, N'admin', N'20342034  ', N'tarikdavulcu@gmail.com')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuID], [Adi], [Link], [Aciklama], [SiraNo]) VALUES (1, N'Anasayfa  ', N'/', N'Anasayfa  ', 1)
INSERT [dbo].[Menu] ([MenuID], [Adi], [Link], [Aciklama], [SiraNo]) VALUES (2, N'Hakkımda  ', N'/Blog/Hakkimda', N'Hakkımda  ', 2)
INSERT [dbo].[Menu] ([MenuID], [Adi], [Link], [Aciklama], [SiraNo]) VALUES (3, N'İletişim  ', N'/Blog/Iletisim', N'İletişim  ', 3)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Mesajlar] ON 

INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (1, N'Deneme', N'tarik__davulcu@hotmail.com', N'05378970797', N'Naber')
SET IDENTITY_INSERT [dbo].[Mesajlar] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteAyarlari] ON 

INSERT [dbo].[SiteAyarlari] ([SiteAyarID], [SiteLogo], [SiteFavicon], [SiteTitle], [SiteTwitter], [SiteFacebook], [SiteInstagram], [SiteGithub], [SiteLinkedin], [SiteCopyright], [SiteAnasayfaResim], [SiteAnasayfa], [SiteAnasayfaAltBaslik], [SiteHakkimdaResim], [SiteHakkimda], [SiteHakkimdaAltBaslik], [SiteHakkimdaAciklama], [SiteIletisimResim], [SiteIletisim], [SiteIletisimAltBaslik], [SiteIletisimAciklama], [SiteLinki], [SiteAdi]) VALUES (1, N'', N'', N'Tarık Davulcu', N'https://twitter.com/tarikdavulcu', N'', N'https://www.instagram.com/tarikdavulcu/', N'http://github.com/tarikdavulcu/', N'linkedin.com/in/tarık-d-016353115', N'Tarık Davulcu', N'', N'Tarık Davulcu', N'Tarık Davulcu', N'', N'Tarık Davulcu Edirne     ', N'Tarık Davulcu', N'Tarık Davulcu   ', N'', N'Tarık Davulcu', N'Tarık Davulcu', N'Tarık Davulcu', N'Tarık Davulcu', N'Tarık Davulcu')
SET IDENTITY_INSERT [dbo].[SiteAyarlari] OFF
GO
