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
         List<Order> GetLocationOrderASC(int locationID);
         List<Order> GetLocationOrderDESC(int locationID);
        List<Order> GetLocationOrderASCTotal(int locationID);
        List<Order> GetLocationOrderDESCTotal(int locationID);
        List<Order> GetCustomerOrdersASC(int custID);
        List<Order> GetCustomerOrdersDESC(int custID);
        List<Order> GetCustomerOrdersASCTotal(int custID);
        List<Order> GetCustomerOrdersDESCTotal(int custID);
    }
}