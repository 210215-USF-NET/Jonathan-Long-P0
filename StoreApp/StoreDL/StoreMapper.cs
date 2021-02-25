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
    }
}