using Trackly.Domain.Entities;

namespace Trackly.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByPhoneAsync(string phone);
        Task<User?> GetByRefreshTokenAsync(string token);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}
