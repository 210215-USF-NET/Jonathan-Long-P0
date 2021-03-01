using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
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
        private IOrderBL _orderBL;
        private IProductOrderBL _productOrderBL;
        public CustMenu(ICustomerBL customerBL,ILocationBL locationBL,IProductBL productBL,IItemBL itemBL, IOrderBL orderBL, IProductOrderBL productOrderBL)
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
            Console.WriteLine("Customer Menu");
            Console.WriteLine("--------------");
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("[0] - New Customer");
            Console.WriteLine("[1] - Search Existing Customers");
            Console.WriteLine("[2] - Select a Store Location");
            Console.WriteLine("[3] - View Order History");
            Console.WriteLine("[4] - Back to main menu");
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
                    GetOrders();
                    break;
                case "4":
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
                foreach(var item in _itemBL.GetItemsByLocation(storeCode))
                {
                    Console.WriteLine(item.Product.ToString());
                    Console.WriteLine(item.ToString());
                }
                Order newOrder = new Order(); //create new order object
                bool shop = true;
                List<Product> cartProducts = new List<Product>();
                List<int> cartQuantity = new List<int>();
                double totalCost = 0.0;
                do
                {
                    //Product selectedProduct = null;
                    Console.WriteLine();
                    Console.WriteLine("Select ProductID to add product to your order");
                    Console.WriteLine("Type \'Cancel\' to cancel order or \'Finish\' to complete your order");
                    Console.WriteLine("Selection:");
                    string option = Console.ReadLine();
                    if(option == "Cancel" || option == "cancel")
                    {
                        shop = false;
                    }
                    else if(option == "Finish" || option == "finish")
                    {
                        //Create Order
                        newOrder.Total = totalCost;  
                        newOrder.Location = selectedLocation;
                        Customer orderCust = FindCustomer();
                        if(orderCust == null)
                        {
                            Console.WriteLine("Oof, null customer");
                        }
                        else
                        {
                            newOrder.Customer = orderCust;
                        }
                        _orderBL.AddOrder(newOrder);
                       
                        //Add products to ProductOrder
                        int oID = _orderBL.FindOrder(newOrder.Total).OrderID;
                        Console.WriteLine(oID + " eh maybe worked??");
                        shop = false;
                                         
                    }
                    else if(option != "Cancel" && option != "Finish")
                    {
                        foreach(var item in _productBL.GetProducts())
                        {
                            if (int.Parse(option) == item.ProductID)
                            {
                                cartProducts.Add(item);
                                Console.WriteLine("Enter quantity:");
                                int quantity = int.Parse(Console.ReadLine());
                                cartQuantity.Add(quantity);
                                totalCost = (totalCost) + (item.Price * quantity);
                            }
                        }


                    }
                }while (shop);

            }
        }
        public Customer FindCustomer()
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
                    return item;
                }
            }
            if(check == 0)
            {
                Console.WriteLine("No matching customer found");
            }
            Customer nullCust = null;
            return nullCust;
        }
        public void GetOrders()
        {
            foreach(var item in _orderBL.GetOrders())
            {
                Console.WriteLine(item.OrderID);
            }
        }
        public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
            menu.Start();
        }
    }
}