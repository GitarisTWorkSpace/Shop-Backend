using Shop.Core.Models;

namespace Shop.Core.Stores
{
    public interface IUserStore
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
