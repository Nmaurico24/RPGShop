using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class Order
    {

        [Key]
        [StringLength(50)]
        public string OrderId { get; set; }

        public DateTime FechData { get; set; }

        public int CanProduct {get; set; }

        public string WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        
        public virtual List<Product> Products { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public decimal TotalAmount { get; set; }

        public string? SelectedProductId { get; set; }
    }
}