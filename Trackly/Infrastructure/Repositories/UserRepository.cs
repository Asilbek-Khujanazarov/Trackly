using Microsoft.EntityFrameworkCore;
using Trackly.Application.Interfaces;
using Trackly.Domain.Entities;
using Trackly.Infrastructure.Persistence;

namespace Trackly.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByPhoneAsync(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        }

        public async Task<User?> GetByRefreshTokenAsync(string token)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.RefreshToken == token);
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
