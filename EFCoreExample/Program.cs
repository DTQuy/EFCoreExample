// See https://aka.ms/new-console-template for more information

// Tạo thêm UserOrders => 1-n: 1 user có nhiều đơn hàng
// Tạo thêm Product => 1 table
// Tạo UserOrderProduct (giống bảng product: quantity, note, discount) quan hệ 1-n với UserOder

//using EFCoreExample.Entity;
//using Microsoft.EntityFrameworkCore;

//namespace EFCoreExample
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            bool exit = false;
//            while (!exit)
//            {
//                Console.WriteLine("MENU:");
//                Console.WriteLine("1. View User Information");
//                Console.WriteLine("2. View Product Information");
//                Console.WriteLine("3. View User Details by ID");
//                Console.WriteLine("4. Exit");

//                Console.Write("Enter your choice: ");
//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        ShowUserInformation();
//                        break;
//                    case "2":
//                        ShowProductInformation();
//                        break;
//                    case "3":
//                        ShowUserDetailsByID();
//                        break;
//                    case "4":
//                        exit = true;
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }
//            }
//        }

//        private static void ShowUserInformation()
//        {
//            using EFCoreCodeFirstDBContext context = new();
//            List<User> usersWithDetails = context.Users.Include(u => u.UserDetails).ToList();
//            Console.WriteLine("User List:");
//            foreach (User user in usersWithDetails)
//            {
//                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Password: {user.Password}, EmailConfirmed: {user.EmailConfirmed}");
//            }
//        }

//        private static void ShowProductInformation()
//        {
//            using EFCoreCodeFirstDBContext context = new();
//            List<Product> products = context.Product.ToList();
//            Console.WriteLine("Product List:");
//            foreach (Product product in products)
//            {
//                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
//            }
//        }

//        private static void ShowUserDetailsByID()
//        {
//            Console.Write("Enter the User ID: ");
//            if (int.TryParse(Console.ReadLine(), out int userId))
//            {
//                using EFCoreCodeFirstDBContext context = new();
//                User? user = context.Users.Include(u => u.UserDetails).FirstOrDefault(u => u.Id == userId);
//                if (user != null)
//                {
//                    Console.WriteLine($"User Details - ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Password: {user.Password}, EmailConfirmed: {user.EmailConfirmed}");
//                    if (user.UserDetails != null)
//                    {
//                        Console.WriteLine($"User Details - Avatar: {user.UserDetails.Avatar}, Age: {user.UserDetails.Age}, Birthday: {user.UserDetails.Birthday}");
//                    }
//                    else
//                    {
//                        Console.WriteLine("No User Details available.");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("User not found.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid input for User ID.");
//            }
//        }
//    }
//}



using EFCoreExample;
using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

using (EFCoreCodeFirstDBContext context = new())
{
    List<User> users = context.Users.ToList();
    List<User> data = context.Users.FromSqlRaw("SELECT * FROM \"Users\"u").ToList();

    User user = new()
    {
        Name = "TestFirstName",
        Email = "test@test.com"
    };

    _ = context.Users.Add(user);
    _ = context.SaveChanges();

    Console.WriteLine("Inserted Name: " + user.Name);
}

//using (DisableObject disableObject = new DisableObject())
//{

//}

Console.WriteLine("321321");
Console.ReadLine();
