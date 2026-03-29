namespace Trackly.Application.DTOs.Habits
{
    public class HabitScheduleDto
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public List<HabitReminderResponceDto>? Reminders { get; set; }
    }
}
