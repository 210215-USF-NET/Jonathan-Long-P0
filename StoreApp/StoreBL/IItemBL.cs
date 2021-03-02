using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IItemBL
    {
         List<Item> GetItems();
         void addItem(Item newItem);
         List<Item> GetItemsByLocation(int locationID);
         Item GetItemByID(int itemID);
         void UpdateItem(Item item2BUpdated, int newQuantity);
    }
}