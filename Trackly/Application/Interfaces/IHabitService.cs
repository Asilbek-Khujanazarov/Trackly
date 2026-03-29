using Trackly.Application.DTOs.Habits;
using Trackly.Domain.Entities;

namespace Trackly.Application.Interfaces
{
    public interface IHabitService
    {
        Task<Guid> CreateAsync(CreateHabitDto dto, Guid userId);
        Task UpdateAsync(Guid habitId, UpdateHabitDto dto, Guid userId);
        Task<HabitResponseDto> GetByIdAsync(Guid habitId, Guid userId);
        Task<List<HabitResponseDto>> GetUserHabitsAsync(Guid userId);
        Task DeleteHabitAsync (Guid habitId, Guid userId);
        Task CreateHabitReminderAsync(Guid habitId, Guid userId);
    }
}
