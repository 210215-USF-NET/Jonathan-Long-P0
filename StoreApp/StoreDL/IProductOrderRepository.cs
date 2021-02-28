using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IProductOrderRepository
    {
        List<ProductOrder> GetProductOrders();
        ProductOrder addProductOrder(ProductOrder newProductOrder);
        List<ProductOrder> GetProductOrderByOrder(int orderID);

    }
}