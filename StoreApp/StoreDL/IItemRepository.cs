using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IItemRepository
    {
         List<Item> GetItems();
         Item AddItem(Item newItem);
         List<Item> GetItemsByLocation(int locationID);
         Item GetItemByID(int itemID);
         void UpdateItem(Item item2BUpdated);
    }
}