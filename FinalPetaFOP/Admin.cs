using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class Admin
    {
        public void Run()
        {
            var keepRunning = true;

            Program.GetUserInfo();

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
                        //UpdatePassword();
                        break;
                    case 2:
                        //InactivateUser;
                        break;
                    case 3:
                        //AddUser();
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
                        //DisplayProducts();
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

    }
 }

