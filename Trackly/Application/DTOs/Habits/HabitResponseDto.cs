using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;
using Trackly.Domain.Enums;

namespace Trackly.Application.DTOs.Habits
{
    public class HabitResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TargetCount { get; set; }
        public HabitCategory Category { get; set; }
        public List<HabitScheduleDto>? Schedules { get; set; }
       
    }
}
