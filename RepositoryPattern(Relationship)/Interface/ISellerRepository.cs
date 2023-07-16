using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Interface
{
    public interface ISellerRepository
    {
        Task CreationSeller(Seller obj);
        Task <IEnumerable<Seller>> GetSellers();
        Task <Seller>GetSellerId(int id);
        Task UpdateSeller(Seller obj);
        Task DeleteSeller (Seller obj);

    }

}
