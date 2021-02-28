using System;
using StoreModels;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting up DB connection
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlServer(connectionString).Options;

            using var context = new StoreDBContext(options);

            Menu menu = new Menu(new CustomerBL(new CustomerRepoDB(context, new StoreMapper())), new LocationBL(new LocationRepoDB(context, new StoreMapper())), 
            new ProductBL(new ProductRepoSC()), new ItemBL(new ItemRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
