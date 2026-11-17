using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }

        List<User> userList = new List<User>();

        List<Warehouse> productList = new List<Warehouse>();
        public void Run()
        {
            

            var keepRunning = true;

            Program.UserLogin();

            while (keepRunning)
            {
                var optionSelect = "Please select an option: " +
                                    "\n1. Add Products" +
                                    "\n2. Display Products" +
                                    "\n3. Inactivate User" +
                                    "\n4. Display Users" +
                                    "\n5. Display Inactive Users" +
                                    "\n6. Display Active Users" +
                                    "\n7. Display Products" +
                                    "\n8. Display Orders" +
                                    "\n9. Logout";

                Console.WriteLine("");

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
                        //UpdatePassword();
                        break;
                    case 2:
                        //InactivateUser;
                        break;
                    case 3:
                        //Program.GetUserInfo();
                        break;
                    case 4:
                        //DisplayUsers();
                        break;
                    case 5:
                        //DisplayInactiveUsers();
                        break;
                    case 6:
                        //DisplayActiveUsers();
                        break;
                    case 7:
                        Warehouse warehouse = new Warehouse();
                        warehouse.DisplayProducts(Program.productList);
                        break;
                    case 8:
                        //DisplayOrders();
                        break;
                    case 9:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public void UpdatePassword(List<string> productList)
        {
            
        }
        public void InactivateUser(List<string> productList)
        {

        }
        public static User AddUser(List<string> productList)
        {
            Console.Write("\nPlease enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();

            Admin admin = new Admin();

            if (admin.userList.Any(u => u.Name == name && u.Password == password))
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

            Console.WriteLine($"User {name} has been successfully added.");

            User userInfo = new User(name, password);

            admin.userList.Add(userInfo);

            return userInfo;
        }
        public static void DisplayUsers()
        {
            if (Program.userList.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (User user in Program.userList)
            {
                Console.WriteLine($"Username: {user.Name}");
            }
        }
        public void DisplayInactiveUser(List<string> productList)
        {

        }
        public void DisplayActiveUsers(List<string> productList)
        {

        }
        public void DisplayProducts(List<string> productList)
        {

        }
       
    }
}

