using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class Transaction
    {
        [Key]
        [StringLength(50)]
        public string TransactionId { get; set; }

        public DateTime FechData { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual List<Product> Products { get; set; }
        
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }

        public decimal TotalAmount { get; set; }

        public string? SelectedProductId { get; set; }
        
    }
}