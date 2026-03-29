using AutoMapper;
using Trackly.Application.DTOs.Habits;
using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Application.Mappings
{
    public class HabitProfile : Profile
    {
        public HabitProfile()
        {
            CreateMap<CreateHabitDto, Habit>();
            CreateMap<UpdateHabitDto, Habit>();
            CreateMap<HabitScheduleDto, HabitSchedule>().ReverseMap();
            CreateMap<Habit, HabitResponseDto>();
            CreateMap<HabitReminderDto, HabitReminder>().ReverseMap();
            CreateMap<HabitReminder,HabitReminderResponceDto>();
        }
    }
}
