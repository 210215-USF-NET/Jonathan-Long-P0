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

        public List<Order> GetLocationOrderASC(int locationID)
        {
            var queryLocations = 
            (from order in _context.Orders
            join location in _context.Locations
            on order.LocationId equals location.LocationId
            join cust in _context.Customers
            on order.CustId equals cust.CustId
            where location.LocationId == locationID
            orderby order.Date
            select order).ToList();
            if(queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach(var item in queryLocations)
            {
                item.Cust = _context.Customers.Find(item.CustId);
                item.Location = _context.Locations.Find(item.LocationId);
                Order newOrder = _mapper.ParseOrder(item);
                returnList.Add(newOrder);
            }
            return returnList;
            
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            var queryLocations = 
            (from order in _context.Orders
            join location in _context.Locations
            on order.LocationId equals location.LocationId
            join cust in _context.Customers
            on order.CustId equals cust.CustId
            where location.LocationId == locationID
            orderby order.Total
            select order).ToList();
            if(queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach(var item in queryLocations)
            {
                item.Cust = _context.Customers.Find(item.CustId);
                item.Location = _context.Locations.Find(item.LocationId);
                Order newOrder = _mapper.ParseOrder(item);
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            var queryLocations = 
            (from order in _context.Orders
            join location in _context.Locations
            on order.LocationId equals location.LocationId
            join cust in _context.Customers
            on order.CustId equals cust.CustId
            where location.LocationId == locationID
            orderby order.Date descending
            select order).ToList();
            if(queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach(var item in queryLocations)
            {
                item.Cust = _context.Customers.Find(item.CustId);
                item.Location = _context.Locations.Find(item.LocationId);
                Order newOrder = _mapper.ParseOrder(item);
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            var queryLocations = 
            (from order in _context.Orders
            join location in _context.Locations
            on order.LocationId equals location.LocationId
            join cust in _context.Customers
            on order.CustId equals cust.CustId
            where location.LocationId == locationID
            orderby order.Total descending
            select order).ToList();
            if(queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach(var item in queryLocations)
            {
                item.Cust = _context.Customers.Find(item.CustId);
                item.Location = _context.Locations.Find(item.LocationId);
                Order newOrder = _mapper.ParseOrder(item);
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.Include("Cust").AsNoTracking().Include("Location").AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
        }
    }
}