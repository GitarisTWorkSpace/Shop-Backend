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

        public DbSet<LoginCode> LoginCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginCode>()
                .HasOne(c => c.User)
                .WithMany(u => u.LoginCode)
                .HasForeignKey(c => c.UserId);
        }
    }
}
