namespace StoreModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductOrder
    {
        //Properties
        public Product product { get; set; }
        public Order order { get; set; }
        public int Quantity { get; set; }
    }
}