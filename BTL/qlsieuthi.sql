USE [master]
GO
/****** Object:  Database [QuanliSanPhamSieuThi]    Script Date: 3/31/2023 6:50:20 PM ******/
CREATE DATABASE [QuanliSanPhamSieuThi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanliSanPhamSieuThi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GF63\MSSQL\DATA\QuanliSanPhamSieuThi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanliSanPhamSieuThi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GF63\MSSQL\DATA\QuanliSanPhamSieuThi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanliSanPhamSieuThi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET  MULTI_USER 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanliSanPhamSieuThi', N'ON'
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET QUERY_STORE = OFF
GO
USE [QuanliSanPhamSieuThi]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Born] [nvarchar](50) NULL,
	[Sex] [nvarchar](50) NULL,
	[Birth] [date] NULL,
	[Contact] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill4]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill4](
	[idBill] [int] IDENTITY(1,1) NOT NULL,
	[nameKH] [nvarchar](100) NOT NULL,
	[namePr] [nvarchar](100) NOT NULL,
	[price] [float] NOT NULL,
	[amount] [float] NOT NULL,
	[ngaymua] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListOfProduct]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListOfProduct](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[idPr] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[id] [int] NOT NULL,
	[price] [float] NOT NULL,
	[amount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistic]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistic](
	[nameKH] [nvarchar](100) NOT NULL,
	[sumBill] [float] NOT NULL,
	[ngaymua] [date] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ListOfProduct] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ListOfProduct] FOREIGN KEY([id])
REFERENCES [dbo].[ListOfProduct] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ListOfProduct]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Products_LoadDL]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[tbl_Products_LoadDL]
as select * from Products
GO
/****** Object:  StoredProcedure [dbo].[tbl_Products_TimKiemSP]    Script Date: 3/31/2023 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[tbl_Products_TimKiemSP]
(
	@Sanpham nvarchar(100)
)
as select * from Products
where name like '%' +@Sanpham+'%'
GO
USE [master]
GO
ALTER DATABASE [QuanliSanPhamSieuThi] SET  READ_WRITE 
GO
