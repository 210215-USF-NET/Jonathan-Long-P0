using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IItemRepository
    {
         List<Item> GetItems();
         Item AddItem(Item newItem);
    }
}