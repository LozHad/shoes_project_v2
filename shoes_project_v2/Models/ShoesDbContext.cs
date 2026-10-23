using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shoes_project_v2.Models;

public partial class ShoesDbContext : DbContext
{
    public ShoesDbContext()
    {
    }

    public ShoesDbContext(DbContextOptions<ShoesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<StockItem> StockItems { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VOrdersSummary> VOrdersSummaries { get; set; }

    public virtual DbSet<VProductsCatalog> VProductsCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=shoes_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_categories");

            entity.ToTable("categories", tb => tb.HasComment("Категории обуви: детская, женская, мужская"));

            entity.HasIndex(e => e.CategoryName, "uq_categories_name").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("pk_manufacturers");

            entity.ToTable("manufacturers", tb => tb.HasComment("Производители"));

            entity.HasIndex(e => e.ManufacturerName, "uq_manufacturers_name").IsUnique();

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("pk_orders");

            entity.ToTable("orders", tb => tb.HasComment("Заказы клиентов"));

            entity.HasIndex(e => e.ClientId, "ix_orders_client_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("order_date");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_client");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("pk_order_items");

            entity.ToTable("order_items", tb => tb.HasComment("Состав заказа: товарная позиция, количество, цена за единицу"));

            entity.HasIndex(e => e.StockItemId, "ix_order_items_stock_item");

            entity.HasIndex(e => new { e.OrderId, e.StockItemId }, "uq_order_items_order_item").IsUnique();

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StockItemId).HasColumnName("stock_item_id");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_order_items_order");

            entity.HasOne(d => d.StockItem).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_items_stock_item");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("pk_products");

            entity.ToTable("products", tb => tb.HasComment("Модели обуви (каталог)"));

            entity.HasIndex(e => e.CategoryId, "ix_products_category_id");

            entity.HasIndex(e => e.ManufacturerId, "ix_products_manufacturer_id");

            entity.HasIndex(e => e.SubcategoryId, "ix_products_subcategory_id");

            entity.HasIndex(e => new { e.ProductName, e.ManufacturerId }, "uq_products_name_manuf").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Composition).HasColumnName("composition");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("product_name");
            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_category");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_manufacturer");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubcategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_subcategory");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_roles");

            entity.ToTable("roles", tb => tb.HasComment("Роли: Администратор, Менеджер, Авторизованный пользователь"));

            entity.HasIndex(e => e.RoleName, "uq_roles_name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("pk_sizes");

            entity.ToTable("sizes", tb => tb.HasComment("Размерный ряд"));

            entity.HasIndex(e => e.SizeValue, "uq_sizes_value").IsUnique();

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.SizeValue)
                .HasPrecision(3, 1)
                .HasColumnName("size_value");
        });

        modelBuilder.Entity<StockItem>(entity =>
        {
            entity.HasKey(e => e.StockItemId).HasName("pk_stock_items");

            entity.ToTable("stock_items", tb => tb.HasComment("Товарные позиции: модель + размер, количество доступное для заказа"));

            entity.HasIndex(e => e.SizeId, "ix_stock_items_size_id");

            entity.HasIndex(e => new { e.ProductId, e.SizeId }, "uq_stock_items_prod_size").IsUnique();

            entity.Property(e => e.StockItemId).HasColumnName("stock_item_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuantityAvailable).HasColumnName("quantity_available");
            entity.Property(e => e.SizeId).HasColumnName("size_id");

            entity.HasOne(d => d.Product).WithMany(p => p.StockItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_stock_items_product");

            entity.HasOne(d => d.Size).WithMany(p => p.StockItems)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stock_items_size");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("pk_subcategories");

            entity.ToTable("subcategories", tb => tb.HasComment("Подкатегории: кроссовки, сапоги, босоножки, туфли, ботинки"));

            entity.HasIndex(e => e.SubcategoryName, "uq_subcategories_name").IsUnique();

            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(50)
                .HasColumnName("subcategory_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_users");

            entity.ToTable("users", tb => tb.HasComment("Пользователи системы (вход по логину)"));

            entity.HasIndex(e => e.RoleId, "ix_users_role_id");

            entity.HasIndex(e => e.Login, "uq_users_login").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_role");
        });

        modelBuilder.Entity<VOrdersSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_orders_summary");

            entity.Property(e => e.ClientFullName).HasColumnName("client_full_name");
            entity.Property(e => e.ItemsCount).HasColumnName("items_count");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
        });

        modelBuilder.Entity<VProductsCatalog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_products_catalog");

            entity.Property(e => e.AvailableSizes).HasColumnName("available_sizes");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.Composition).HasColumnName("composition");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("product_name");
            entity.Property(e => e.SizeMax).HasColumnName("size_max");
            entity.Property(e => e.SizeMin).HasColumnName("size_min");
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(50)
                .HasColumnName("subcategory_name");
            entity.Property(e => e.QuantityAvailable).HasColumnName("total_quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
