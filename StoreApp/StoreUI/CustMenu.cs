using System;
using StoreModels;
namespace StoreUI
{
    /// <summary>
    /// This class contains all the fields and methods for the customer menu
    /// </summary>
    public class CustMenu : IMenu
    {
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
            Console.WriteLine("[1] - Place Order");
            Console.WriteLine("[2] - View Order History");
            Console.WriteLine("Option:");
            string option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    CreateCustomer();
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
            Console.WriteLine(newCustomer.FirstName);
            Console.WriteLine(newCustomer.LastName);
            Console.WriteLine(newCustomer.PhoneNumber);
        }
    }
}