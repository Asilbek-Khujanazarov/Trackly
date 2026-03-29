using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Application.Interfaces
{
    public interface IHabitRepository
    {
        Task<Habit?> GetByIdAsync(Guid id);
        Task<List<Habit>> GetByUserIdAsync(Guid userId);
        Task<Habit?> GetByScheduleIdAsync(Guid scheduleId);
        Task AddAsync(Habit habit);
        Task UpdateAsync(Habit habit);
        Task DeleteAsync(Habit habit);
    }
}
