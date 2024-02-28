using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    public class UserOrderDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        public UserOrderDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

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

        private int GenerateRandomUserId()
        {
            Random random = new();
            List<int> userIds = _context.Users.Select(u => u.Id).ToList();
            return userIds.Count == 0 ? 1 : userIds[random.Next(userIds.Count)];
        }
        private DateTime GenerateRandomOrderDate()
        {
            Random random = new();
            DateTime startDate = DateTime.UtcNow.AddYears(-1);
            int range = (DateTime.UtcNow - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }

    }
}
