using Model = StoreModels;
using Entity = StoreDL.Entities;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer(customer.FirstName, customer.LastName, customer.PhoneNumber);
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public Model.Item ParseItem(Entity.Item item)
        {
            Model.Item newItem = new Model.Item(item.Quantity, ParseProduct(item.Product), ParseLocation(item.Location));
            newItem.ItemID = item.ItemId;
            return newItem;
        }

        public Entity.Item ParseItem(Model.Item item)
        {
            return new Entity.Item
            {
                Quantity = item.Quantity,
                ProductId = item.Product.ProductID,
                LocationId = item.Location.LocationID
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            Model.Location newLocation = new Model.Location(location.Address, location.State, location.LocationName);
            newLocation.LocationID = location.LocationId;
            return newLocation;
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            return new Entity.Location
            {
                Address = location.Address,
                State = location.State,
                LocationName = location.LocationName
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            Model.Product newProduct = new Model.Product(product.ProductName, decimal.ToDouble(product.Price), product.Description);
            newProduct.ProductID = product.ProductId;
            return newProduct;
        }
    }
}