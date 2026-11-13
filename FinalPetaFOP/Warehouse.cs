using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class Warehouse
    {
        public void Run()
        {
            List<string> productList = new List<string>();

            var keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("");

                Program.GetUserInfo();

                var optionSelect = "Please select an option: "+ 
                                    "\n1. Add Products" + 
                                    "\n2. Display Products" +
                                    "\n3. Logout";

                Console.WriteLine("");

                Console.WriteLine(optionSelect);

                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        AddProducts(productList);
                        break;
                    case 2:
                        DisplayProducts(productList);
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
        public void AddProducts(List<string> productList)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product quantity: ");
            decimal productQuantity = Convert.ToInt32(Console.ReadLine());

            productList.Add($"Product: {productName}, Quantity: {productQuantity}");
            Console.WriteLine($"Product '{productName}' with quantity {productQuantity  } added to the warehouse.");
        }
        public void DisplayProducts(List<string> productList)
        {
            if (productList.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var product in productList)
            {
                Console.WriteLine(product);
            }
        }
    }
}
