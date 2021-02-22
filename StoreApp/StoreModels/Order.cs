using System;
namespace StoreModels
{
    /// <summary>
    /// This class contains all the necessary fields and properties for customer orders 
    /// </summary>
    public class Order
    {
        //Fields
        private int orderID;
        private double total;
        private DateTime date;
        private Customer customer;
        private Location location;

        //Constructor(s)
        

        //Properties
        public int OrderID
        {
            get {return orderID;}
            set {orderID = value;}
        }
        public double Total
        {
            get {return total;}
            set {total = value;}
        }
        public DateTime Date
        {
            get{return date;}
            set{date = value;}
        }
        public Customer Customer
        {
            get {return customer;}
            set {customer = value;}
        }
        public Location Location
        {
            get {return location;}
            set {location = value;}
        }
    }
}