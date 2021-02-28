using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class ProductOrderRepoDB : IProductOrderRepository
    {
        public Model.ProductOrder addProductOrder(Model.ProductOrder newProductOrder)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.ProductOrder> GetProductOrderByOrder(int orderID)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.ProductOrder> GetProductOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}