using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Warehouse");
            Console.WriteLine("3. User");

            Console.Write("Enter choice: ");
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
                    user.Order();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        }
            public static string GetUserInfo()
            {
                Console.Write("Please enter your username: ");
                string name = Console.ReadLine();

                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();

                return $"Name: {name}, Password: {password}";
            }
        }
    }


