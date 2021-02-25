using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemLocation> ItemLocations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__049E3A89FCE6FE79");

                entity.ToTable("Customer");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__LocationID__4C6B5938");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__ProductID__4B7734FF");
            });

            modelBuilder.Entity<ItemLocation>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.LocationId })
                    .HasName("ItemLocationPK");

                entity.ToTable("ItemLocation");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemLocations)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemLocationFK1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ItemLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemLocationFK2");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__Order__CustID__4F47C5E3");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Order__LocationI__503BEA1C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId })
                    .HasName("ProductOrderPK");

                entity.ToTable("ProductOrder");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductOrderFK2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductOrderFK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
