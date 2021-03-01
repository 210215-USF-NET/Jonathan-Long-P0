using System.Collections.Generic;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    public class ProductOrderBL : IProductOrderBL
    {
        private IProductOrderRepository _repo;
        public ProductOrderBL(IProductOrderRepository repo)
        {
            _repo = repo;
        }
        public void AddProductOrder(ProductOrder newProductOrder)
        {
            _repo.AddProductOrder(newProductOrder);
        }

        public List<ProductOrder> GetProductOrderByOrder(int orderID)
        {
            return _repo.GetProductOrderByOrder(orderID);
        }

        public List<ProductOrder> GetProductOrders()
        {
            return _repo.GetProductOrders();
        }
    }
}