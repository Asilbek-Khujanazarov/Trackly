namespace Trackly.Domain.Entities.Habits
{
    public class HabitSchedule
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public Habit Habit { get; set; } = null!;
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public ICollection<HabitReminder> Reminders { get; set; } = new List<HabitReminder>();

    }
}