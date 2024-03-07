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
        public virtual DbSet<LinkImage> LinkImages { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<ThemeTable> ThemeTables { get; set; } = null!;
        public virtual DbSet<TypeOfHouse> TypeOfHouses { get; set; } = null!;
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

                entity.Property(e => e.Advise).HasMaxLength(200);

                entity.Property(e => e.CustomerComment)
                    .HasMaxLength(200)
                    .HasColumnName("Customer comment");

                entity.Property(e => e.HouseSType)
                    .HasMaxLength(100)
                    .HasColumnName("House's type");

                entity.Property(e => e.Payment).HasMaxLength(100);

                entity.Property(e => e.Product).HasMaxLength(100);

                entity.Property(e => e.RequestId)
                    .HasMaxLength(10)
                    .HasColumnName("Request Id");

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
                    .HasMaxLength(5)
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
            });

            modelBuilder.Entity<LinkImage>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.ToTable("Link Image");

                entity.Property(e => e.LinkId)
                    .HasMaxLength(50)
                    .HasColumnName("Link Id");

                entity.Property(e => e.PostId)
                    .HasMaxLength(10)
                    .HasColumnName("Post Id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.LinkImages)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Link Image_Post");
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

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .HasColumnName("Staff Id");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Staff");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.RequestId)
                    .HasMaxLength(10)
                    .HasColumnName("Request ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("Customer Id");

                entity.Property(e => e.CustomerPhone).HasMaxLength(12);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.HouseSType)
                    .HasMaxLength(100)
                    .HasColumnName("House's type");

                entity.Property(e => e.Theme).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Customer");

                entity.HasMany(d => d.Quotations)
                    .WithMany(p => p.Requests)
                    .UsingEntity<Dictionary<string, object>>(
                        "CR",
                        l => l.HasOne<ConstructionPriceQuotation>().WithMany().HasForeignKey("QuotationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_C_R_Construction price quotation1"),
                        r => r.HasOne<Request>().WithMany().HasForeignKey("RequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_C_R_Request"),
                        j =>
                        {
                            j.HasKey("RequestId", "QuotationId").HasName("PK");

                            j.ToTable("C_R");

                            j.IndexerProperty<string>("RequestId").HasMaxLength(10).HasColumnName("Request ID");

                            j.IndexerProperty<string>("QuotationId").HasMaxLength(10).HasColumnName("Quotation ID");
                        });
            });

            modelBuilder.Entity<ThemeTable>(entity =>
            {
                entity.HasKey(e => e.ThemeId)
                    .HasName("PK_Theme");

                entity.ToTable("Theme_Table");

                entity.Property(e => e.ThemeId).HasMaxLength(10);

                entity.Property(e => e.Theme).HasMaxLength(100);

                entity.HasMany(d => d.Requests)
                    .WithMany(p => p.Themes)
                    .UsingEntity<Dictionary<string, object>>(
                        "RequestTheme",
                        l => l.HasOne<Request>().WithMany().HasForeignKey("RequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_REQUEST_THEME_Request"),
                        r => r.HasOne<ThemeTable>().WithMany().HasForeignKey("ThemeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_REQUEST_THEME_Theme_Table"),
                        j =>
                        {
                            j.HasKey("ThemeId", "RequestId").HasName("PK_R_T");

                            j.ToTable("REQUEST_THEME");

                            j.IndexerProperty<string>("ThemeId").HasMaxLength(10);

                            j.IndexerProperty<string>("RequestId").HasMaxLength(10).HasColumnName("Request_ID");
                        });
            });

            modelBuilder.Entity<TypeOfHouse>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Type of house");

                entity.Property(e => e.TypeId).HasMaxLength(10);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("Type name");

                entity.HasMany(d => d.Requests)
                    .WithMany(p => p.Types)
                    .UsingEntity<Dictionary<string, object>>(
                        "TypeRequest",
                        l => l.HasOne<Request>().WithMany().HasForeignKey("RequestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Type_Request_Request"),
                        r => r.HasOne<TypeOfHouse>().WithMany().HasForeignKey("TypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Type_Request_Type of house"),
                        j =>
                        {
                            j.HasKey("TypeId", "RequestId");

                            j.ToTable("Type_Request");

                            j.IndexerProperty<string>("TypeId").HasMaxLength(10);

                            j.IndexerProperty<string>("RequestId").HasMaxLength(10);
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
