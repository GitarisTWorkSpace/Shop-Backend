using Shop.Core.Models;

namespace Shop.Infrastructure.JWT
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
