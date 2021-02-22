using System;
namespace StoreUI
{
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
                    //Create new customer
                    break;
            }
            } while(menuRun);
        }
    }
}