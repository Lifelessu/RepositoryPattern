using Microsoft.EntityFrameworkCore;
using RepositoryPattern_Relationship_.Data;
using RepositoryPattern_Relationship_.Interface;
using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreationItem(Item obj)
        {
            _context.Items.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Item obj)
        {
            _context.Items.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> FindItemId(int id)
        {
            return await _context.Items.SingleOrDefaultAsync(L => L.ItemId == id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
           return await _context.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> SearchItems(string itemName)
        {
            var result = await _context.Items.Where(a => a.ItemName.Contains(itemName)).ToListAsync();
            return result;

        }

        public async Task UpdateItem(Item obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }
    }
}
