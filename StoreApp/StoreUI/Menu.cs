using System;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    /// <summary>
    /// This is the starting menu for the application. Lets you choose either the customer or manager menu.
    /// </summary>
    public class Menu : IMenu
    {
        private ICustomerBL _customerBL;
        public Menu(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }
        public void Start()
        {
            bool menuRun = true;
            do
            {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Ski Store!");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("[0] - Customer Options");
            Console.WriteLine("[1] - Manager Options");
            Console.WriteLine("[2] - Exit Program");
            Console.WriteLine("Select Option: ");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    CustMenu customerMenu = new CustMenu(_customerBL);
                    customerMenu.Start();
                    menuRun = false;
                    break;
                case "1":
                    //Go to Manager Menu
                    break;
                case "2":
                    menuRun = false;
                    break;
                default:
                    Console.WriteLine("Invalid menu option. Please try again!");
                    break;
            }
            } while (menuRun);
        }
    }
}