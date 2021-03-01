using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductOrderBL
    {
         void AddProductOrder(ProductOrder newProductOrder);
         List<ProductOrder> GetProductOrders();
         List<ProductOrder> GetProductOrderByOrder(int orderID);
    }
}