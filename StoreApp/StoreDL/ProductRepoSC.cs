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
    }
}