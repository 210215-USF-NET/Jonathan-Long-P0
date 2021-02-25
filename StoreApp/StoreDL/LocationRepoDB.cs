using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList();
        }
    }
}