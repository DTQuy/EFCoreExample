using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    public class UserOrderProductDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        public UserOrderProductDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        public void GenerateDummyUserOrderProducts(int numberOfUserOrderProducts)
        {
            if (!_context.UserOrders.Any())
            {
                Console.WriteLine("No data in UserOrder table. Please add data to UserOrder table first.");
                return;
            }
            _context.UserOrderProducts.RemoveRange(_context.UserOrderProducts);
            _ = _context.SaveChanges();

            for (int i = 0; i < numberOfUserOrderProducts; i++)
            {
                UserOrderProduct userOrderProduct = new()
                {
                    OrderID = GenerateRandomOrderId(),
                    ProductID = GenerateRandomProductId(),
                    Quantity = GenerateRandomQuantity(),
                    Note = GenerateRandomNote(),
                    Discount = GenerateRandomDiscount()
                };

                _ = _context.UserOrderProducts.Add(userOrderProduct);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy UserOrderProducts ({numberOfUserOrderProducts}) created successfully.");
        }


        private int GenerateRandomOrderId()
        {
            Random random = new();

            List<int> orderIds = _context.UserOrders.Select(o => o.OrderID).ToList();
            return orderIds.Count == 0 ? 1 : orderIds[random.Next(orderIds.Count)];
        }


        private int GenerateRandomProductId()
        {
            Random random = new();
            return random.Next(1, 10);
        }

        private int GenerateRandomQuantity()
        {
            Random random = new();
            return random.Next(1, 10);
        }

        private string GenerateRandomNote()
        {
            return "Note" + Guid.NewGuid().ToString()[..8];
        }

        private decimal GenerateRandomDiscount()
        {
            Random random = new();
            return Math.Round((decimal)(random.NextDouble() * 100), 2);
        }
    }
}
