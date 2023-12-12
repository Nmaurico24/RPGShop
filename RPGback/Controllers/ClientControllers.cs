using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;

namespace RPGback.Controllers
{
    public class ClientControllers
    {
        public static List<Client> GetClients()
        {
            using (var db = new StoreContext())
            {
                return db.Clients.ToList();
            }
        }
        public static async Task<Client> GetClientByIdAsync(string clientId)
        {
            using (var db = new StoreContext())
            {
                return await db.Clients.FindAsync(clientId);
            }
        }

        public static void CreateClient(Client oClient)
        {
            using (var db = new StoreContext())
            {
                db.Clients.Add(oClient);
                db.SaveChanges();
            }
        }
        public static void UpdateClient(Client oClient)
        {
            using (var db = new StoreContext())
            {
                var entry = db.Entry(oClient);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public static async Task<List<Client>> GetClientsAsync()
        {
            using (var db = new StoreContext())
            {
                return await db.Clients.ToListAsync();
            }
        }
        public static async Task CreateClientAsync(Client oClient)
        {
            using (var db = new StoreContext())
            {
                db.Clients.Add(oClient);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateClientAsync(Client oClient)
        {
            using (var db = new StoreContext())
            {
                db.Clients.Update(oClient);
                await db.SaveChangesAsync();
            }
        }
    }
}