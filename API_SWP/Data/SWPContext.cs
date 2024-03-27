using System;
using System.Collections.Generic;
using API_SWP.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_SWP.Data
{
    public partial class SWPContext : DbContext
    {
        public SWPContext()
        {
        }

        public SWPContext(DbContextOptions<SWPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ConstructionPriceQuotation> ConstructionPriceQuotations { get; set; } = null!;
        public virtual DbSet<ConstructionReceived> ConstructionReceiveds { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostDetail> PostDetails { get; set; } = null!;
        public virtual DbSet<PostImg> PostImgs { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<TypeOfHouse> TypeOfHouses { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder.UseSqlServer(GetConnectionString());

        private string? GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnection"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminSId);

                entity.ToTable("Admin");

                entity.Property(e => e.AdminSId)
                    .HasMaxLength(50)
                    .HasColumnName("Admin's ID");

                entity.Property(e => e.AdminSMail)
                    .HasMaxLength(50)
                    .HasColumnName("Admin's mail");

                entity.Property(e => e.AdminSPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Admin's password");
            });

            modelBuilder.Entity<ConstructionPriceQuotation>(entity =>
            {
                entity.HasKey(e => e.QuotationId);

                entity.ToTable("Construction price quotation");

                entity.Property(e => e.QuotationId)
                    .HasMaxLength(10)
                    .HasColumnName("Quotation ID");

                entity.Property(e => e.CustomerId).HasMaxLength(10);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customerName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.ProjectAddress)
                    .HasMaxLength(100)
                    .HasColumnName("projectAddress");

                entity.Property(e => e.QuotationDate)
                    .HasColumnType("date")
                    .HasColumnName("quotationDate");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .HasColumnName("Staff Id");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ConstructionPriceQuotations)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Construction price quotation_Staff");
            });

            modelBuilder.Entity<ConstructionReceived>(entity =>
            {
                entity.HasKey(e => e.QuotationId)
                    .HasName("PK_Construction received_1");

                entity.ToTable("Construction received");

                entity.Property(e => e.QuotationId)
                    .HasMaxLength(10)
                    .HasColumnName("Quotation ID");

                entity.Property(e => e.ConstructionReceivedId)
                    .HasMaxLength(10)
                    .HasColumnName("Construction received ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.HouseSType)
                    .HasMaxLength(100)
                    .HasColumnName("House's type");

                entity.HasOne(d => d.Quotation)
                    .WithOne(p => p.ConstructionReceived)
                    .HasForeignKey<ConstructionReceived>(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Construction received_Construction price quotation");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerSId);

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerSId)
                    .HasMaxLength(10)
                    .HasColumnName("Customer's Id");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Customer email");

                entity.Property(e => e.CustomerSName)
                    .HasMaxLength(50)
                    .HasColumnName("Customer's name");

                entity.Property(e => e.LoginName)
                    .HasMaxLength(50)
                    .HasColumnName("Login name");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .HasColumnName("Phone number");

                entity.HasMany(d => d.Quotations)
                    .WithMany(p => p.Customers)
                    .UsingEntity<Dictionary<string, object>>(
                        "CusCon",
                        l => l.HasOne<ConstructionPriceQuotation>().WithMany().HasForeignKey("QuotationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Cus_Con_Construction price quotation"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Cus_Con_Customer"),
                        j =>
                        {
                            j.HasKey("CustomerId", "QuotationId").HasName("PK_Customer_QuotationId");

                            j.ToTable("Cus_Con");

                            j.IndexerProperty<string>("CustomerId").HasMaxLength(10);

                            j.IndexerProperty<string>("QuotationId").HasMaxLength(10);
                        });
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostSId);

                entity.ToTable("Post");

                entity.Property(e => e.PostSId)
                    .HasMaxLength(10)
                    .HasColumnName("Post's ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ImgLink).HasColumnName("imgLink");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .HasColumnName("Staff Id");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Staff");
            });

            modelBuilder.Entity<PostDetail>(entity =>
            {
                entity.ToTable("PostDetail");

                entity.Property(e => e.PostDetailId).HasMaxLength(10);

                entity.Property(e => e.Details).HasMaxLength(300);

                entity.Property(e => e.PostId)
                    .HasMaxLength(10)
                    .HasColumnName("postId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostDetails)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostDetail_Post");
            });

            modelBuilder.Entity<PostImg>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PK_Link Image");

                entity.ToTable("PostImg");

                entity.Property(e => e.LinkId)
                    .HasMaxLength(50)
                    .HasColumnName("Link Id");

                entity.Property(e => e.PostId).HasMaxLength(10);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImgs)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Link Image_Post");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.RequestId)
                    .HasMaxLength(10)
                    .HasColumnName("Request ID");

                entity.Property(e => e.HouseSType)
                    .HasMaxLength(100)
                    .HasColumnName("House's type");

                entity.Property(e => e.QuotationId).HasMaxLength(10);

                entity.Property(e => e.Unit).HasMaxLength(100);

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Construction price quotation");
            });

            modelBuilder.Entity<TypeOfHouse>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Type of house");

                entity.Property(e => e.TypeId).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("Type name");

                entity.HasMany(d => d.Requests)
                    .WithMany(p => p.Types)
                    .UsingEntity<Dictionary<string, object>>(
                        "TypeRequest",
                        l => l.HasOne<Request>().WithMany().HasForeignKey("RequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Type_Request_Request1"),
                        r => r.HasOne<TypeOfHouse>().WithMany().HasForeignKey("TypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Type_Request_Type of house"),
                        j =>
                        {
                            j.HasKey("TypeId", "RequestId");

                            j.ToTable("Type_Request");

                            j.IndexerProperty<string>("TypeId").HasMaxLength(10);

                            j.IndexerProperty<string>("RequestId").HasMaxLength(10);
                        });
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.UnitId).HasMaxLength(10);

                entity.Property(e => e.Unit1)
                    .HasMaxLength(100)
                    .HasColumnName("Unit");

                entity.HasMany(d => d.Requests)
                    .WithMany(p => p.Units)
                    .UsingEntity<Dictionary<string, object>>(
                        "RequestUnit",
                        l => l.HasOne<Request>().WithMany().HasForeignKey("RequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_REQUEST_UNIT_Request"),
                        r => r.HasOne<Unit>().WithMany().HasForeignKey("UnitId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_REQUEST_UNIT_Unit"),
                        j =>
                        {
                            j.HasKey("UnitId", "RequestId").HasName("PK_R_T");

                            j.ToTable("REQUEST_UNIT");

                            j.IndexerProperty<string>("UnitId").HasMaxLength(10);

                            j.IndexerProperty<string>("RequestId").HasMaxLength(10).HasColumnName("Request_ID");
                        });
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffSId);

                entity.ToTable("Staff");

                entity.Property(e => e.StaffSId)
                    .HasMaxLength(10)
                    .HasColumnName("Staff's ID");

                entity.Property(e => e.StaffPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Staff password");

                entity.Property(e => e.StaffSEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Staff's email");

                entity.Property(e => e.StaffSName)
                    .HasMaxLength(50)
                    .HasColumnName("Staff's name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
