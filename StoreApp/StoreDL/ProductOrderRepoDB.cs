using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class ProductOrderRepoDB : IProductOrderRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public ProductOrderRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.ProductOrder AddProductOrder(Model.ProductOrder newProductOrder)
        {
            _context.ProductOrders.Add(_mapper.ParseProductOrder(newProductOrder));
            _context.SaveChanges();
            return newProductOrder;
        }

        public List<ProductOrder> GetCustomerProductOrders(Customer customer)
        {
            return _context.ProductOrders
            .Include("Product")
            .AsNoTracking()
            .Include("Order")
            .AsNoTracking()
            .Select(x => _mapper.ParseProductOrder(x))
            .ToList()
            .FindAll(x => x.Order.Customer == customer);
        }

        public List<Model.ProductOrder> GetProductOrderByOrder(int orderID)
        {

             return _context.ProductOrders
            .Include("Product")
            .AsNoTracking()
            .Include("Order")
            .AsNoTracking()
            .Select(x => _mapper.ParseProductOrder(x))
            .ToList()
            .FindAll(x => x.Order.OrderID == orderID);
            
        }
        

        public List<Model.ProductOrder> GetProductOrders()
        {
            return _context.ProductOrders.Include("Product").AsNoTracking().Include("Order").AsNoTracking().Select(x => _mapper.ParseProductOrder(x)).ToList();
        }
    }
}