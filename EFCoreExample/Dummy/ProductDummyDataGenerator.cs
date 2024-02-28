using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    public class ProductDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        public ProductDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        public void GenerateDummyProducts(int numberOfProducts)
        {
            _context.Products.RemoveRange(_context.Products);
            _ = _context.SaveChanges();

            for (int i = 0; i < numberOfProducts; i++)
            {
                Product product = new()
                {
                    Name = GenerateProductName(),
                    Price = GenerateRandomPrice(),
                    Description = GenerateRandomDescription()
                };

                _ = _context.Products.Add(product);
            }

            _ = _context.SaveChanges();

            Console.WriteLine($"Dummy products ({numberOfProducts}) created successfully.");
        }

        private string GenerateProductName()
        {
            return "Product" + Guid.NewGuid().ToString()[..8];
        }

        private string GenerateRandomPrice()
        {
            Random random = new();
            decimal price = Math.Round((decimal)(random.NextDouble() * 1000), 2);
            return price.ToString();
        }

        private string GenerateRandomDescription()
        {
            string[] descriptions = { "Best product ever", "High quality item", "Limited edition", "Great value for money" };
            Random random = new();
            int index = random.Next(descriptions.Length);
            return descriptions[index];
        }
    }
}
