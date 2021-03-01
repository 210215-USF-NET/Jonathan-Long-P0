using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class ProductRepoSC : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return ProductStorage.AllProducts;
        }

        public List<Product> ProductsByOrder(int orderID)
        {
            throw new System.NotImplementedException();
        }

        void IProductRepository.ProductsByOrder(int orderID)
        {
            throw new System.NotImplementedException();
        }
    }
}