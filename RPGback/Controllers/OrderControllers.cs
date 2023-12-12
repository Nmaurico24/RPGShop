using RPGback.Context;
using RPGobject;
using Microsoft.EntityFrameworkCore;

namespace RPGback.Controllers
{
    public class OrderControllers
    {
        public static List<Order> GetOrders()
        {
            using (var db = new StoreContext())
            {
                return db.Orders.ToList();
            }
        }
        public static async Task<Order> GetOrderByIdAsync(string orderId)
        {
            using (var db = new StoreContext())
            {
                return await db.Orders.FindAsync(orderId);
            }
        }

        public static void CreateOrder(Order oOrder)
        {
            using (var db = new StoreContext())
            {
                db.Orders.Add(oOrder);
                db.SaveChanges();
            }
        }
        public static async Task<List<Order>> GetOrdersByWarehouseIdAsync(string warehouseId)
        {
            using (var db = new StoreContext())
            {
                return await db.Orders
                    .Where(t => t.WarehouseId == warehouseId)
                    .ToListAsync();
            }
        }
        public static void UpdateOrder(Order oOrder)
        {
            using (var db = new StoreContext())
            {
                var entry = db.Entry(oOrder);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public static async Task<List<Order>> GetOrderAsync()
        {
            using (var db = new StoreContext())
            {
                return await db.Orders.ToListAsync();
            }
        }
        public static async Task CreateOrderAsync(Order oOrder)
        {
            using (var db = new StoreContext())
            {
                db.Orders.Add(oOrder);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateOrderAsync(Order oOrder)
        {
            using (var db = new StoreContext())
            {
                db.Orders.Update(oOrder);
                await db.SaveChangesAsync();
            }
        }
    }

}