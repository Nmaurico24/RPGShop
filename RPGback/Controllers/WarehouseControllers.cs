using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;

namespace RPGback.Controllers
{
    public class WarehouseControllers
    {
        public static List<Warehouse> GetWarehouses()
        {
            using (var db = new StoreContext())
            {
                return db.Warehouses.ToList();
            }
        }
        public static async Task<Warehouse> GetWarehouseByIdAsync(string warehouseId)
        {
            using (var db = new StoreContext())
            {
                return await db.Warehouses.FindAsync(warehouseId);
            }
        }

        public static void CreateWarehouse(Warehouse oWarehouse)
        {
            using (var db = new StoreContext())
            {
                db.Warehouses.Add(oWarehouse);
                db.SaveChanges();
            }
        }
        public static void UpdateWarehouse(Warehouse oWarehouse)
        {
            using (var db = new StoreContext())
            {
                var entry = db.Entry(oWarehouse);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public static async Task<List<Warehouse>> GetWarehousesAsync()
        {
            using (var db = new StoreContext())
            {
                return await db.Warehouses.ToListAsync();
            }
        }
        public static async Task CreateWarehouseAsync(Warehouse oWarehouse)
        {
            using (var db = new StoreContext())
            {
                db.Warehouses.Add(oWarehouse);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateWarehouseAsync(Warehouse oWarehouse)
        {
            using (var db = new StoreContext())
            {
                db.Warehouses.Update(oWarehouse);
                await db.SaveChangesAsync();
            }
        }
    }

}