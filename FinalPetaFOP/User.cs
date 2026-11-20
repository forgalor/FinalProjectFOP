using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var keepRunning = true;

            Console.WriteLine($"Welcome, {Name}!");

            while (keepRunning)
            {
                var optionSelect = "Please select an option: " +
                                    "\n1. Order" +
                                    "\n2. Display Order" +
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
                        Order(Program.productList);
                        break;

                    case 2:
                        DisplayOrder(Program.productList);
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


        public void Order(List<Warehouse> productList)
        {
            if (productList.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            int i = 1;

            foreach (var product in productList)
            {
                Console.WriteLine($"\n{i}. Product Name: {product.Name}");
                Console.WriteLine($"Quantity Available: {product.Quantity}");
                i++;
            }

            Console.Write("\nPlease enter the number of the product you would like to order: ");

            if (!int.TryParse(Console.ReadLine(), out int productNumber) ||
                productNumber < 1 || productNumber > productList.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (productList[productNumber - 1].Quantity <= 0)
            {
                Console.WriteLine("Sorry, this product is out of stock.");
                return;
            }

            Console.Write("Please enter quantity you would like to order: ");

            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity.");
                return;
            }

            if (productList[productNumber - 1].Quantity >= quantity)
            {
                productList[productNumber - 1].Quantity -= quantity;

                OrderRecord newOrder = new OrderRecord(
                    Name,
                    productList[productNumber - 1].Name,
                    quantity
                );

                Program.orderList.Add(newOrder);

                Console.WriteLine("Order has been successfully created!");
            }
            else
            {
                Console.WriteLine("Insufficient stock.");
            }
        }
        public void DisplayOrder(List<Warehouse> productList)
        {
            var userOrders = Program.orderList
                .Where(o => o.Username == Name)
                .ToList();

            if (userOrders.Count == 0)
            {
                Console.WriteLine("You have no orders yet.");
                return;
            }

            int i = 1;

            foreach (var order in userOrders)
            {
                Console.WriteLine($"\nOrder #{i}");
                Console.WriteLine($"Username: {order.Username}");
                Console.WriteLine($"Product Name: {order.ProductName}");
                Console.WriteLine($"Quantity Ordered: {order.Quantity}");
                Console.WriteLine($"Order Date: {order.OrderDate}");

                i++;
            }
        }
    }
}