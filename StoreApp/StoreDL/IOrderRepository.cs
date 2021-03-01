using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderRepository
    {
         List<Order> GetOrders();
         Order AddOrder(Order newOrder);
         Order FindOrder(int orderID);
         Order FindOrder(double totalCost);
         List<Order> GetCustomerOrders(int custID);
    }
}