using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IOrderBL
    {
         List<Order> GetOrders();
         void AddOrder(Order newOrder);
         Order FindOrder(int orderID);
         Order FindOrder(double totalCost);
         List<Order> GetCustomerOrders(int custID);
         List<Order> GetLocationOrder(int locationID);
    }
}