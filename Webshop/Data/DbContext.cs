using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Webshop.Models;

namespace Webshop.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productimage> Productimages { get; set; }

    public virtual DbSet<Productreview> Productreviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=webshop;User=root;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.ToTable("cart");

            entity.HasIndex(e => e.ProductId, "fk_cart_product");

            entity.HasIndex(e => e.UserId, "fk_cart_user");

            entity.Property(e => e.CartId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_cart_product");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_cart_user");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CategoryImageUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.PaymentId, "fk_orders_payment");

            entity.HasIndex(e => e.ProductId, "fk_orders_product");

            entity.HasIndex(e => e.UserId, "fk_orders_user");

            entity.Property(e => e.OrderDetailsId).HasColumnType("int(11)");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderNo).HasColumnType("text");
            entity.Property(e => e.PaymentId).HasColumnType("int(11)");
            entity.Property(e => e.ProductId).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("fk_orders_payment");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_orders_product");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_orders_user");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentId).HasColumnType("int(11)");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.CardNo).HasMaxLength(50);
            entity.Property(e => e.CvvNo).HasColumnType("int(11)");
            entity.Property(e => e.ExpiryDate).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PaymentMode).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "FK_Product_Category");

            entity.HasIndex(e => e.SubCategoryId, "FK_Product_SubCategory");

            entity.Property(e => e.ProductId).HasColumnType("int(11)");
            entity.Property(e => e.AdditionalDescription)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LongDescription)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Size)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Sold).HasColumnType("int(11)");
            entity.Property(e => e.SubCategoryId).HasColumnType("int(11)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK_Product_SubCategory");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("productimages");

            entity.HasIndex(e => e.ProductId, "FK_ProductImages_Product");

            entity.Property(e => e.ImageId).HasColumnType("int(11)");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.Productimages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImages_Product");
        });

        modelBuilder.Entity<Productreview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

            entity.ToTable("productreview");

            entity.HasIndex(e => e.ProductId, "FK_ProductReview_Product");

            entity.HasIndex(e => e.UserId, "FK_ProductReview_User");

            entity.Property(e => e.ReviewId).HasColumnType("int(11)");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnType("int(11)");
            entity.Property(e => e.Rating).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.Productreviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductReview_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Productreviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ProductReview_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PRIMARY");

            entity.ToTable("subcategory");

            entity.HasIndex(e => e.CategoryId, "FK_SubCategory_Category");

            entity.Property(e => e.SubCategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.SubCategoryName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Subcategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_SubCategory_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "FK_Users_Roles");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.UserId).HasColumnType("int(11)");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PRIMARY");

            entity.ToTable("wishlist");

            entity.HasIndex(e => e.ProductId, "FK_Wishlist_Product");

            entity.HasIndex(e => e.UserId, "FK_Wishlist_User");

            entity.Property(e => e.WishlistId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Wishlist_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Wishlist_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
