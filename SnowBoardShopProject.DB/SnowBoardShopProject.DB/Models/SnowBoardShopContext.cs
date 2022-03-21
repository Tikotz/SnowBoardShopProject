using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class SnowBoardShopContext : DbContext
    {
        public SnowBoardShopContext()
        {
        }

        public SnowBoardShopContext(DbContextOptions<SnowBoardShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=SnowBoardShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsLogin)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Orders");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Companies");
            });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    AccountId = 17
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    FirstName = "ori",
                    LastName = "tikozki",
                    PhoneNumber = 0547887927,
                    Email = "oritikozki@gmail.com",
                    UserName = "tikotz",
                    Password = "280298",
                    Budget = 20000,
                    IsLogin = "false"
                },
                new Client
                {
                    Id = 17,
                    FirstName = "Admin",
                    LastName = "Boss",
                    PhoneNumber = 0500000000,
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    Password = "admin123",
                    Budget = 0,
                    IsLogin = "false"
                });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                CompanyName = "Burton"
            },
            new Company
            {
                CompanyId = 2,
                CompanyName = "LibTech"
            },new Company
            {
                CompanyId = 3,
                CompanyName = "Gnu"
            }, new Company
            {
                CompanyId = 4,
                CompanyName = "Salomon"
            }, new Company
            {
                CompanyId = 5,
                CompanyName = "NeverSummer"
            });



            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                CompanyId = 1,
                ProductName = "Prosses",
                UnitPrice = 2190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 2,
                CompanyId = 1,
                ProductName = "Custome",
                UnitPrice = 2790,
                UnitInStock = 4
            }, new Product
            {
                ProductId = 3,
                CompanyId = 1,
                ProductName = "FlightAttendent",
                UnitPrice = 2790,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 4,
                CompanyId = 1,
                ProductName = "SkeletonKey",
                UnitPrice = 2490,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 5,
                CompanyId = 1,
                ProductName = "HomeTownHero",
                UnitPrice = 2890,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 6,
                CompanyId = 1,
                ProductName = "DeepThinker",
                UnitPrice = 2790,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 7,
                CompanyId = 1,
                ProductName = "Kilroy3D",
                UnitPrice = 2590,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 8,
                CompanyId = 2,
                ProductName = "T.RisePro",
                UnitPrice = 2890,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 9,
                CompanyId = 2,
                ProductName = "ColdBrew",
                UnitPrice = 2690,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 10,
                CompanyId = 2,
                ProductName = "T.RiseOrca",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 11,
                CompanyId = 2,
                ProductName = "SkateBanana",
                UnitPrice = 2590,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 12,
                CompanyId = 2,
                ProductName = "GoldenOrca",
                UnitPrice = 3590,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 13,
                CompanyId = 2,
                ProductName = "MagicBM",
                UnitPrice = 2990,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 14,
                CompanyId = 2,
                ProductName = "LostRocket",
                UnitPrice = 2990,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 15,
                CompanyId = 3,
                ProductName = "GWO",
                UnitPrice = 2190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 16,
                CompanyId = 3,
                ProductName = "HeadSpace",
                UnitPrice = 2690,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 17,
                CompanyId = 3,
                ProductName = "Finest",
                UnitPrice = 2790,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 18,
                CompanyId = 3,
                ProductName = "RidersChoise",
                UnitPrice = 2890,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 19,
                CompanyId = 4,
                ProductName = "DanceHaul",
                UnitPrice = 2090,
                UnitInStock = 2
            },new Product
            {
                ProductId = 20,
                CompanyId = 4,
                ProductName = "Assessin",
                UnitPrice = 2390,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 21,
                CompanyId = 4,
                ProductName = "AssessinPro",
                UnitPrice = 2790,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 22,
                CompanyId = 4,
                ProductName = "Super8",
                UnitPrice = 2290,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 23,
                CompanyId = 5,
                ProductName = "SnowTrooper",
                UnitPrice = 2990,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 24,
                CompanyId = 5,
                ProductName = "ProtoSynthesis",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 25,
                CompanyId = 5,
                ProductName = "ProtoUltra",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 26,
                CompanyId = 5,
                ProductName = "ProtoSlinger",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 27,
                CompanyId = 5,
                ProductName = "ProtoFR",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 28,
                CompanyId = 5,
                ProductName = "ShaperTwin",
                UnitPrice = 3190,
                UnitInStock = 2
            }, new Product
            {
                ProductId = 29,
                CompanyId = 5,
                ProductName = "Harpoon",
                UnitPrice = 3190,
                UnitInStock = 2
            });


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
