using System;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    /// <summary>
    /// This class contains all the fields and methods for the customer menu
    /// </summary>
    public class CustMenu : IMenu
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IItemBL _itemBL;
        public CustMenu(ICustomerBL customerBL,ILocationBL locationBL,IProductBL productBL,IItemBL itemBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _itemBL = itemBL;
        }
        public void Start()
        {
            bool menuRun = true;
            do
            {
            Console.WriteLine();
            Console.WriteLine("Customer Menu");
            Console.WriteLine("--------------");
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("[0] - New Customer");
            Console.WriteLine("[1] - Search Existing Customers");
            Console.WriteLine("[2] - Select a Store Location");
            Console.WriteLine("[3] - Back to main menu");
            Console.WriteLine("Option:");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    CreateCustomer();
                    break;
                case "1":
                    GetCustomers();
                    break;
                case "2":
                    GetStores();
                    break;
                case "3":
                    BackToMainMenu();
                    menuRun = false;
                    break;
            }
            } while(menuRun);
        }
        public void CreateCustomer()
        {
            Console.WriteLine("Enter customer first name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter customer last name: ");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter customer phone number: ");
            string phoneNumber = Console.ReadLine();
            Customer newCustomer = new Customer(fName, lName, phoneNumber);
            _customerBL.AddCustomer(newCustomer); //BL add customer

        }
        public void GetCustomers()
        {
            Console.WriteLine("Customer First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Customer Last Name: ");
            string lastName = Console.ReadLine();
            int check = 0;
            foreach(var item in _customerBL.GetCustomers())
            {
                if(item.FirstName == firstName && item.LastName == lastName)
                {
                    Console.WriteLine(item.ToString());
                    check++;
                }
                
            }
            if(check == 0)
            {
                Console.WriteLine("No matching customer found");
            }
        }
        public void GetStores()
        {
            foreach(var item in _locationBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Enter a Store Code to Shop:");
            int storeCode = int.Parse(Console.ReadLine());
            Location selectedLocation = _locationBL.GetSpecificLocation(storeCode);
            if(selectedLocation == null)
            {
                Console.WriteLine("Error - store code not valid");
            } else
            {
                Console.WriteLine($"{selectedLocation.LocationName} Inventory:");
                foreach(var item in _itemBL.GetItems())
                {
                    Console.WriteLine(item.Product.ToString());
                }

            }
        }
        public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL, _itemBL);
            menu.Start();
        }
    }
}