// See https://aka.ms/new-console-template for more information

// Tạo thêm UserOrders => 1-n: 1 user có nhiều đơn hàng
// Tạo thêm Product => 1 table
// Tạo UserOrderProduct (giống bảng product: quantity, note, discount) quan hệ 1-n với UserOder

using EFCoreExample.Dummy;
using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample
{
    public class Program
    {
        /// <summary>
        /// Main method of the program
        /// </summary>
        private static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1. View User Information");
                Console.WriteLine("2. View User Details by ID");
                Console.WriteLine("3. View Product Information");
                Console.WriteLine("4. View All Order Information");
                Console.WriteLine("5. View Order Information by UserID");
                Console.WriteLine("6. Add Dummy Data to Database");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                string? input = Console.ReadLine();
                string choice = input ?? "";


                switch (choice)
                {
                    case "1":
                        ShowUserInformation();
                        break;
                    case "2":
                        ShowUserDetailsByID();
                        break;
                    case "3":
                        ShowProductInformation();
                        break;
                    case "4":
                        ShowOrderInformation();
                        break;
                    case "5":
                        ShowOrderInformationByUserID();
                        break;
                    case "6":
                        AddDummyData();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays user information
        /// </summary>
        private static void ShowUserInformation()
        {
            using EFCoreCodeFirstDBContext context = new();
            List<User> usersWithDetails = context.Users.Include(u => u.UserDetails).ToList();
            Console.WriteLine("User List:");
            foreach (User user in usersWithDetails)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Password: {user.Password}, EmailConfirmed: {user.EmailConfirmed}");
            }
        }

        /// <summary>
        /// Displays product information
        /// </summary>
        private static void ShowProductInformation()
        {
            using EFCoreCodeFirstDBContext context = new();
            List<Product> products = context.Products.ToList();
            Console.WriteLine("Product List:");
            foreach (Product product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
            }
        }

        /// <summary>
        /// Displays user details by ID
        /// </summary>
        private static void ShowUserDetailsByID()
        {
            Console.Write("Enter the User ID: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                using EFCoreCodeFirstDBContext context = new();
                User? user = context.Users.Include(u => u.UserDetails).FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    Console.WriteLine($"User Details - ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Password: {user.Password}, EmailConfirmed: {user.EmailConfirmed}");
                    if (user.UserDetails != null)
                    {
                        Console.WriteLine($"User Details - Avatar: {user.UserDetails.Avatar}, Age: {user.UserDetails.Age}, Birthday: {user.UserDetails.Birthday}");
                    }
                    else
                    {
                        Console.WriteLine("No User Details available.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for User ID.");
            }
        }

        /// <summary>
        /// Displays order information
        /// </summary>
        private static void ShowOrderInformation()
        {
            using EFCoreCodeFirstDBContext context = new();
            List<UserOrder> ordersWithProducts = context.UserOrders.Include(o => o.OrderProducts).ToList();

            Console.WriteLine("Order List:");
            foreach (UserOrder order in ordersWithProducts)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Order Date: {order.OrderDate}");

                if (order.OrderProducts != null)
                {
                    Console.WriteLine("Products:");
                    foreach (UserOrderProduct product in order.OrderProducts)
                    {
                        Console.WriteLine($"  Product ID: {product.ProductID}, Quantity: {product.Quantity}, Note: {product.Note}, Discount: {product.Discount}");
                    }
                }
            }
        }

        /// <summary>
        /// Displays order information by UserID
        /// </summary>
        private static void ShowOrderInformationByUserID()
        {
            Console.Write("Enter the User ID: ");
            if (int.TryParse(Console.ReadLine(), out int userID))
            {
                using EFCoreCodeFirstDBContext context = new();
                List<UserOrder> userOrders = context.UserOrders
                        .Where(order => order.UserID == userID)
                        .Include(order => order.OrderProducts.Where(op => op != null).ToList())
                        .ToList();
                if (userOrders.Any())
                {
                    Console.WriteLine($"Order Information for User with ID {userID}:");
                    foreach (UserOrder? order in userOrders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderID}, Order Date: {order.OrderDate}");

                        foreach (UserOrderProduct orderProduct in order.OrderProducts ?? Enumerable.Empty<UserOrderProduct>())
                        {
                            if (orderProduct.Product != null)
                            {
                                Console.WriteLine($"  Product ID: {orderProduct.ProductID}, Quantity: {orderProduct.Quantity}, Note: {orderProduct.Note}, Discount: {orderProduct.Discount}");
                                Console.WriteLine($"    Product Name: {orderProduct.Product.Name}, Price: {orderProduct.Product.Price}, Description: {orderProduct.Product.Description}");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"No orders found for User with ID {userID}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for User ID. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Adds dummy data to the database
        /// </summary>
        private static void AddDummyData()
        {
            Console.WriteLine("Choose what you want to add:");
            Console.WriteLine("1. Dummy User");
            Console.WriteLine("2. Dummy Product");
            Console.WriteLine("3. Dummy UserOrder");
            Console.WriteLine("4. Dummy UserOrderProduct");

            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();
            string choice = input ?? "";


            switch (choice)
            {
                case "1":
                    AddDummyUsers();
                    break;
                case "2":
                    AddDummyProducts();
                    break;
                case "3":
                    AddDummyOrders();
                    break;
                case "4":
                    AddDummyOrdersProduct();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        /// <summary>
        /// Adds dummy users to the database
        /// </summary>
        private static void AddDummyUsers()
        {
            Console.Write("Enter the number of dummy users to add: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfUsers))
            {
                using (EFCoreCodeFirstDBContext context = new())
                {
                    DummyDataGenerator dataGenerator = new(context);
                    dataGenerator.GenerateDummyUsers(numberOfUsers);
                }
                Console.WriteLine($"{numberOfUsers} dummy users added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Adds dummy products to the database
        /// </summary>
        private static void AddDummyProducts()
        {
            Console.Write("Enter the number of dummy products to add: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfProducts))
            {
                using (EFCoreCodeFirstDBContext context = new())
                {
                    ProductDummyDataGenerator dataGenerator = new(context);
                    dataGenerator.GenerateDummyProducts(numberOfProducts);
                }
                Console.WriteLine($"{numberOfProducts} dummy products added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Adds dummy orders to the database
        /// </summary>
        private static void AddDummyOrders()
        {
            Console.Write("Enter the number of dummy orders to add: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfOrders))
            {
                using (EFCoreCodeFirstDBContext context = new())
                {
                    UserOrderDummyDataGenerator dataGenerator = new(context);
                    dataGenerator.GenerateDummyUserOrders(numberOfOrders);
                }
                Console.WriteLine($"{numberOfOrders} dummy orders added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Adds dummy order products to the database
        /// </summary>
        private static void AddDummyOrdersProduct()
        {
            Console.Write("Enter the number of dummy orders to add: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfOrders))
            {
                using (EFCoreCodeFirstDBContext context = new())
                {
                    UserOrderProductDummyDataGenerator dataGenerator = new(context);
                    dataGenerator.GenerateDummyUserOrderProducts(numberOfOrders);
                }
                Console.WriteLine($"{numberOfOrders} dummy orders added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }


    }
}
