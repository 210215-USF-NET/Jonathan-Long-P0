using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
namespace StoreDL
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepoDB : IProductRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public ProductRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();
        }

        public void ProductsByOrder(int orderID)
        {
            var queryProducts = 
            (from product in _context.Products
            join productOrder in _context.ProductOrders
            on product.ProductId equals productOrder.ProductId
            join order in _context.Orders on productOrder.OrderId equals order.OrderId
            join customer in _context.Customers on order.CustId equals customer.CustId
            join location in _context.Locations on order.LocationId equals location.LocationId
            where order.OrderId == orderID
            select new{product.ProductName, product.Price, product.Description});
            if(queryProducts == null)
            {
                Console.WriteLine("No products found for order");
            }
            else 
            {
                foreach(var item in queryProducts)
                {
                    Console.WriteLine($"\tProduct: {item.ProductName}\n\tPrice: ${item.Price}\n\tDescription {item.Description}");
                }
            }
        }
    }
}