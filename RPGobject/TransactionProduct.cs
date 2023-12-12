using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class TransactionProduct
    {
        [Key]
        public string TransactionProductId { get; set; }

        [Required]
        public string TransactionId { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Transaction Transaction { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}