using System;
using Xunit;
using StoreModels;
namespace StoreTests
{
    
    public class StoreModelTests
    {
        /// <summary>
        /// This Xunit tests the models for the ski store
        /// </summary>
        private Customer testCustomer = new Customer();
        private Location testLocation = new Location("12 Way", "VA", "Ski Store");
        [Fact]
       public void CustomerValuesShouldSetToCustomerValues()
        {
            string fName = "Customer";
            string lName = "Test";
            string phoneNumber = "555-222-3443";
            testCustomer.FirstName = fName;
            testCustomer.LastName = lName;
            testCustomer.PhoneNumber = phoneNumber;
            Assert.Equal(fName, testCustomer.FirstName);
            Assert.Equal(lName, testCustomer.LastName);
            Assert.Equal(phoneNumber, testCustomer.PhoneNumber);
        }
        [Fact]
        public void LocationSetsAddress()
        {
            string address = "45 Code St";
            testLocation.Address = address;
            Assert.Equal(address, testLocation.Address);
        }
        [Fact]
        public void LocationSetState()
        {
            string state = "MA";
            testLocation.State = state;
            Assert.Equal(state, testLocation.State);
        }
        [Fact]
        public void LocationSetStore()
        {
            string store = "Mountain Store";
            testLocation.LocationName = store;
            Assert.Equal(store, testLocation.LocationName);
        }
    }
}