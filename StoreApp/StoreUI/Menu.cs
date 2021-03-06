using System;
using StoreModels;
using StoreBL;
using Serilog;
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
        private IItemBL _itemBL;
        private IOrderBL _orderBL;
        private IProductOrderBL _productOrderBL;
        public Menu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IItemBL itemBL, IOrderBL orderBL, IProductOrderBL productOrderBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _itemBL = itemBL;
            _orderBL = orderBL;
            _productOrderBL = productOrderBL;

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
                    CustMenu customerMenu = new CustMenu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
                    menuRun = false;
                    customerMenu.Start();
                    break;
                case "1":
                    ManagerMenu managerMenu = new ManagerMenu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
                    Log.Information("Manager Menu Accessed");
                    menuRun = false;
                    managerMenu.Start();
                    break;
                case "2":
                    menuRun = false;
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid menu option. Please try again!");
                    break;
            }
            } while (menuRun);
        }
        public void Exit()
        {
            Console.WriteLine("Thank you for using the Ski Shop!");
        }
    }
}