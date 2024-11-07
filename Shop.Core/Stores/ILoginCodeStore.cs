using Shop.Core.Models;

namespace Shop.Core.Stores
{
    public interface ILoginCodeStore
    {
        Task<string> GetCodeByUser(long userId);
        
        Task<int> CreateLoginCodeForUser(long userId, string code);

        Task<int> DeleteLoginCodeForUser(long userId);
    }
}
