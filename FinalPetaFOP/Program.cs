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

        public static List<Warehouse> productList = new List<Warehouse>();

        static void Main(string[] args)
        {
            var optionSelect = "Choose an option: " +
                                    "\n1. Admin" +
                                    "\n2. Warehouse" +
                                    "\n3. User";

            Console.WriteLine(optionSelect);
            var userChoice = Console.ReadLine();

            if (!int.TryParse(userChoice, out int userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
          
            switch (userInput)
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
        public static User UserLogin()
        {
            Console.Write("\nPlease enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();

            if(userList.Any(u => u.Name == name && u.Password == password))
            {
                Console.WriteLine("User already exists. Please try again.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty. Please try again.");
                return null;
            }
            if (!name.All(char.IsLetterOrDigit) || !password.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Username and password can only contain letters and digits. Please try again.");
                return null;
            }

            User userInfo = new User(name, password);

            userList.Add(userInfo);

            return userInfo;
        }
    }
}


