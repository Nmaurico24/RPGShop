using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;

namespace RPGback.Controllers
{
public class TransactionProductControllers
{
    public static List<TransactionProduct> GetTransactionProducts()
    {
        using (var db = new StoreContext())
        {
            return db.TransactionProducts.ToList();
        }
    }

    public static async Task<TransactionProduct> GetTransactionProductByIdAsync(string transactionProductId)
    {
        using (var db = new StoreContext())
        {
            return await db.TransactionProducts.FindAsync(transactionProductId);
        }
    }

    public static async Task<List<TransactionProduct>> GetTransactionProductsByTransactionIdAsync(string transactionId)
    {
        using (var db = new StoreContext())
        {
            return await db.TransactionProducts
                .Where(tp => tp.TransactionId == transactionId)
                .ToListAsync();
        }
    }

    public static void CreateTransactionProduct(TransactionProduct transactionProduct)
    {
        using (var db = new StoreContext())
        {
            db.TransactionProducts.Add(transactionProduct);
            db.SaveChanges();
        }
    }

    public static async Task CreateTransactionProductAsync(TransactionProduct transactionProduct)
    {
        using (var db = new StoreContext())
        {
            db.TransactionProducts.Add(transactionProduct);
            await db.SaveChangesAsync();
        }
    }

    public static void UpdateTransactionProduct(TransactionProduct transactionProduct)
    {
        using (var db = new StoreContext())
        {
            var entry = db.Entry(transactionProduct);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }

    public static async Task UpdateTransactionProductAsync(TransactionProduct transactionProduct)
    {
        using (var db = new StoreContext())
        {
            db.TransactionProducts.Update(transactionProduct);
            await db.SaveChangesAsync();
        }
    }
}

}