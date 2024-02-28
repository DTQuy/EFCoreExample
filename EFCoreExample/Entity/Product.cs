using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the product
        /// </summary>
        public string Price { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of user order products associated with this product
        /// </summary>
        public List<UserOrderProduct>? UserOrderProducts { get; set; }
    }
}
