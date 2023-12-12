using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;

namespace RPGback.Controllers
{
    public class TransactionControllers
    {
        public static List<Transaction> GetTransactions()
        {
            using (var db = new StoreContext())
            {
                return db.Transactions.ToList();
            }
        }
        public static async Task<Transaction> GetTransactionByIdAsync(string transactionId)
        {
            using (var db = new StoreContext())
            {
                return await db.Transactions.FindAsync(transactionId);
            }
        }
        public static async Task<List<Transaction>> GetTransactionsByClientIdAsync(string clientId)
        {
            using (var db = new StoreContext())
            {
                return await db.Transactions
                    .Where(t => t.ClientId == clientId)
                    .ToListAsync();
            }
        }
        public static void UpdateTransaction(Transaction oTransaction)
        {
            using (var db = new StoreContext())
            {
                var entry = db.Entry(oTransaction);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public static async Task<List<Transaction>> GetTransactionsAsync()
        {
            using (var db = new StoreContext())
            {
                return await db.Transactions.ToListAsync();
            }
        }
        public static async Task CreateTransactionAsync(Transaction oTransaction)
        {
            using (var db = new StoreContext())
            {
                db.Transactions.Add(oTransaction);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateTransactionAsync(Transaction oTransaction)
        {
            using (var db = new StoreContext())
            {
                db.Transactions.Update(oTransaction);
                await db.SaveChangesAsync();
            }
        }
        public static void CreateTransaction(Transaction oTransaction)
        {
            using (var db = new StoreContext())
            {
                var client = db.Clients.Find(oTransaction.ClientId);
                oTransaction.Client = client;
                db.Transactions.Add(oTransaction);
                db.SaveChanges();
            }
        }
    }

}