using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using Serilog;
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
            Console.WriteLine("[2] - Back to main menu");
            Console.WriteLine("Option:");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    LocationHistory();
                    break;
                case "1":
                    UpdateItem();
                    break;
                case "2":
                    BackToMainMenu();
                    break;
                default:
                    Console.WriteLine("Incorrect option, please try again");
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
            Location loc = null;
            bool foundLoc = false;
            int option;
            do{
                Console.WriteLine("Enter store code to view inventory history:");
                option = int.Parse(Console.ReadLine());
                loc = _locationBL.GetSpecificLocation(option);
                if(loc == null)
                {
                    Console.WriteLine("Invalid location id, please search again");
                }else{
                    foundLoc = true;
                }
            }while(!foundLoc);
            Console.WriteLine("Select order history format:");
            Console.WriteLine("\t[1] - Date(Ascending)\n\t[2] - Date(Descending)\n\t[3] - Total(Highest)\n\t[4] - Total(Lowest)");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                   foreach(var item in _orderBL.GetLocationOrderASC(loc.LocationID))
                   {
                       Console.WriteLine(item.ToString());
                       _productBL.ProductsByOrder(item.OrderID);
                   }
                    break;
                case 2:
                    foreach(var item in _orderBL.GetLocationOrderDESC(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                        _productBL.ProductsByOrder(item.OrderID);
                    }
                    break;
                case 3:
                    foreach(var item in _orderBL.GetLocationOrderASCTotal(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                        _productBL.ProductsByOrder(item.OrderID);
                    }
                    break;
                case 4:
                    foreach(var item in _orderBL.GetLocationOrderDESCTotal(loc.LocationID))
                    {
                        Console.WriteLine(item.ToString());
                        _productBL.ProductsByOrder(item.OrderID);
                    }
                    break;
                default:
                        Console.WriteLine("Incorrect option, please try again");
                        break;
            }
        }
        public void UpdateItem()
        {
            foreach(var item in _locationBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
            bool foundLoc = false;
            Location loc = null;
            int option;
            do{
                try
                {
                    Console.WriteLine("Enter location code for store to update inventory:");
                    option = int.Parse(Console.ReadLine());
                    loc = _locationBL.GetSpecificLocation(option);
                    if(loc == null)
                    {
                        Console.WriteLine("Invalid location id, please search again");
                    }else{
                        foundLoc = true;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid store code, make sure to enter a number");
                    Log.Error("Incorrect input for store id");
                }
            }while(!foundLoc);
            
            foreach(var item in _itemBL.GetItemsByLocation(loc.LocationID))
            {
                Console.WriteLine($"Item ID: {item.ItemID}");
                Console.WriteLine(item.Product.ToString());
                Console.WriteLine(item.ToString());
            }
            try
            {
                Console.WriteLine("Select Item ID to replenish inventory:");
                int choice = int.Parse(Console.ReadLine());
                Item item2BUpdated = _itemBL.GetItemByID(choice);
                if(item2BUpdated == null)
                {
                    Console.WriteLine("Error - did not select a valid ItemID");
                }
                else
                {
                    Console.WriteLine($"Enter new quantity for {item2BUpdated.Product.ProductName} at {item2BUpdated.Location.LocationName}:");
                    int q = int.Parse(Console.ReadLine());
                    _itemBL.UpdateItem(item2BUpdated, q);
                    Console.WriteLine("Successfully updated!");
                    Log.Information($"Inventory {item2BUpdated.Product.ProductName} updated to {q}");
                }
                Console.WriteLine();
            }
            catch(FormatException)
            {
                Console.WriteLine("Error - incorrect entry for item id");
                Log.Error("Incorrect entry for when selecting item id for updating inventory");
            }
        }
        public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
            menu.Start();
        }
    }
}