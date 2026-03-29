using AutoMapper;
using Trackly.Application.DTOs.Habits;
using Trackly.Application.Interfaces;
using Trackly.Domain.Common;
using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Infrastructure.Services
{
    public class HabitReminderService : IHabitReminderService
    {
        private readonly IHabitRepository repository;
        private readonly IMapper mapper;

        public HabitReminderService(IHabitRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Guid> AddReminderAsync(HabitReminderDto dto, Guid scheduleId, Guid userId)
        {
            var habit = await repository.GetByScheduleIdAsync(scheduleId);
            if (habit == null)
                throw new NotFoundException("Schedule not found");

            var schedule = habit.Schedules.First(s => s.Id == scheduleId);

            if (schedule.Reminders.Any(x => x.Time == dto.Time))
                throw new BadRequestException("Reminder already exists");

            var reminder = new HabitReminder
            {
                Time = dto.Time
            };

            schedule.Reminders.Add(reminder);

            await repository.UpdateAsync(habit);

            return reminder.Id;
        }
        public async Task<List<HabitReminderResponceDto>> GetByRemindersAsync(Guid scheduleId, Guid userId)
        {
            var habit = await repository.GetByScheduleIdAsync(scheduleId);

            if (habit == null)
                throw new NotFoundException("Schedule not found");

            if (habit.UserId != userId)
                throw new ForbiddenException("Access denied");
            
            var schedule = habit.Schedules.First(x => x.Id == scheduleId);

            return mapper.Map<List<HabitReminderResponceDto>>(schedule.Reminders);
        }
        public async Task UpdateByReminderAsync(Guid scheduleId, Guid reminderId, HabitReminderDto dto, Guid userId)
        {
            var habit = await repository.GetByScheduleIdAsync(scheduleId);

            if (habit == null)
                throw new NotFoundException("Schedule not found");

            if (habit.UserId != userId)
                throw new ForbiddenException("Access denied");

            var schedule = habit.Schedules.First(x => x.Id == scheduleId);

            if (schedule == null)
                throw new NotFoundException("Schedule not found");

            var reminder = schedule.Reminders.FirstOrDefault(x => x.Id ==  reminderId);

            if (reminder == null)
                throw new NotFoundException("Reminder not found");

            reminder.Time = dto.Time;

            await repository.UpdateAsync(habit);
        }

        public async Task DeleteByReminderAsync(Guid scheduleId, Guid reminderId, Guid userId)
        {
            var habit = await repository.GetByScheduleIdAsync(scheduleId);

            if(habit == null)
                throw new NotFoundException("Schedule not found");

            if (habit.UserId != userId)
                throw new ForbiddenException("Access denied");

            var schedule = habit.Schedules.First(x => x.Id == scheduleId);

            if (schedule == null)
                throw new NotFoundException("Schedule not found");

            var reminder = schedule.Reminders.FirstOrDefault(x => x.Id == reminderId);

            if (reminder == null)
                throw new NotFoundException("Reminder not found");

            schedule.Reminders.Remove(reminder);

            await repository.UpdateAsync(habit);
        }
    }
}
