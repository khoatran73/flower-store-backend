using Microsoft.EntityFrameworkCore;

namespace store.Entities
{
    public partial class henrystoreContext : DbContext
    {
        public henrystoreContext()
        {
        }

        public henrystoreContext(DbContextOptions<henrystoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartDetail> CartDetails { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductInStore> ProductInStores { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KHOA-PRO\\MAYCHU;Initial Catalog=henrystore;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname).HasColumnName("fullname");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PasswordHash)
                    .IsUnicode(false)
                    .HasColumnName("passwordHash");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Salt)
                    .IsUnicode(false)
                    .HasColumnName("salt");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasMany(d => d.CommentsNavigation)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "Reaction",
                        l => l.HasOne<Comment>().WithMany().HasForeignKey("CommentId").HasConstraintName("fk_reaction_comment"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_reaction_account"),
                        j =>
                        {
                            j.HasKey("AccountId", "CommentId").HasName("PK__reaction__3EBACC07293CCCB3");

                            j.ToTable("reaction");

                            j.IndexerProperty<Guid>("AccountId").HasColumnName("accountId");

                            j.IndexerProperty<Guid>("CommentId").HasColumnName("commentId");
                        });
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_cart_account");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId })
                    .HasName("PK__cartDeta__F38A0EAE84626B74");

                entity.ToTable("cartDetail");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("fk_cartDetail_cart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_cartDetail_product");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_comment_account");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_comment_product");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_customer_account");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_customer_store");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.DeliveryAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deliveryAt");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_orders_cart");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customer");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("fk_staff_cart");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_product_category");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("productCategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<ProductInStore>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StoreId })
                    .HasName("PK__productI__0CFAA00B3E28F0D1");

                entity.ToTable("productInStore");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInStores)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_productInStore_product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductInStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("fk_productInStore_store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Contact).HasColumnName("contact");
                
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_staff_account");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_staff_store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
