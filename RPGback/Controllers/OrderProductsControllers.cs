using Microsoft.EntityFrameworkCore;
using RPGback.Context;
using RPGobject;

namespace RPGback.Controllers
{
    public class OrderProductControllers
{
    public static List<OrderProduct> GetOrderProducts()
    {
        using (var db = new StoreContext())
        {
            return db.OrderProducts.ToList();
        }
    }

    public static async Task<OrderProduct> GetOrderProductByIdAsync(string orderProductId)
    {
        using (var db = new StoreContext())
        {
            return await db.OrderProducts.FindAsync(orderProductId);
        }
    }

    public static async Task<List<OrderProduct>> GetOrderProductsByOrderIdAsync(string orderId)
    {
        using (var db = new StoreContext())
        {
            return await db.OrderProducts
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
        }
    }

    public static void CreateOrderProduct(OrderProduct orderProduct)
    {
        using (var db = new StoreContext())
        {
            db.OrderProducts.Add(orderProduct);
            db.SaveChanges();
        }
    }

    public static async Task CreateOrderProductAsync(OrderProduct orderProduct)
    {
        using (var db = new StoreContext())
        {
            db.OrderProducts.Add(orderProduct);
            await db.SaveChangesAsync();
        }
    }

    public static void UpdateOrderProduct(OrderProduct orderProduct)
    {
        using (var db = new StoreContext())
        {
            var entry = db.Entry(orderProduct);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }

    public static async Task UpdateOrderProductAsync(OrderProduct orderProduct)
    {
        using (var db = new StoreContext())
        {
            db.OrderProducts.Update(orderProduct);
            await db.SaveChangesAsync();
        }
    }
}

}