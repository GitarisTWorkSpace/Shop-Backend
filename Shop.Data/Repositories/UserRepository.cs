using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.Core.Stores;

namespace Shop.Data.Repositories
{
    public class UserRepository : IUserStore
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await DefaultIncludes().ToListAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await DefaultIncludes().Where(u => u.Id == id).FirstAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await DefaultIncludes().Where(u => u.Email == email).FirstAsync();
        }        

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            return await DefaultIncludes().Where(u => u.PhoneNumber == phoneNumber).FirstAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await DefaultIncludes().Where(u => u.Name == userName).FirstAsync();
        }

        public async Task<long> CreateUser(User user)
        {
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> UpdateUser(User user)
        {
            await _context.Users
                .Where(u => u.Id == user.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.Name, u => user.Name)
                    .SetProperty(u => u.Surname, u => user.Surname)
                    .SetProperty(u => u.Email, u => user.Email)
                    .SetProperty(u => u.PhoneNumber, u => user.PhoneNumber)
                    .SetProperty(u => u.UpdatedAt, u => DateTime.UtcNow));

            return user.Id;
        }        

        public async Task<long> DeleteUser(long id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();

            return id;
        }

        public IQueryable<User> DefaultIncludes()
        {
            return _context.Users.AsNoTracking();
        }
    }
}
