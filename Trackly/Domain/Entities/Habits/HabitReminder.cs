namespace Trackly.Domain.Entities.Habits
{
    public class HabitReminder
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public HabitSchedule Schedules { get; set; } = null!;
        public TimeSpan Time { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
