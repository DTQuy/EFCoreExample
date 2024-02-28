using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    /// <summary>
    /// Represents a user order entity
    /// </summary>
    public class UserOrder
    {
        /// <summary>
        /// Gets or sets the order ID
        /// </summary>
        [Key]
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the date of the order
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user placing the order
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this order
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the list of products associated with this order
        /// </summary>
        public List<UserOrderProduct>? OrderProducts { get; set; }
    }
}
