using System.Threading.Tasks;

namespace EnglishLearningAPI.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task UpdateUserAsync(User user);
    }
}

