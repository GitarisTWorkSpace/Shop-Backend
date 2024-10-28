using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public class UserRepository : IUserRepository
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
            return await DefaultIncludes().Where(u => u.Alias == userName).FirstAsync();
        }

        public async Task<long> TaskCreateUser(User user)
        {
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> UpdateUser(User user)
        {
            await _context.Users
                .Where(u => u.Id == user.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.Alias, u => user.Alias)
                    .SetProperty(u => u.Name, u => user.Name)
                    .SetProperty(u => u.LastName, u => user.LastName)
                    .SetProperty(u => u.Email, u => user.Email)
                    .SetProperty(u => u.PhoneNumber, u => user.PhoneNumber)
                    .SetProperty(u => u.UpdateAt, u => DateTime.UtcNow));

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

        public Task<long> CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
