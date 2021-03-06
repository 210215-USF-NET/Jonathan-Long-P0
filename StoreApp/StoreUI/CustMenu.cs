using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using Serilog;
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
                    GetOrderHistory();
                    break;
                case "4":
                    BackToMainMenu();
                    menuRun = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, please try again");
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
            bool correctPhoneNumberFormat = false;
            string phoneNumber = "";
            do
            {
                Console.WriteLine("Enter customer phone number: ");
                phoneNumber = Console.ReadLine();
                if(phoneNumber.Length != 12)
                {
                    Console.WriteLine("Error - phone number must be formatted xxx-xxx-xxxx");
                }
                else if(phoneNumber[3] != '-' && phoneNumber[7] != '-')
                {
                    Console.WriteLine("Error - phone number must be formatted xxx-xxx-xxxx");
                }
                else
                {
                    bool allNums = true;
                    for(int i = 0; i < 10; i++)
                    {
                        if(i == 3 || i == 7)
                        {
                            continue;
                        }
                        if(char.IsDigit(phoneNumber[i]) == false)
                        {
                            allNums = false;
                        }
                    }
                    if(allNums)
                    {
                        correctPhoneNumberFormat = true;
                    }
                    else
                    {
                        Console.WriteLine("Error - one of the entrys for the phone number is not a digit");
                    }
                }
            }while(!correctPhoneNumberFormat);
            Customer newCustomer = new Customer(fName, lName, phoneNumber);
            _customerBL.AddCustomer(newCustomer); //BL add customer
            Console.WriteLine("Customer successfully added!");
            Log.Information($"Added customer {newCustomer.FirstName} {newCustomer.LastName}");

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
            try
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
                            bool findCustomer = false;
                            do{
                            Customer orderCust = FindCustomer();
                            if(orderCust == null)
                            {
                                Console.WriteLine("No matching customer found, try searching again");
                            }
                            else
                            {
                                newOrder.Customer = orderCust;
                                findCustomer = true;
                            }
                            }while(!findCustomer);
                            _orderBL.AddOrder(newOrder);
                        
                            //Add products to ProductOrder
                            int oID = _orderBL.FindOrder(newOrder.Total).OrderID;
                            for(int i = 0; i < cartProducts.Count; i++)
                            {
                                ProductOrder po = new ProductOrder();
                                po.Order = _orderBL.FindOrder(oID);
                                po.Product = cartProducts[i];
                                po.Quantity = cartQuantity[i];
                                _productOrderBL.AddProductOrder(po);
                                Console.WriteLine("Order Summary:");
                                Console.WriteLine("--------------");
                                po.ToString();
                                _productBL.ProductsByOrder(po.Order.OrderID);
                            }
                            Console.WriteLine("Order successfully placed!");
                            Log.Information("Order Created");
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
            catch
            {
                Console.WriteLine("Something went wrong...canceling order");
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
        public void GetOrderHistory()
        {
            bool findCust = false;
            Customer customer = new Customer();
            do{
                customer = FindCustomer();
                if(customer == null)
                {
                    Console.WriteLine("Search again for a customer");
                }else{
                    findCust = true;
                }
            }while(!findCust);
            Console.WriteLine("Select order history format:");
            Console.WriteLine("\t[1] - Date(Ascending)\n\t[2] - Date(Descending)\n\t[3] - Total(Highest)\n\t[4] - Total(Lowest)");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    foreach(var item in _orderBL.GetCustomerOrdersASC(customer.CustID))
                    {
                        Console.WriteLine(item.ToString());
                        _productBL.ProductsByOrder(item.OrderID);
                    }
                        break;
                    
                    case 2:
                        foreach(var item in _orderBL.GetCustomerOrdersDESC(customer.CustID))
                        {
                            Console.WriteLine(item.ToString());
                            _productBL.ProductsByOrder(item.OrderID);
                        }
                        break;
                    case 3:
                        foreach(var item in _orderBL.GetCustomerOrdersASCTotal(customer.CustID))
                        {
                            Console.WriteLine(item.ToString());
                            _productBL.ProductsByOrder(item.OrderID);
                        }
                        break;
                    case 4:
                        foreach(var item in _orderBL.GetCustomerOrdersDESCTotal(customer.CustID))
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
            catch
            {
                Console.WriteLine("Error - incorrect option");
            }
            /*foreach(var item in _orderBL.GetCustomerOrders(customer.CustID))
            {
                Console.WriteLine(item.ToString());
                _productBL.ProductsByOrder(item.OrderID);
            }
            */
             
        }
        public void BackToMainMenu()
        {
            Menu menu = new Menu(_customerBL, _locationBL, _productBL, _itemBL, _orderBL, _productOrderBL);
            menu.Start();
        }
    }
}