using Microsoft.EntityFrameworkCore;
using RepositoryPattern_Relationship_.Models;

namespace RepositoryPattern_Relationship_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }  
        public DbSet<Seller> Sellers { get; set; }  
    }
}
