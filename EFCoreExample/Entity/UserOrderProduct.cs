namespace EFCoreExample.Entity
{
    public class UserOrderProduct
    {
        public int UserOrderProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public UserOrder? UserOrder { get; set; }
        public Product? Product { get; set; }

    }
}
