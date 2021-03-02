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

        public Item GetItemByID(int itemID)
        {
            var queryItem = 
            (from item in _context.Items
            where item.ItemId == itemID
            select item).ToList().FirstOrDefault();
            if(queryItem == null)
            {
                return null;
            }
            queryItem.Product = _context.Products.Find(queryItem.ProductId);
            queryItem.Location = _context.Locations.Find(queryItem.LocationId);
            return _mapper.ParseItem(queryItem);
        }

        public List<Model.Item> GetItems()
        {
            return _context.Items.Include("Product").AsNoTracking().Include("Location").AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
        }

        public List<Model.Item> GetItemsByLocation(int locationID)
        {
            return _context.Items
            .Include("Product")
            .AsNoTracking()
            .Include("Location")
            .AsNoTracking()
            .Select(x => _mapper.ParseItem(x))
            .ToList()
            .FindAll(x => x.Location.LocationID == locationID);
        }

        public void UpdateItem(Item item2BUpdated)
        {
            Entity.Item oldItem = _context.Items.Find(item2BUpdated.ItemID);
            _context.Entry(oldItem).CurrentValues.SetValues(_mapper.ParseItem(item2BUpdated));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}