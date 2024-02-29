using EFCoreExample.Entity;

namespace EFCoreExample.Dummy
{
    /// <summary>
    /// Generates dummy data for products.
    /// </summary>
    public class ProductDummyDataGenerator
    {
        private readonly EFCoreCodeFirstDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDummyDataGenerator"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductDummyDataGenerator(EFCoreCodeFirstDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates dummy products.
        /// </summary>
        /// <param name="numberOfProducts">The number of products to generate.</param>
        public void GenerateDummyProducts(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product product = new()
                {
                    Name = GenerateProductName(),
                    Price = GenerateRandomPrice(),
                    Description = GenerateRandomDescription()
                };

                _ = _context.Products.Add(product);
                _ = _context.SaveChanges();
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
                Console.WriteLine();
            }

            Console.WriteLine($"Dummy products ({numberOfProducts}) created successfully.");
        }

        /// <summary>
        /// Generates a random product name.
        /// </summary>
        private static string GenerateProductName()
        {
            return "Product" + Guid.NewGuid().ToString()[..8];
        }

        /// <summary>
        /// Generates a random price for a product.
        /// </summary>
        private static string GenerateRandomPrice()
        {
            Random random = new();
            decimal price = Math.Round((decimal)(random.NextDouble() * 1000), 2);
            return price.ToString();
        }

        /// <summary>
        /// Generates a random description for a product.
        /// </summary>
        private static string GenerateRandomDescription()
        {
            string[] descriptions = { "Best product ever", "High quality item", "Limited edition", "Great value for money" };
            Random random = new();
            int index = random.Next(descriptions.Length);
            return descriptions[index];
        }
    }
}
