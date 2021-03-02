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

        public Item GetItemByID(int itemID)
        {
            return _repo.GetItemByID(itemID);
        }

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Item> GetItemsByLocation(int locationID)
        {
            return _repo.GetItemsByLocation(locationID);
        }

        public void UpdateItem(Item item2BUpdated, int newQuantity)
        {
            item2BUpdated.Quantity = newQuantity;
            _repo.UpdateItem(item2BUpdated);
        }
    }
}