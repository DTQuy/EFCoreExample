using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    public class UserOrder
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public User? User { get; set; }
        public List<UserOrderProduct>? UserOrderProducts { get; set; }
    }
}
