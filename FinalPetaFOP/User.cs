using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public void Run()
        {
            List<string> productList = new List<string>();

            var keepRunning = true;

            User userInfo = Program.GetUserInfo();

            Console.WriteLine($"Welcome, {userInfo.Name}!");

            while (keepRunning)
            {
                var optionSelect = "Please select an option: " +
                                    "\n1. Add Products" +
                                    "\n2. Display Products" +
                                    "\n3. Logout";

                Console.WriteLine("");
                Console.WriteLine(optionSelect);

                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        DisplayOrder(productList);
                        break;

                    case 2:
                        Warehouse warehouse = new Warehouse();
                        warehouse.DisplayProducts(productList);
                        break;

                    case 3:
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public void DisplayOrder(List<string> productList)
        {
            Console.WriteLine("Test");
        }
    }
}