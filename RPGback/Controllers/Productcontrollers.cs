using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;


namespace RPGback.Controllers
{
    public class ProductControllers
    {
        public static List<Product> GetProducts()
        {
            using (var db = new StoreContext())
            {
                return db.Products.ToList();
            }
        }
        public static async Task<Product> GetProductByIdAsync(string productId)
        {
            using (var db = new StoreContext())
            {
                return await db.Products.FindAsync(productId);
            }
        }

        public static void CreateProduct(Product oProduct)
        {
            using (var db = new StoreContext())
            {
                db.Products.Add(oProduct);
                db.SaveChanges();
            }
        }
        public static void UpdateProduct(Product oProduct)
        {
            using (var db = new StoreContext())
            {
                var entry = db.Entry(oProduct);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public static async Task<List<Product>> GetProductsAsync()
        {
            using (var db = new StoreContext())
            {
                return await db.Products.ToListAsync();
            }
        }
        public static async Task<List<Product>> GetProductsByTransactionIdAsync(string transactionId)
        {
            using (var db = new StoreContext())
            {
                var productIds = await db.TransactionProducts
                    .Where(tp => tp.TransactionId == transactionId)
                    .Select(tp => tp.ProductId)
                    .ToListAsync();
        
                var products = await db.Products
                    .Where(p => productIds.Contains(p.ProductId))
                    .ToListAsync();
        
                return products;
            }
        }

        public static async Task CreateProductAsync(Product oProduct)
        {
            using (var db = new StoreContext())
            {
                db.Products.Add(oProduct);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateProductAsync(Product oProduct)
        {
            using (var db = new StoreContext())
            {
                db.Products.Update(oProduct);
                await db.SaveChangesAsync();
            }
        }
    }

}

