using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IProductOrderRepository
    {
        List<ProductOrder> GetProductOrders();
        ProductOrder AddProductOrder(ProductOrder newProductOrder);
        List<ProductOrder> GetProductOrderByOrder(int orderID);
        List<ProductOrder> GetCustomerProductOrders(Customer customer);

    }
}