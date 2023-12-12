using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class Warehouse
    {
        [Key]
        [StringLength(50)]
        public string WarehouseId { get; set; }

        [Required]
        [StringLength(100)]
        public string WarehouseName { get; set; }

        [Required]
        [StringLength(600)]
        public string WarehouseAddress { get; set; }
        
        public virtual List<Order> Orders { get; set; }

    }
}