using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentalCRM.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RentalCRM.Models
{
    public partial class RentalCRMContext : DbContext
    {

        public RentalCRMContext(DbContextOptions<RentalCRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLog> AccessLog { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<CashReport> CashReport { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategory { get; set; }
        public virtual DbSet<Disaster> Disaster { get; set; }
        public virtual DbSet<DisasterCategory> DisasterCategory { get; set; }
        public virtual DbSet<GeoDistrict> GeoDistrict { get; set; }
        public virtual DbSet<GeoProvince> GeoProvince { get; set; }
        public virtual DbSet<GeoWard> GeoWard { get; set; }
        public virtual DbSet<Livelihood> Livelihood { get; set; }
        public virtual DbSet<LivelihoodCategory> LivelihoodCategory { get; set; }
        public virtual DbSet<LivelihoodType> LivelihoodType { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategory { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationCategory> NotificationCategory { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderLog> OrderLog { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductItem> ProductItem { get; set; }
        public virtual DbSet<ProductItemLog> ProductItemLog { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ProductSize> ProductSize { get; set; }
        public virtual DbSet<ProductUnit> ProductUnit { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<SubOrder> SubOrder { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyCategory> SurveyCategory { get; set; }
        public virtual DbSet<SurveyResult> SurveyResult { get; set; }
        public virtual DbSet<UserCategory> UserCategory { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.Property(e => e.AccessLogId).HasColumnName("AccessLogID");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentUrl)
                    .HasColumnName("CurrentURL")
                    .HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(2000);

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("OS")
                    .HasMaxLength(2000);

                entity.Property(e => e.Source).HasMaxLength(2000);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);
            });

            modelBuilder.Entity<CashReport>(entity =>
            {
                entity.Property(e => e.CashReportId).HasColumnName("CashReportID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.Property(e => e.CounterId).HasColumnName("CounterID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("Unique_Phone");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(2000);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CitizenId)
                    .HasColumnName("CitizenID")
                    .HasMaxLength(2000);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Photo).HasMaxLength(2000);
            });

            modelBuilder.Entity<CustomerCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Disaster>(entity =>
            {
                entity.Property(e => e.DisasterId).HasColumnName("DisasterID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.ApproveTime).HasColumnType("datetime");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhotoOrg)
                    .HasColumnName("PhotoORG")
                    .HasColumnType("text");

                entity.Property(e => e.Scope).HasComment("1: province 2: district 3: ward");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.Property(e => e.WardId).HasColumnName("WardID");
            });

            modelBuilder.Entity<DisasterCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<GeoDistrict>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceId)
                    .IsRequired()
                    .HasColumnName("ProvinceID")
                    .HasMaxLength(5);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GeoProvince>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GeoWard>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DistrictId)
                    .IsRequired()
                    .HasColumnName("DistrictID")
                    .HasMaxLength(5);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.WardId).HasColumnName("WardID");
            });

            modelBuilder.Entity<Livelihood>(entity =>
            {
                entity.Property(e => e.LivelihoodId).HasColumnName("LivelihoodID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Location).HasMaxLength(2000);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhotoOrg)
                    .HasColumnName("PhotoORG")
                    .HasColumnType("text");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<LivelihoodCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<LivelihoodType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.Property(e => e.MarketId).HasColumnName("MarketID");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhotoOrg)
                    .HasColumnName("PhotoORG")
                    .HasColumnType("text");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TItle")
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.ApproveTime).HasColumnType("datetime");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhotoOrg)
                    .HasColumnName("PhotoORG")
                    .HasColumnType("text");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.Property(e => e.UserCategoryId)
                    .HasColumnName("UserCategoryID")
                    .HasMaxLength(2000);

                entity.Property(e => e.WardId).HasColumnName("WardID");
            });

            modelBuilder.Entity<NotificationCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductItemId).HasColumnName("ProductItemID");

                entity.Property(e => e.SoldQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.Property(e => e.OrderLogId).HasColumnName("OrderLogID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedStaffId).HasColumnName("CreatedStaffID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PromotionCode).HasMaxLength(200);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdatedStaffId).HasColumnName("UpdatedStaffID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.StatusName).HasMaxLength(200);
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_OrderCategory");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedStaffId).HasColumnName("CreatedStaffID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DepositInfo).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");

                entity.Property(e => e.PromotionCode).HasMaxLength(200);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdatedStaffId).HasColumnName("UpdatedStaffID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CodeName).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Location).HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Photo).HasMaxLength(2000);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.Property(e => e.ProductItemId).HasColumnName("ProductItemID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");
            });

            modelBuilder.Entity<ProductItemLog>(entity =>
            {
                entity.Property(e => e.ProductItemLogId).HasColumnName("ProductItemLogID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductItemId).HasColumnName("ProductItemID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.UpdatedStaffId).HasColumnName("UpdatedStaffID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CustomerCateId).HasColumnName("CustomerCateID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => e.SizeId);

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SizeName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.UnitId)
                    .HasColumnName("UnitID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerCateId).HasColumnName("CustomerCateID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCateId).HasColumnName("ProductCateID");

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubOrder>(entity =>
            {
                entity.Property(e => e.SubOrderId).HasColumnName("SubOrderID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductItemId).HasColumnName("ProductItemID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhotoOrg)
                    .HasColumnName("PhotoORG")
                    .HasColumnType("text");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<SurveyCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<SurveyResult>(entity =>
            {
                entity.Property(e => e.SurveyResultId).HasColumnName("SurveyResultID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.RoleName).HasMaxLength(2000);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CateId)
                    .HasColumnName("CateID")
                    .HasMaxLength(500);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Photo).HasColumnType("text");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasComment("1: user; 2:admin");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WardId).HasColumnName("WardID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
