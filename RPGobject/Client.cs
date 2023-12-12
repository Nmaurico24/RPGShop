using System.ComponentModel.DataAnnotations;

namespace RPGobject
{
    public class Client
    {   
        [Key]
        [StringLength(50)]
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientLastname { get; set; }

        public string Number { get; set; }

        public string Email { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
        
    }
}