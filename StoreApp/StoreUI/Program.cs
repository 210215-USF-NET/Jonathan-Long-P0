using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new CustomerBL(new CustomerRepoSC()), new LocationBL(new LocationStorageRepoSC()), 
            new ProductBL(new ProductRepoSC()));
            menu.Start();
        }
    }
}
