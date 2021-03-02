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

        public Order FindOrder(double totalCost)
        {
            return _repo.FindOrder(totalCost);
        }

        public List<Order> GetCustomerOrders(int custID)
        {
            return _repo.GetCustomerOrders(custID);
        }

        public List<Order> GetLocationOrderASC(int locationID)
        {
            return _repo.GetLocationOrderASC(locationID);
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            return _repo.GetLocationOrderASCTotal(locationID);
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            return _repo.GetLocationOrderDESC(locationID);
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            return _repo.GetLocationOrderDESCTotal(locationID);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
    }
}