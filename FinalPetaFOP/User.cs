using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class User
    {
        public void Order()
        {
            List<string> productList = new List<string>();

            var keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("");

                Program.GetUserInfo();

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
                        Menu(productList);
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
        public void Menu(List<string> productList)
        {
            Console.WriteLine("Test");
        }
    }
}