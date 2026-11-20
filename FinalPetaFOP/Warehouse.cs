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
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Password { get; set; }

        public Warehouse(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public Warehouse()
        {
        }

        public void Run()
        {
            var keepRunning = true;

            while (keepRunning)
            {
                var optionSelect = "Please select an option: "+ 
                                    "\n1. Add Products" + 
                                    "\n2. Display Products" +
                                    "\n3. Logout";

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
                        AddProducts(Program.productList);
                        break;
                    case 2:
                        DisplayProducts(Program.productList);
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
        public void AddProducts(List<Warehouse> productList)
        {
            Console.WriteLine("Please enter the number of products to add:");

            if (!int.TryParse(Console.ReadLine(), out int productsEntered))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (productsEntered <= 0)
            {
                Console.WriteLine("Number of products must be greater than zero.");
                return;
            }
                for (int i = 1; i <= productsEntered; i++)
            {
                Console.Write($"{i}. Enter product name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Product name cannot be empty. Please enter a valid name.");
                    i--; 
                    continue;
                }
                if (productList.Any(p => p.Name != null && p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Product already exists. Please enter a different name.");
                    i--;
                    continue;
                }

                Console.Write($"{i}. Enter product quantity: ");

                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    i--;
                    continue;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                    i--;
                    continue;
                }

                productList.Add(new Warehouse
                {
                    Name = name,
                    Quantity = quantity
                });
            }
        }
        public void DisplayProducts(List<Warehouse> productList)
        {
            if (productList.Count == 0)
                Console.WriteLine("No Record found");

            foreach (var product in productList)
            {
                Console.WriteLine($"\nProduct Name: {product.Name}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Active:");
                Console.WriteLine($"Created Date: ");
                Console.WriteLine($"Created by: ");
            }
        }
    }
}
