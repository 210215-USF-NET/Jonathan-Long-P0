using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class OrderRepoDB : IOrderRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public OrderRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Order AddOrder(Model.Order newOrder)
        {
            _context.Orders.Add(_mapper.ParseOrder(newOrder));
            _context.SaveChanges();
            return newOrder;
        }

        public Order FindOrder(int orderID)
        {
            return _context.Orders
            .Include("Cust")
            .AsNoTracking()
            .Include("Location")
            .AsNoTracking()
            .Select(x => _mapper.ParseOrder(x))
            .ToList()
            .FirstOrDefault(x => x.OrderID == orderID);
        }

        public Order FindOrder(double totalCost)
        {
            return _context.Orders
            .Include("Cust")
            .AsNoTracking()
            .Include("Location")
            .AsNoTracking()
            .Select(x => _mapper.ParseOrder(x))
            .ToList()
            .FindLast(x => x.Total == totalCost);
        }

        public List<Order> GetCustomerOrders(int custID)
        {
            return _context.Orders
            .Include("Cust")
            .AsNoTracking()
            .Include("Location")
            .AsNoTracking()
            .Select(x => _mapper.ParseOrder(x))
            .ToList()
            .FindAll(x => x.Customer.CustID == custID);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.Include("Cust").AsNoTracking().Include("Location").AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
        }
    }
}