using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    public class UserOrder
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public List<UserOrderProduct>? OrderProducts { get; set; }
    }
}
