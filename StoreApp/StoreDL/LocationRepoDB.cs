using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class LocationRepoDB : ILocationRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public LocationRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public Location GetSpecificLocation(int storeCode)
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.LocationID == storeCode);
        }
    }
}