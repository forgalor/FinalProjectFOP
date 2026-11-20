using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

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
                        UpdatePassword();
                        break;
                    case 2:
                        InactivateUser();
                        break;
                    case 3:
                        AddUser();
                        break;
                    case 4:
                        DisplayUsers();
                        break;
                    case 5:
                        DisplayInactiveUser();
                        break;
                    case 6:
                        DisplayActiveUsers();
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
            Program.adminList.Add(new Admin("test_admin", "123"));

            Program.warehouseList.Add(new Warehouse("test_warehouse", "123"));

            Program.userList.Add(new User("test_user", "123"));
        }
        public void UpdatePassword()
        {

            DisplayUsers();

            int totalAccounts = Program.adminList.Count + Program.warehouseList.Count + Program.userList.Count;

            if (totalAccounts == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out int userNumber) ||
                userNumber < 1 || userNumber > totalAccounts)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            int selectedNumber = 1;

            foreach (Admin admin in Program.adminList)
            {
                if (selectedNumber == userNumber)
                {
                    UpdateAccountPassword(admin);
                    return;
                }
                selectedNumber++;
            }

            foreach (Warehouse warehouse in Program.warehouseList)
            {
                if (selectedNumber == userNumber)
                {
                    UpdateAccountPassword(warehouse);
                    return;
                }
                selectedNumber++;
            }

            foreach (User user in Program.userList)
            {
                if (selectedNumber == userNumber)
                {
                    UpdateAccountPassword(user);
                    return;
                }
                selectedNumber++;
            }
        }
        private void UpdateAccountPassword(Admin admin)
        {
            Console.Write($"Please enter the new password for {admin.Name}: ");
            string newPassword = Console.ReadLine();

            Console.Write("Confirm the new password: ");
            string confirmPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (!newPassword.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password can only contain letters and numbers.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            admin.Password = newPassword;

            Console.WriteLine("Password updated successfully.");
        }
        private void UpdateAccountPassword(Warehouse warehouse)
        {
            Console.Write($"Please enter the new password for {warehouse.Name}: ");
            string newPassword = Console.ReadLine();

            Console.Write("Confirm the new password: ");
            string confirmPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (!newPassword.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password can only contain letters and numbers.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            warehouse.Password = newPassword;

            Console.WriteLine("Password updated successfully.");
        }
        private void UpdateAccountPassword(User user)
        {
            Console.Write($"Please enter the new password for {user.Name}: ");
            string newPassword = Console.ReadLine();

            Console.Write("Confirm the new password: ");
            string confirmPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (!newPassword.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password can only contain letters and numbers.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            user.Password = newPassword;

            Console.WriteLine("Password updated successfully.");
        }
        public static int SelectAccount()
        {
            DisplayUsers();

            int totalAccounts = Program.adminList.Count + Program.warehouseList.Count + Program.userList.Count;

            if (totalAccounts == 0)
            {
                Console.WriteLine("No accounts found.");
                return -1;
            }

            if (!int.TryParse(Console.ReadLine(), out int choice) ||
                choice < 1 || choice > totalAccounts)
            {
                Console.WriteLine("Invalid selection.");
                return -1;
            }

            return choice;
        }
        public void InactivateUser()
        {
            int choice = SelectAccount();

            if (choice == -1)
                return;

            int adminCount = Program.adminList.Count;
            int warehouseCount = Program.warehouseList.Count;

            if (choice <= adminCount)
            {
                Program.adminList[choice - 1].IsActive = false;
            }
            else if (choice <= adminCount + warehouseCount)
            {
                Program.warehouseList[choice - adminCount - 1].IsActive = false;
            }
            else
            {
                Program.userList[choice - adminCount - warehouseCount - 1].IsActive = false;
            }

            Console.WriteLine("Account successfully inactivated.");
        }
       
        public static void AddUser()
        {
            Console.Write("\nPlease enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();


            if (Program.adminList.Any(a => a.Name == name) || Program.warehouseList.Any(w => w.Name == name) || Program.userList.Any(u => u.Name == name))
            {
                Console.WriteLine("Username already exists.");
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty. Please try again.");
                return;
            }
            if (!name.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                Console.WriteLine("Username can only contain letters, numbers, and underscores.");
                return;
            }
            if (!password.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password can only contain letters and numbers.");
                return;
            }

            if (name.EndsWith("_admin"))
            {
                Program.adminList.Add(new Admin(name, password));
            }
            else if (name.EndsWith("_warehouse"))
            {
                Program.warehouseList.Add(new Warehouse(name, password));
            }
            else if (name.EndsWith("_user"))
            {
                Program.userList.Add(new User(name, password));
            }
            else
            {
                Console.WriteLine("Username must end with _admin, _warehouse, or _user.");
                return;
            }

            Console.WriteLine($"Account {name} has been successfully added.");
            return;
        }

        public static void DisplayUsers()
        {
            if (Program.userList.Count == 0 && Program.adminList.Count == 0 && Program.warehouseList.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            int i = 1;

            foreach (Admin admin in Program.adminList)
            {
                
                 Console.WriteLine($"{i}. {admin.Name}");
                 i++;
                
            }

            foreach (Warehouse warehouse in Program.warehouseList)
            {
                Console.WriteLine($"{i}. {warehouse.Name}");
                i++;
  
            }

            foreach (User user in Program.userList)
            {
                Console.WriteLine($"{i}. {user.Name}");
                i++;
            }
        }
        public void DisplayInactiveUser()
        {
            int i = 1;
            bool found = false;

            foreach (Admin admin in Program.adminList)
            {
                if (!admin.IsActive)
                {
                    Console.WriteLine($"{i}. {admin.Name}");
                    i++;
                    found = true;
                }
            }

            foreach (Warehouse warehouse in Program.warehouseList)
            {
                if (!warehouse.IsActive)
                {
                    Console.WriteLine($"{i}. {warehouse.Name}");
                    i++;
                    found = true;
                }
            }

            foreach (User user in Program.userList)
            {
                if (!user.IsActive)
                {
                    Console.WriteLine($"{i}. {user.Name}");
                    i++;
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No inactive accounts found.");
        }
        public void DisplayActiveUsers()
        {
            int i = 1;
            bool found = false;

            foreach (Admin admin in Program.adminList)
            {
                if (admin.IsActive)
                {
                    Console.WriteLine($"{i}. {admin.Name}");
                    i++;
                    found = true;
                }
            }

            foreach (Warehouse warehouse in Program.warehouseList)
            {
                if (warehouse.IsActive)
                {
                    Console.WriteLine($"{i}. {warehouse.Name}");
                    i++;
                    found = true;
                }
            }

            foreach (User user in Program.userList)
            {
                if (user.IsActive)
                {
                    Console.WriteLine($"{i}. {user.Name}");
                    i++;
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No active accounts found.");
        }
        public void DisplayOrders(List<Warehouse> productList)
        {
            var userOrders = Program.orderList;
            if (userOrders.Count == 0)
            {
                Console.WriteLine("You have no orders yet.");
                return;
            }

            foreach (var order in userOrders)
            {
                Console.WriteLine("\nOrder Details");
                Console.WriteLine($"Product Name: {order.ProductName}");
                Console.WriteLine($"Quantity Ordered: {order.Quantity}");
            }
        }
    }
}
