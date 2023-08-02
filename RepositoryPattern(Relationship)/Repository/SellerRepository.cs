using Microsoft.AspNetCore.Mvc;
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
            var getSellerId = await _context.Sellers.Where(x => x.SellerId == id).FirstOrDefaultAsync();
            return getSellerId;
        }

        public async Task<IEnumerable<Seller>> GetSellers()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<IEnumerable<Seller>> Searchseller(string? firstName, string? itemName)
        {
            var result = _context.Sellers.AsQueryable();
            var query = _context.Sellers
                    .Join(_context.Items,
                          seller => seller.SellerId,
                          item => item.SellerId,
                          (seller, item) => new { Seller = seller, Item = item });

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(q => q.Seller.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(itemName))
            {
                query = query.Where(q => q.Item.ItemName.Contains(itemName));
            }

            var sellers = await query.Select(q => q.Seller).ToListAsync();
            return sellers;
        }

        public async Task<IEnumerable<Item>> SearchItems(string itemName)
        {
            //var result = _context.Sellers.AsQueryable();
            //var query = _context.Sellers
            //        .Join(_context.Items,
            //              seller => seller.SellerId,
            //              item => item.SellerId,
            //              (seller, item) => new { Seller = seller, Item = item });

            var result = _context.Items.AsQueryable();
            var query = _context.Items
                    .Join(_context.Sellers,
                          item => item.SellerId,
                          seller => seller.SellerId,
                          (item, seller) => new { Item = item, Seller = seller });
            

            if (!string.IsNullOrEmpty(itemName))
            {
                query = query.Where(q => q.Item.ItemName.Contains(itemName));
            }

            var item = await query.Select(a => a.Item).ToListAsync();
            return item;
        }

        public async Task UpdateSeller(Seller obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> ViewItem(int id)
        {
            var result = await _context.Sellers.FirstOrDefaultAsync(x => x.SellerId == id);
            return result;
        }


    }
}
