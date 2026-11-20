using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    internal class Program
    {
        public static List<Admin> adminList = new List<Admin>();

        public static List<Warehouse> warehouseList = new List<Warehouse>();

        public static List<User> userList = new List<User>();

        public static List<Warehouse> productList = new List<Warehouse>();

        public static List<OrderRecord> orderList = new List<OrderRecord>();

        static void Main(string[] args)
        {
            Admin.GetInitialValues();

            var keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Warehouse");
                Console.WriteLine("3. User");
                Console.WriteLine("4. Exit");

                var userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out int userInput))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (userInput)
                {
                    case 1:
                        Login("_admin");
                        break;

                    case 2:
                        Login("_warehouse");
                        break;

                    case 3:
                        Login("_user");
                        break;

                    case 4:
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } 
        }
        
        public static void Login(string accountType)
        {
            while (true)
            {
                Console.Write("\nPlease enter your username: ");
                string name = Console.ReadLine();

                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Fields cannot be empty.");
                    continue;
                }

                if (!name.EndsWith(accountType))
                {
                    Console.WriteLine($"Please use an account ending in {accountType}.");
                    continue;
                }

                if (accountType == "_admin")
                {
                    Admin admin = adminList.FirstOrDefault(
                        a => a.Name == name && a.Password == password);

                    if (admin != null)
                    {
                        Console.WriteLine("Admin login successful!");
                        admin.Run();
                        return;
                    }
                }
                else if (accountType == "_warehouse")
                {
                    Warehouse warehouse = warehouseList.FirstOrDefault(
                        w => w.Name == name && w.Password == password);

                    if (warehouse != null)
                    {
                        Console.WriteLine("Warehouse login successful!");
                        warehouse.Run();
                        return;
                    }
                }
                else if (accountType == "_user")
                {
                    User user = userList.FirstOrDefault(
                        u => u.Name == name && u.Password == password);

                    if (user != null)
                    {
                        Console.WriteLine("User login successful!");
                        user.Run();
                        return;
                    }
                }

                Console.WriteLine("Incorrect username or password. Please try again.");
            }
        }
    }
}


