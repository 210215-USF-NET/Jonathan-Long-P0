namespace StoreModels
{
    /// <summary>
    /// This class is used define the quantity of a product at a specific store location
    /// </summary>
    public class Item
    {
        //Fields
        private int itemID;
        private int quantity;
        private Product product;
        private Location location;

        //Constructor(s)
        public Item(int quantity, Product product, Location location)
        {
            this.quantity = quantity;
            this.product = product;
            this.location = location;
        }
        //Properties
        public int ItemID
        {
            get {return itemID;}
            set {itemID = value;}
        }
        public int Quantity
        {
            get {return quantity;}
            set {quantity = value;}
        }
        public Product Product
        {
            get {return product;}
            set {product = value;}
        }
        public Location Location
        {
            get {return location;}
            set {location = value;}
        }
        //Methods
        public override string ToString()
        {
            return $"\tQuantity: {this.Quantity}";
        }
    }
}