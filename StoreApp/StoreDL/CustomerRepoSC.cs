using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public class CustomerRepoSC : ICustomerRepository
    {
        public Customer AddCustomer(Customer newCustomer)
        {
            CustomerStorage.AllCustomers.Add(newCustomer);
            return newCustomer;
        }

        public List<Customer> GetCustomers()
        {
            return CustomerStorage.AllCustomers;
        }
    }
}
