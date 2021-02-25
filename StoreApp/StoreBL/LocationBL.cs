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

        public Location GetSpecificLocation(int storeCode)
        {
            return _repo.GetSpecificLocation(storeCode);
        }
    }
}