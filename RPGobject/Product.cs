using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class Product
    {
        [Key]
        [StringLength(50)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public int PurchasePrice { get; set; }

        [Required]
        public int SalePrice { get; set; }

        [Required]
        public Category1 Category1 { get; set; }

        [Required]
        public Category2 Category2 { get; set; }

        [Required]
        public Category3 Category3 { get; set; }

        public bool Selected { get; set; }

        public string? TransactionId { get; set; }
        
        public virtual Transaction? Transaction { get; set; }

        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }

        public virtual Order? Order { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}