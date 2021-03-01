
namespace StoreModels
{
    /// <summary>
    /// This class contains all the necessary fields and properties that define a product for the store 
    /// </summary>
    public class Product
    {
        //Fields
        private int productID;
        private string productName;
        private double price;
        private string description;

        //Constructor(s)
        public Product(string productName, double price, string description)
        {
            this.productName = productName;
            this.price = price;
            this.description = description;
        }
        //Properties
        public int ProductID
        {
            get {return productID;}
            set {productID = value;}
        }
        public string ProductName
        {
            get {return productName;}
            set {productName = value;}
        }
        public double Price
        {
            get {return price;}
            set {price = value;}
        }
        public string Description
        {
            get {return description;}
            set {description = value;}
        }
        //Methods
        public override string ToString()
        {
            return $"{this.ProductName} Details: \n\tProductID: {this.ProductID}\n\tPrice: ${this.Price}\n\tDescription: {this.Description}";
        }

    }
}