using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class OrderProduct
    {
        [Key]
        public string OrderProductId { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public void SubtractQuantity(int quantityToSubtract)
        {
            if (quantityToSubtract > 0 && quantityToSubtract <= Quantity)
            {
                Quantity -= quantityToSubtract;
            }
        }
    }
}