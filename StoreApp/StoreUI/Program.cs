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
            Menu menu = new Menu(new CustomerBL(new CustomerRepoSC()));
            menu.Start();
        }
    }
}
