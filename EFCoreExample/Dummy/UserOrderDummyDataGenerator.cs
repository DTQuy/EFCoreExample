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
            for (int i = 0; i < numberOfUserOrders; i++)
            {
                UserOrder userOrder = new()
                {
                    OrderDate = GenerateRandomOrderDate(),
                    UserID = GenerateRandomUserId(_context)
                };

                _ = _context.UserOrders.Add(userOrder);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy UserOrders ({numberOfUserOrders}) created successfully.");
        }

        /// <summary>
        /// Generates a random user ID.
        /// </summary>
        private int GenerateRandomUserId(EFCoreCodeFirstDBContext context)
        {
            List<int> userIds = new();
            List<User> users = context.Users.ToList();
            foreach (User? user in users)
            {
                userIds.Add(user.Id);
            }
            if (userIds.Count == 0)
            {
                return -1;
            }
            Random random = new();

            int randomIndex = random.Next(0, userIds.Count);
            int randomUserId = userIds[randomIndex];
            return randomUserId;

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
