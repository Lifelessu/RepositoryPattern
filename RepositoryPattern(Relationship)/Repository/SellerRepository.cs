using Microsoft.EntityFrameworkCore;
using RepositoryPattern_Relationship_.Data;
using RepositoryPattern_Relationship_.Interface;
using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _context;
        public SellerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreationSeller(Seller obj)
        {
            _context.Sellers.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeller(Seller obj)
        {
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> GetSellerId(int id)
        {
            //var getId = await _context.Sellers.FirstOrDefaultAsync(m => m.SellerId == sellerId);
            //return getId;
            //hakdog
            return await _context.Sellers.SingleOrDefaultAsync(m => m.SellerId ==  id); 
            
        }

        public async Task<IEnumerable<Seller>> GetSellers()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task UpdateSeller(Seller obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
