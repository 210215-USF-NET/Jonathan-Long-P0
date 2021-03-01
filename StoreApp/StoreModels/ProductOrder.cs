namespace StoreModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductOrder
    {
        //Properties
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}