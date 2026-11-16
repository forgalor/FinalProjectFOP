using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    internal class Program
    {
        public static List<User> userList = new List<User>();

        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Warehouse");
            Console.WriteLine("3. User");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Admin admin = new Admin();
                    admin.Run();
                    break;

                case 2:
                    Warehouse warehouse = new Warehouse();
                    warehouse.Run();
                    break;

                case 3:
                    User user = new User();
                    user.Run();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }   
        }
        public static User GetUserInfo()
        {
            Console.Write("\nPlease enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();

            User userInfo = new User(name, password);

            userList.Add(userInfo);

            return userInfo;
        }
        public static void DisplayUsers()
        {
            if (userList.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (User user in userList)
            {
                Console.WriteLine($"Username: {user.Name}");
            }
        }
    }
}


