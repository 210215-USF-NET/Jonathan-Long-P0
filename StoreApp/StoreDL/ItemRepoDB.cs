using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class ItemRepoDB : IItemRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public ItemRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Item AddItem(Model.Item newItem)
        {
            _context.Items.Add(_mapper.ParseItem(newItem));
            _context.SaveChanges();
            return newItem;
        }

        public List<Model.Item> GetItems()
        {
            return _context.Items.Include("Product").Include("Location").AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
        }

        public List<Item> GetItemsByLocation(int locationID)
        {
            throw new System.NotImplementedException();
        }
    }
}