using System.Collections.Generic;
using StoreModels;
using StoreDL;
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

        public Location locationSelection(int choice)
        {
            Location selectedLocation = null;
            bool selected = false;
            while(!selected)
            {
                foreach(var item in _repo.GetLocations())
                {
                    if(item.LocationID == choice)
                    {
                        selectedLocation = item;
                        selected = true;
                    }
                }
            }
            return selectedLocation;
        }

        
    }
}