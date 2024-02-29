using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    /// <summary>
    /// Generates dummy data for user order products.
    /// </summary>
    public class UserOrderProductDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserOrderProductDummyDataGenerator"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserOrderProductDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates dummy user order products.
        /// </summary>
        /// <param name="numberOfUserOrderProducts">The number of user order products to generate.</param>
        public void GenerateDummyUserOrderProducts(int numberOfUserOrderProducts)
        {
            if (!_context.UserOrders.Any())
            {
                Console.WriteLine("No data in UserOrder table. Please add data to UserOrder table first.");
                return;
            }
            _ = _context.SaveChanges();

            for (int i = 0; i < numberOfUserOrderProducts; i++)
            {
                UserOrderProduct userOrderProduct = new()
                {
                    OrderID = GenerateRandomOrderId(),
                    ProductID = GenerateRandomProductId(_context),
                    Quantity = GenerateRandomQuantity(),
                    Note = GenerateRandomNote(),
                    Discount = GenerateRandomDiscount()
                };

                _ = _context.UserOrderProducts.Add(userOrderProduct);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy UserOrderProducts ({numberOfUserOrderProducts}) created successfully.");
        }

        /// <summary>
        /// Generates a random order ID.
        /// </summary>
        /// <returns></returns>
        private int GenerateRandomOrderId()
        {
            Random random = new();

            List<int> orderIds = _context.UserOrders.Select(o => o.OrderID).ToList();
            return orderIds.Count == 0 ? 1 : orderIds[random.Next(orderIds.Count)];
        }

        /// <summary>
        /// Generates a random product ID.
        /// </summary>
        private static int GenerateRandomProductId(EFCoreCodeFirstDBContext context)
        {
            List<int> productIds = new();

            List<Product> products = context.Products.ToList();

            foreach (Product? product in products)
            {
                productIds.Add(product.Id);
            }
            if (productIds.Count == 0)
            {
                return -1;
            }
            Random random = new();

            int randomIndex = random.Next(0, productIds.Count);
            int randomProductId = productIds[randomIndex];
            return randomProductId;
        }

        /// <summary>
        /// Generates a random quantity.
        /// </summary>
        private static int GenerateRandomQuantity()
        {
            Random random = new();
            return random.Next(1, 10);
        }

        /// <summary>
        /// Generates a random note.
        /// </summary>
        private static string GenerateRandomNote()
        {
            return "Note" + Guid.NewGuid().ToString()[..8];
        }

        /// <summary>
        /// Generates a random discount.
        /// </summary>
        private static decimal GenerateRandomDiscount()
        {
            Random random = new();
            return Math.Round((decimal)(random.NextDouble() * 100), 2);
        }
    }
}
