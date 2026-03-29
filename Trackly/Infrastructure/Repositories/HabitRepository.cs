using Microsoft.EntityFrameworkCore;
using Trackly.Application.Interfaces;
using Trackly.Domain.Entities;
using Trackly.Infrastructure.Persistence;

namespace Trackly.Infrastructure.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly ApplicationDbContext _context;
        public HabitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Habit?> GetByIdAsync(Guid id)
        {
            return await _context.Habits
                .Include(x => x.Schedules)
                .ThenInclude(s => s.Reminders)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Habit>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Habits
                .Where(x => x.UserId == userId)
                .Include(x => x.Schedules) 
                .ThenInclude(s => s.Reminders)
                .ToListAsync();

        }
        public async Task<Habit?> GetByScheduleIdAsync (Guid scheduleId)
        {
            return await _context.Habits
                .Include(x => x.Schedules)
                    .ThenInclude(x => x.Reminders)
                .Where(h => h.Schedules.Any(s => s.Id == scheduleId))
                .FirstOrDefaultAsync();
        }
        public async Task AddAsync(Habit habit)
        {
            await _context.AddAsync(habit);

            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Habit habit)
        {
            _context.Habits.Update(habit);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Habit habit)
        {
            _context.Habits.Remove(habit);

            await _context.SaveChangesAsync();
        }
    }
}
