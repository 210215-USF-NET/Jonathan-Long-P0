using System;
using StoreModels;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up logger
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(new CompactJsonFormatter(),"../Logs.json").CreateLogger();
            
            //Setting up DB connection
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlServer(connectionString).Options;

            using var context = new StoreDBContext(options);

            Menu menu = new Menu(new CustomerBL(new CustomerRepoDB(context, new StoreMapper())), new LocationBL(new LocationRepoDB(context, new StoreMapper())), 
            new ProductBL(new ProductRepoDB(context, new StoreMapper())), new ItemBL(new ItemRepoDB(context, new StoreMapper())), new OrderBL(new OrderRepoDB(context, new StoreMapper())),
            new ProductOrderBL(new ProductOrderRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
