using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
namespace StoreBL
{
    /// <summary>
    /// This class enforces the business rules for Location objects
    /// </summary>
    public class LocationBL : ILocationBL
    {
        private ILocationRepository _repo;
        public LocationBL(ILocationRepository repo)
        {
            _repo = repo;
        }
        
        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public Location locationSelection()
        {
            Location selectedLocation = null;
            bool selected = false;
            while(!selected)
            {
                Console.WriteLine("Store Locations");
                Console.WriteLine("---------------");
                foreach(var item in _repo.GetLocations())
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Select Store Code:");
                int choice = int.Parse(Console.ReadLine());     
                foreach(var item in _repo.GetLocations())
                {
                    if(item.LocationID == choice)
                    {
                        selectedLocation = item;
                        selected = true;
                    }
                }
                if(!selected)
                {
                    Console.WriteLine("Store code incorrect, please try again");
                }
            }
            return selectedLocation;
        }

        
    }
}