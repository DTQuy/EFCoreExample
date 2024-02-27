using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<UserOrderProduct>? UserOrderProducts { get; set; }

    }
}
