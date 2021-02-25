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
        public CustMenu(ICustomerBL customerBL,ILocationBL locationBL,IProductBL productBL)
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL);
            menu.Start();
        }
    }
}