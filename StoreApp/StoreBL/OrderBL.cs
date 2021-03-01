using System.Collections.Generic;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepository _repo;
        public OrderBL(IOrderRepository repo)
        {
            _repo = repo;
        }
        public void AddOrder(Order newOrder)
        {
            _repo.AddOrder(newOrder);
        }

        public Order FindOrder(int orderID)
        {
            return _repo.FindOrder(orderID);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
    }
}