using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Admin()
        {
        }
        public Admin(string name, string password)
        {
            Name = name;
            Password = password;
        }

       
        public void Run()
        {
            var keepRunning = true;

            while (keepRunning)
            {
                var optionSelect = "Please select an option: " +
                                    "\n1. Update Password" +
                                    "\n2. Inactivate User" +
                                    "\n3. Add User" +
                                    "\n4. Display All Users" +
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
                        AddUser(Program.productList);
                        break;
                    case 4:
                        DisplayUsers();
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
                        User user = new User();
                        user.DisplayOrder(Program.productList);
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
        public static void GetInitialValues()
        {
            Program.adminList.Add(new Admin("sean_admin", "admin123"));

            Program.warehouseList.Add(new Warehouse("sean_warehouse", "warehouse123"));

            Program.userList.Add(new User("sean_user", "user123"));
        }

        public void UpdatePassword(List<string> productList)
        {
            Console.WriteLine("Test");
        }
        public void InactivateUser(List<string> productList)
        {

        }
        public static User AddUser(List<Warehouse> productList)
        {
            Console.Write("\nPlease enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();



            if (Program.userList.Any(u => u.Name == name))
            {
                Console.WriteLine("Username already exists.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty. Please try again.");
                return null;
            }
            if (!name.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                Console.WriteLine("Username can only contain letters, numbers, and underscores.");
                return null;
            }
            if (!password.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password can only contain letters and numbers.");
                return null;
            }

            Console.WriteLine($"User {name} has been successfully added.");

            User userInfo = new User(name, password);

            Program.userList.Add(userInfo);

            return userInfo;
        }
        public static void DisplayUsers()
        {
            if (Program.userList.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            int i = 1;

            foreach (User user in Program.userList)
            {
                Console.WriteLine($"{i}: {user.Name}");
                i++;
            }
        }
        public void DisplayInactiveUser(List<string> productList)
        {
            Console.WriteLine("Test");
        }
        public void DisplayActiveUsers(List<string> productList)
        {
            Console.WriteLine("Test");
        }
    }
}

