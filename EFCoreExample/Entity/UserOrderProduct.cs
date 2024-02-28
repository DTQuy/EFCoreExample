namespace EFCoreExample.Entity
{
    /// <summary>
    /// Represents a user order product entity
    /// </summary>
    public class UserOrderProduct
    {
        /// <summary>
        /// UserOrderProductID
        /// </summary>
        public int UserOrderProductID { get; set; }

        /// <summary>
        /// Order ID related to this product
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Product ID related to this order
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Quantity of the product ordered
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Additional notes for the order product
        /// </summary>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Discount applied to the product
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// User order associated with this product
        /// </summary>
        public UserOrder? UserOrder { get; set; }

        /// <summary>
        /// Product details associated with this order product
        /// </summary>
        public Product? Product { get; set; }
    }
}
