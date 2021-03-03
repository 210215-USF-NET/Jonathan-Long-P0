using Xunit;
using Microsoft.EntityFrameworkCore;
using StoreDL;
using Entity = StoreDL.Entities;
using Model = StoreModels;
using System.Linq;
namespace StoreTests
{
    /// <summary>
    /// Test class for data access methods in my DL for store application
    /// </summary>
    public class StoreRepoTest
    {
        private readonly DbContextOptions<Entity.StoreDBContext> options;
        public StoreRepoTest()
        {
            options = new DbContextOptionsBuilder<Entity.StoreDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;

            Seed();
        }
        //Testing Read Operations
        
        [Fact]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                //Arrange
                ICustomerRepository _repo = new CustomerRepoDB(context, new StoreMapper());
                //Act
                var customer = _repo.GetCustomers();
                Assert.Equal(2, customer.Count);
            }
        }
        
        [Fact]
        public void GetAllLocationsShouldReturnAllLocations()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                ILocationRepository _repo = new LocationRepoDB(context, new StoreMapper());
                var location = _repo.GetLocations();
                Assert.Equal(2, location.Count());
            }
        }
        [Fact]
        public void SearchSpecificLocationShouldReturnLocation()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                ILocationRepository _repo = new LocationRepoDB(context, new StoreMapper());
                var location = _repo.GetSpecificLocation(0);
                Assert.Equal(location, location);
            }
        }
        [Fact]
        public void SearchForItemShouldReturnItem()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                IItemRepository _repo = new ItemRepoDB(context, new StoreMapper());
                var item = _repo.GetItems();
                Assert.Equal(2, item.Count());
            }
            
        }
        [Fact]
        public void SearchForItemShouldReturnSpecificItem()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                IItemRepository _repo = new ItemRepoDB(context, new StoreMapper());
                var item = _repo.GetItemByID(0);
                Assert.Equal(item, item);
            }
        }
        [Fact]
        public void SearchForProductShouldReturnProduct()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                IProductRepository _repo = new ProductRepoDB(context, new StoreMapper());
                var product = _repo.GetProducts();
                Assert.Equal(2, product.Count());
            }
        }
        private void Seed()
        {
            using(var context = new Entity.StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Customers.AddRange
                (
                    new Entity.Customer
                    {
                        CustId = 0,
                        FirstName = "Jack",
                        LastName = "Long",
                        PhoneNumber = "123-444-5678"
                    },
                     new Entity.Customer
                    {
                        CustId = 1,
                        FirstName = "Tom",
                        LastName = "Brady",
                        PhoneNumber = "145-464-5690"
                    }
                );
                
                context.Locations.AddRange
                (
                    new Entity.Location
                    {
                        LocationId = 0,
                        Address = "123 Way",
                        State = "VA",
                        LocationName = "Ski Store"
                    },
                      new Entity.Location
                    {
                        LocationId = 1,
                        Address = "42 Way",
                        State = "VA",
                        LocationName = "Ski Buy"
                    }
                );
                context.Products.AddRange
                (
                    new Entity.Product
                    {
                        ProductId = 0,
                        ProductName = "Skis",
                        Price = 22,
                        Description = "They are skis"
                    },
                      new Entity.Product
                    {
                        ProductId = 1,
                        ProductName = "Boots",
                        Price = 10,
                        Description = "They are boots"
                    }
                );
                context.Items.AddRange
                (
                    new Entity.Item
                    {
                        ItemId = 0,
                        Quantity = 20,
                        ProductId = 1,
                        LocationId = 1
                    },
                     new Entity.Item
                    {
                        ItemId = 1,
                        Quantity = 10,
                        ProductId = 0,
                        LocationId = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}