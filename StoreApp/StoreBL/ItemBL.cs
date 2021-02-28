using System.Collections.Generic;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    /// <summary>
    /// This class handles all of the BL for Items 
    /// </summary>
    public class ItemBL : IItemBL
    {
        private IItemRepository _repo;
        public ItemBL(IItemRepository repo)
        {
            _repo = repo;
        }
        public void addItem(Item newItem)
        {
            _repo.AddItem(newItem);
        }

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Item> GetItemsByLocation(int locationID)
        {
            return _repo.GetItemsByLocation(locationID);
        }
    }
}