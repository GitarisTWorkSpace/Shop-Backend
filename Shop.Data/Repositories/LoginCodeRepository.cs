using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using Shop.Core.Models;
using Shop.Core.Stores;

namespace Shop.Data.Repositories
{
    public class LoginCodeRepository : ILoginCodeStore
    {
        private readonly AppDbContext _context;

        public LoginCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetCodeByUser(long userId)
        {
            LoginCode loginCode = await DefaultIncludes().Where(c => c.UserId == userId && c.CreatedAt >= DateTime.UtcNow).FirstOrDefaultAsync();

            if (loginCode == null)
                return null;

            return loginCode.Code;
        }

        public async Task<int> CreateLoginCodeForUser(long userId, string code)
        {
            LoginCode loginCode = new LoginCode();
            loginCode.UserId = userId;            
            loginCode.Code = code;
            loginCode.CreatedAt = DateTime.UtcNow.AddMinutes(15);

            await _context.AddAsync(loginCode);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> DeleteLoginCodeForUser(long userId)
        {
            return await _context.LoginCodes.Where(c => c.UserId == userId).ExecuteDeleteAsync();
        }

        public IQueryable<LoginCode> DefaultIncludes()
        {
            return _context.LoginCodes.AsNoTracking();
        }
    }
}
