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
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        public Menu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;

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
            Console.WriteLine("[0] - Customer Menu");
            Console.WriteLine("[1] - Manager Menu");
            Console.WriteLine("[2] - Exit Program");
            Console.WriteLine("Select Option: ");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    CustMenu customerMenu = new CustMenu(_customerBL, _locationBL, _productBL);
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