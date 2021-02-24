using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public class LocationStorageRepoSC : ILocationRepository
    {
        public List<Location> GetLocations()
        {
            //Test Code Until DB
            Location testLocation1 = new Location(1, "123 Town Rd", "VA", "SkiVA");
            Location testLocation2 = new Location(2, "52 West Rd", "MA", "SkiMA");
            LocationStorage.AllLocations.Add(testLocation1);
            LocationStorage.AllLocations.Add(testLocation2);
            //End Test Code
            return LocationStorage.AllLocations;
        }
       
    }
}