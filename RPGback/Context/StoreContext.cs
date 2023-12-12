using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RPGobject;

namespace RPGback.Context
{
    public class StoreContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<TransactionProduct> TransactionProducts { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public StoreContext() : base()
        {
        }

        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string connectionString = _config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer("Server=*****\\SQLEXPRESS; Database=***;User Id=**; Password=***;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionProduct>()
           .HasKey(tp => new { tp.TransactionId, tp.ProductId });

            modelBuilder.Entity<TransactionProduct>()
                .HasOne(tp => tp.Transaction)
                .WithMany(t => t.TransactionProducts)
                .HasForeignKey(tp => tp.TransactionId);

            modelBuilder.Entity<TransactionProduct>()
                .HasOne(tp => tp.Product)
                .WithMany(p => p.TransactionProducts)
                .HasForeignKey(tp => tp.ProductId);



            modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);



            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                       new Product
                       {
                           ProductId = Guid.NewGuid().ToString(),
                           ProductName = "Black Sword",
                           ProductDescription = "",
                           PurchasePrice = 150,
                           SalePrice = 220,
                           Category1 = Category1.Arma,
                           Category2 = Category2.Fisico,
                           Category3 = Category3.Corte
                       }
                    );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientId = Guid.NewGuid().ToString(),
                    ClientName = "~",
                    ClientLastname = "~",
                    Number = "",
                    Email = ""
                }
            );

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse
                {
                    WarehouseId = Guid.NewGuid().ToString(),
                    WarehouseName = "Central Warehouse",
                    WarehouseAddress = "street x, number x, city x"
                }
            );
        }
    }
}