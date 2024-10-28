using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;

namespace Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {            
        }

        public DbSet<User> Users { get; set; }
    }
}
