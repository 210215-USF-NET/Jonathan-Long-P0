using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
namespace StoreUI
{
    public class ManagerMenu : IMenu
    {
        /// <summary>
        /// This menu is used by managers to replenish inventory and view location order history
        /// </summary>
         private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IItemBL _itemBL;
        private IOrderBL _orderBL;
        private IProductOrderBL _productOrderBL;
        public ManagerMenu(ICustomerBL customerBL,ILocationBL locationBL,IProductBL productBL,IItemBL itemBL, IOrderBL orderBL, IProductOrderBL productOrderBL)
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
            Console.WriteLine("Manager Menu");
            Console.WriteLine("--------------");
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("[0] - View Location Order History");
            Console.WriteLine("[1] - Replenish Inventory");
            Console.WriteLine("[3] - Back to main menu");
            Console.WriteLine("Option:");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    LocationHistory();
                    break;
                case "1":
                    //GetCustomers();
                    break;
                case "2":
                    //GetStores();
                    break;
                case "3":
                    BackToMainMenu();
                    break;
            }
            } while(menuRun);
        }
        public void LocationHistory()
        {
            foreach(var item in _locationBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Enter store code to view inventory history:");
            int option = int.Parse(Console.ReadLine());
            Location loc = _locationBL.GetSpecificLocation(option);
            Console.WriteLine("Select order history format:");
            Console.WriteLine("\t[1] - Date(Ascending)\n\t[2] - Date(Descending)\n\t[3] - Total(Highest)\n\t[4] - Total(Lowest)");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                   foreach(var item in _orderBL.GetLocationOrderASC(loc.LocationID))
                   {
                       Console.WriteLine(item.ToString());
                   }
                    break;
                case 2:
                    foreach(var item in _orderBL.GetLocationOrderDESC(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case 3:
                    foreach(var item in _orderBL.GetLocationOrderASCTotal(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case 4:
                    foreach(var item in _orderBL.GetLocationOrderDESCTotal(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
            }
        }

         public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
            menu.Start();
        }
    }
}