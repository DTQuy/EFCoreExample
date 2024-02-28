using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    /// <summary>
    /// Generates dummy data for testing purposes.
    /// </summary>
    public class DummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyDataGenerator"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public DummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates dummy users.
        /// </summary>
        /// <param name="numberOfUsers">The number of users to generate.</param>
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

        /// <summary>
        /// Generates a random name.
        /// </summary>
        private static string GenerateRandomName()
        {
            return "User" + Guid.NewGuid().ToString()[..8];
        }

        /// <summary>
        /// Generates a random password.
        /// </summary>
        private static string GenerateRandomPassword()
        {
            return Guid.NewGuid().ToString()[..8];
        }

        /// <summary>
        /// Generates a random avatar URL.
        /// </summary>
        private static string GenerateRandomAvatarUrl()
        {
            return "https://example.com/avatar" + Guid.NewGuid().ToString()[..8] + ".png";
        }

        /// <summary>
        /// Generates a random age.
        /// </summary>
        private static int GenerateRandomAge()
        {
            Random random = new();
            return random.Next(18, 71);
        }

        /// <summary>
        /// Generates a random birthday.
        /// </summary>
        private static DateTimeOffset GenerateRandomBirthday()
        {
            Random random = new();
            int year = random.Next(1970, 2006);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
        }
    }
}
