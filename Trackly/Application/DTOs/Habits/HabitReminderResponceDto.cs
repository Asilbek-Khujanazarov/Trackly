namespace Trackly.Application.DTOs.Habits
{
    public class HabitReminderResponceDto
    {
        public Guid Id { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsEnabled { get; set; }
    }
}
