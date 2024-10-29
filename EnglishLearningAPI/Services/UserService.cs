using System.Threading.Tasks;
using EnglishLearningAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EnglishLearningAPI.Services
{
    public class UserService : IUserService
    {
        private readonly EnglishLearningDbContext _context;

        public UserService(EnglishLearningDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.refresh_token == refreshToken);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
