using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    /// <summary>
    /// Generates dummy data for user orders.
    /// </summary>
    public class UserOrderDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserOrderDummyDataGenerator"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserOrderDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates dummy user orders.
        /// </summary>
        /// <param name="numberOfUserOrders">The number of user orders to generate.</param>
        public void GenerateDummyUserOrders(int numberOfUserOrders)
        {
            _context.UserOrders.RemoveRange(_context.UserOrders);
            _ = _context.SaveChanges();

            for (int i = 0; i < numberOfUserOrders; i++)
            {
                UserOrder userOrder = new()
                {
                    OrderDate = GenerateRandomOrderDate(),
                    UserID = GenerateRandomUserId()
                };

                _ = _context.UserOrders.Add(userOrder);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy UserOrders ({numberOfUserOrders}) created successfully.");
        }

        /// <summary>
        /// Generates a random user ID.
        /// </summary>
        private int GenerateRandomUserId()
        {
            Random random = new();
            List<int> userIds = _context.Users.Select(u => u.Id).ToList();
            return userIds.Count == 0 ? 1 : userIds[random.Next(userIds.Count)];
        }

        /// <summary>
        /// Generates a random order date.
        /// </summary>
        private static DateTime GenerateRandomOrderDate()
        {
            Random random = new();
            DateTime startDate = DateTime.UtcNow.AddYears(-1);
            int range = (DateTime.UtcNow - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }
}
