USE [MyBlog]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 31.3.2022 15:40:48 ******/
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
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 31.3.2022 15:40:48 ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 31.3.2022 15:40:48 ******/
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
/****** Object:  Table [dbo].[Mesajlar]    Script Date: 31.3.2022 15:40:48 ******/
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
/****** Object:  Table [dbo].[SiteAyarlari]    Script Date: 31.3.2022 15:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteAyarlari](
	[SiteAyarID] [int] IDENTITY(1,1) NOT NULL,
	[SiteLogo] [nvarchar](250) NULL,
	[SiteFavicon] [nvarchar](250) NULL,
	[SiteTitle] [nvarchar](250) NULL,
	[SiteTwitter] [nvarchar](250) NULL,
	[SiteFacebook] [nvarchar](250) NULL,
	[SiteInstagram] [nvarchar](250) NULL,
	[SiteGithub] [nvarchar](250) NULL,
	[SiteLinkedin] [nvarchar](250) NULL,
	[SiteCopyright] [nvarchar](250) NULL,
	[SiteAnasayfaResim] [nvarchar](250) NULL,
	[SiteAnasayfa] [nvarchar](250) NULL,
	[SiteAnasayfaAltBaslik] [nvarchar](250) NULL,
	[SiteHakkimdaResim] [nvarchar](250) NULL,
	[SiteHakkimda] [nvarchar](250) NULL,
	[SiteHakkimdaAltBaslik] [nvarchar](250) NULL,
	[SiteHakkimdaAciklama] [nvarchar](max) NULL,
	[SiteIletisimResim] [nvarchar](250) NULL,
	[SiteIletisim] [nvarchar](250) NULL,
	[SiteIletisimAltBaslik] [nvarchar](250) NULL,
	[SiteIletisimAciklama] [nvarchar](max) NULL,
	[SiteLinki] [nvarchar](250) NULL,
	[SiteAdi] [nvarchar](250) NULL,
	[SiteAnasayfaEtiket] [nvarchar](250) NULL,
	[SiteKisiProfil] [nvarchar](250) NULL,
	[SiteKisiEPosta] [nvarchar](250) NULL,
	[SiteKisiTel] [nvarchar](14) NULL,
	[SiteKisiAdres] [nvarchar](250) NULL,
 CONSTRAINT [PK_SiteAyarlari] PRIMARY KEY CLUSTERED 
(
	[SiteAyarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogID], [Resim], [Baslik], [AltBaslik], [Icerik], [PostTarihi], [KullaniciID], [SeoLink]) VALUES (1, N'Content/img/BlogResim/sql-server-identity-seed-reset.png', N'Sql Server Identity Seed Reset', N'Sql Server', N'<div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">Merhaba Arkadaşlar,</div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;"><br></div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">SQL Server üzerindeki IDENTITY SEED özelliğine sahip bir tablonun IDENTITY SEED değerini resetlemek için, her dafasında arama motorlarında aramaktan bıktım. Aşağıdaki kodu kopya-yapıştır yaparak kullanabilirsiniz.</div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;"><br></div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">DBCC CHECKIDENT (‘VERITABANI_ADI.TABLO_ADI‘, RESEED,0)</div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">yazıp bu T-SQL cümleciğini çalıştırdığınızda, belirtilen veritabanı içerisindeki belirtilen tabloya ait IDEDTITY SEED değeri 1’a set edilmiş olacak. Yani bu tabloya yeni girilen ilk kayıt ID’si (IDENTITY SEED özelliği verilmiş kolunu) 1’den başlayacak.</div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;"><br></div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">Umarım faydalı olmuştur.</div><div class="separator" data-original-attrs="{&quot;style&quot;:&quot;&quot;}" style="font-family: &quot;Times New Roman&quot;; font-size: medium; clear: both;">Teşekkürler.</div>                                    ', CAST(N'2021-11-18T10:00:10.100' AS DateTime), 1, N'Sql-Server-Identity-Seed-Reset')
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

INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (2, N'Deneme', N'tarikdavulcu@gmail.com', N'asaddas', N'Naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (4, N'ahmet', N'tarikdavulcu@gmail.com', N'123456789', N'Naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (5, N'ahmet', N'tarikdavulcu@gmail.com', N'123456789', N'Naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (6, N'ahmet', N'tarikdavulcu@gmail.com', N'123123123', N'Naber
')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (7, N'ahmet', N'tarikdavulcu@gmail.com', N'123123123', N'naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (8, N'Ttt', N'ttt@t.com', N'555', N'Naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (9, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'nnnn')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (10, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (11, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (12, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (13, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (14, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (15, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (16, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (17, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'1')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (18, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'1112233')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (19, N'ahmet', N'tarikdavulcu@gmail.com', N'aa', N'aa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (20, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (21, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (22, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (23, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'111')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (24, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'1')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (25, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'1')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (26, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (27, N'ahmet', N'tarikdavulcu@gmail.com', N'123123', N'asd')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (28, N'ahmet', N'tarikdavulcu@gmail.com', N'123123', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (29, N'Deneme', N'tarikdavulcu@gmail.com', N'5378970797', N'naber laaaaaaaaaaaaaaaaan')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (37, N'Volkan aygün', N'vaygun@tekobel.com', N'5555555555', N'Naber lan')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (39, N'ahmet', N'tarikdavulcu@gmail.com', N'123123', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (41, N'engin', N'emutlu@tekobel.com', N'5378970797', N'zike zike müslüman yaptılar.!')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (43, N'Mahmut Tuncer', N'mahmut@tuncer.com', N'5389761315', N'Naber Nasılsın')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (44, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (45, N'ahmet', N'tarikdavulcu@gmail.com', N'21212', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (46, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (47, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (48, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (49, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (50, N'ahmet', N'tarikdavulcu@gmail.com', N'a', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (51, N'ahmet', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (52, N'ahmet', N'tarikdavulcu@gmail.com', N'123aa', N'aa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (53, N'aaa', N'tarikdavulcu@gmail.com', N'123', N'aaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (54, N'ahmet', N'tarikdavulcu@gmail.com', N'123123', N'naber')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (55, N'Tarık Davulcu', N'tarik@davulcu.com', N'5378970797', N'Naber basılsın')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (57, N'engin', N'tarikdavulcu@gmail.com', N'5378970797', N'aaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (1056, N'engin', N'tarikdavulcu@gmail.com', N'5378970797', N'aaaaa')
INSERT [dbo].[Mesajlar] ([MesajID], [Ad], [Mail], [Telefon], [Mesaj]) VALUES (2058, N'RaymondTug', N'electricservice@gmail.com', N'89591741435', N'Hello! We will make a commercial for your business or website for only $20. 
The deal takes place on a well-known freelance exchange, you are protected, the payment will be made after you accept the completed work. 
Email us and we will do the work within 3 hours. 
An example of our work: https://www.youtube.com/watch?v=aRuQxmUwpl4 
To get started we just need your logo (if available), phone number and website address. 
The resulting video you can use in social networks, on your website, YouTube, and so on. 
Our contact information: 
rosajmann@gmail.com 
Sorry if we bothered you, 
Sincerely, Rosa.')
SET IDENTITY_INSERT [dbo].[Mesajlar] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteAyarlari] ON 

INSERT [dbo].[SiteAyarlari] ([SiteAyarID], [SiteLogo], [SiteFavicon], [SiteTitle], [SiteTwitter], [SiteFacebook], [SiteInstagram], [SiteGithub], [SiteLinkedin], [SiteCopyright], [SiteAnasayfaResim], [SiteAnasayfa], [SiteAnasayfaAltBaslik], [SiteHakkimdaResim], [SiteHakkimda], [SiteHakkimdaAltBaslik], [SiteHakkimdaAciklama], [SiteIletisimResim], [SiteIletisim], [SiteIletisimAltBaslik], [SiteIletisimAciklama], [SiteLinki], [SiteAdi], [SiteAnasayfaEtiket], [SiteKisiProfil], [SiteKisiEPosta], [SiteKisiTel], [SiteKisiAdres]) VALUES (1, N'content/img/home-bg.jpg', N'favicon.ico', N'Tarık Davulcu Yazılım Uzmanı', N'https://twitter.com/tarikdavulcu', N'', N'https://www.instagram.com/tarikdvlc/', N'http://github.com/tarikdavulcu', N'linkedin.com/in/tarık-d-016353115', N'Tarık Davulcu', N'content/img/home-bg.jpg', N'Tarık Davulcu', N'Tarık Davulcu', N'../content/img/about-bg.jpg', N'Hakkımda', N'Tarık Davulcu', N'1989 Edirne de dünyaya geldim. Programlar nasıl yapılıyor diye merak ederdim ve serüven böyle başladı 😊', N'../content/img/contact-bg.jpg', N'İletişim', N'Tarık Davulcu', N'Sormaktan çekinmeyin..', N'https://www.tarikdavulcu.com', N'Tarık Davulcu', N'Yazılımcı,Tasarımcı,Mobilci :)', N'Yazılım Uzmanı', N'info@tarikdavulcu.com', N'0537 897 07 97', N'İzmir')
SET IDENTITY_INSERT [dbo].[SiteAyarlari] OFF
GO
