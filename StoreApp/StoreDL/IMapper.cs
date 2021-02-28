using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and UI
    /// </summary>
    public interface IMapper
    {
         Model.Customer ParseCustomer(Entity.Customer customer);
         Entity.Customer ParseCustomer(Model.Customer customer);
         Model.Location ParseLocation(Entity.Location location);
         Entity.Location ParseLocation(Model.Location location);
         Model.Product ParseProduct(Entity.Product product);
         Model.Item ParseItem(Entity.Item item);
         Entity.Item ParseItem(Model.Item item);
    }
}