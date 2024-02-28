using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    public class DummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        public DummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        public void GenerateDummyUsers(int numberOfUsers)
        {
            _context.Users.RemoveRange(_context.Users);
            _ = _context.SaveChanges();

            for (int i = 0; i < numberOfUsers; i++)
            {
                User user = new()
                {
                    Name = GenerateRandomName(),
                    Email = $"user{i + 1}@example.com",
                    Password = GenerateRandomPassword(),
                    EmailConfirmed = i % 2 == 0
                };

                UserDetails userDetails = new()
                {
                    Avatar = GenerateRandomAvatarUrl(),
                    Age = GenerateRandomAge(),
                    Birthday = GenerateRandomBirthday(),
                    User = user
                };

                _ = _context.Users.Add(user);
                _ = _context.UserDetails.Add(userDetails);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy users ({numberOfUsers}) created successfully.");
        }

        private string GenerateRandomName()
        {
            return "User" + Guid.NewGuid().ToString()[..8];
        }

        private string GenerateRandomPassword()
        {
            return Guid.NewGuid().ToString()[..8];
        }

        private string GenerateRandomAvatarUrl()
        {
            return "https://example.com/avatar" + Guid.NewGuid().ToString()[..8] + ".png";
        }

        private int GenerateRandomAge()
        {
            Random random = new();
            return random.Next(18, 71);
        }

        private DateTimeOffset GenerateRandomBirthday()
        {
            Random random = new();
            int year = random.Next(1970, 2006);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
        }
    }
}
