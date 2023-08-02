using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Interface
{
    public interface IItemRepository
    {
        Task CreationItem(Item obj);
        Task <IEnumerable<Item>> GetItems();
        Task<IEnumerable<Item>> SearchItems(string itemName);
        Task <Item>FindItemId(int id);
        Task UpdateItem (Item obj);
        Task DeleteItem (Item obj);
    }
}
