using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(long id);

        Task<User> GetByUserName(string userName);

        Task<User> GetByEmail(string email);

        Task<User> GetByPhoneNumber(string phoneNumber);        

        Task<long> CreateUser(User user);

        Task<long> UpdateUser(User user);

        Task<long> DeleteUser(long id);
    }
}
