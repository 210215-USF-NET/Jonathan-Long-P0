using Model = StoreModels;
using Entity = StoreDL.Entities;
using System;
namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            Model.Customer newCustomer = new Model.Customer(customer.FirstName, customer.LastName, customer.PhoneNumber);
            newCustomer.CustID = customer.CustId;
            return newCustomer;
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

        public Model.Order ParseOrder(Entity.Order order)
        {
            Model.Order newOrder = new Model.Order();
            newOrder.OrderID = order.OrderId;
            newOrder.Total = decimal.ToDouble(order.Total);
            newOrder.Customer = ParseCustomer(order.Cust);
            newOrder.Location = ParseLocation(order.Location);
            return newOrder;
        }

        public Entity.Order ParseOrder(Model.Order order)
        {
            return new Entity.Order
            {
                Total = Convert.ToDecimal(order.Total),
                Date = order.Date,
                CustId = order.Customer.CustID,
                LocationId = order.Location.LocationID
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            Model.Product newProduct = new Model.Product(product.ProductName, decimal.ToDouble(product.Price), product.Description);
            newProduct.ProductID = product.ProductId;
            return newProduct;
        }

        public Model.ProductOrder ParseProductOrder(Entity.ProductOrder productOrder)
        {
            Model.ProductOrder newProductOrder = new Model.ProductOrder();
            newProductOrder.Product = ParseProduct(productOrder.Product);
            newProductOrder.Order = ParseOrder(productOrder.Order);
            newProductOrder.Quantity = productOrder.Quantity;
            return newProductOrder;
        }

        public Entity.ProductOrder ParseProductOrder(Model.ProductOrder productOrder)
        {
            return new Entity.ProductOrder
            {
                ProductId = productOrder.Product.ProductID,
                OrderId = productOrder.Order.OrderID,
                Quantity = productOrder.Quantity
            };
        }
    }
}