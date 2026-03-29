using AutoMapper;
using Trackly.Application.DTOs.Habits;
using Trackly.Application.Interfaces;
using Trackly.Domain.Common;
using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Infrastructure.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitRepository habitRepository;
        private readonly IMapper mapper;

        public HabitService(IHabitRepository habitRepository, IMapper mapper)
        {
            this.habitRepository = habitRepository;
            this.mapper = mapper;
        }
        public async Task<HabitResponseDto> GetByIdAsync(Guid habitId, Guid userId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            if (habit == null)
                throw new NotFoundException($"Not Found {habitId}");

            if (habit.UserId != userId)
                throw new ForbiddenException("Unauthorized");

            return mapper.Map<HabitResponseDto>(habit);
        }

        public async Task<List<HabitResponseDto>> GetUserHabitsAsync(Guid userId)
        {
            var habits = await habitRepository.GetByUserIdAsync(userId);

            return mapper.Map<List<HabitResponseDto>>(habits);
        }

        public async Task<Guid> CreateAsync(CreateHabitDto dto, Guid userId)
        {
            var habit = mapper.Map<Habit>(dto);
            habit.UserId = userId;

            if (habit.StartDate == default)
                habit.StartDate = DateTime.UtcNow;

            await habitRepository.AddAsync(habit);

            return habit.Id;
        }


        public async Task UpdateAsync(Guid habitId, UpdateHabitDto dto, Guid userId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            mapper.Map(dto, habit);

            if (habit == null)
                throw new NotFoundException($"Not Found : {habitId}");

            if (habit.UserId != userId)
                throw new ForbiddenException("Unauthorized");

            if (dto.Schedules != null)
            {
                habit.Schedules.Clear();
                habit.Schedules = mapper.Map<List<HabitSchedule>>(dto.Schedules);

            }
            await habitRepository.UpdateAsync(habit);
        }

        public async Task DeleteHabitAsync(Guid habitId, Guid userId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            if (habit == null)
                throw new NotFoundException($"Not Found : {habitId}");

            if (habit.UserId != userId)
                throw new ForbiddenException("Access denied");

            await habitRepository.DeleteAsync(habit);
        }

        public async Task CreateHabitReminderAsync(Guid habitId, Guid userId)
        {
            var habit = await habitRepository.GetByIdAsync(habitId);

            if (habit == null)
                throw new NotFoundException($"Not Found : {habitId}");

            if (habit.UserId != userId)
                throw new ForbiddenException("Access denied");


        }
    }
}
