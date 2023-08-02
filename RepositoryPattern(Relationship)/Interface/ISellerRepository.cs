using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Interface
{
    public interface ISellerRepository
    {
        Task CreationSeller(Seller obj);
        Task <IEnumerable<Seller>> GetSellers();
        Task<IEnumerable<Seller>> Searchseller(string firstName, string itemName);
        Task<IEnumerable<Item>> SearchItems(string itemName);
        Task <Seller>GetSellerId(int id);
        Task <Seller> ViewItem(int id);
        Task UpdateSeller(Seller obj);
        Task DeleteSeller (Seller obj);

    }

}
