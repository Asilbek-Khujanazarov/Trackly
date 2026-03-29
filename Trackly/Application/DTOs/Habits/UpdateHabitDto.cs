using Trackly.Domain.Enums;

namespace Trackly.Application.DTOs.Habits
{
    public class UpdateHabitDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public HabitCategory Category { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime EndDate { get; set; }
        public int? TargetCount { get; set; }
        public ICollection<HabitScheduleDto>? Schedules { get; set; }
    }
}
