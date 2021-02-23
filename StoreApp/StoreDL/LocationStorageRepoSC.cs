using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public class LocationStorageRepoSC : ILocationRepository
    {
        public List<Location> GetLocations()
        {
            return LocationStorage.AllLocations;
        }
    }
}