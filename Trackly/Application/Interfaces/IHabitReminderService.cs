using Trackly.Application.DTOs.Habits;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Application.Interfaces
{
    public interface IHabitReminderService
    {
        Task<Guid> AddReminderAsync(HabitReminderDto dto,Guid scheduleId, Guid userId);
        Task<List<HabitReminderResponceDto>> GetByRemindersAsync(Guid scheduleId, Guid userId);
        Task UpdateByReminderAsync(Guid scheduleId, Guid reminderId, HabitReminderDto dto, Guid userId);
        Task DeleteByReminderAsync(Guid scheduleId, Guid reminderId, Guid userId);
    }
}
