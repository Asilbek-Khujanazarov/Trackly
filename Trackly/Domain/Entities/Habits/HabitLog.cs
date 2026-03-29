namespace Trackly.Domain.Entities.Habits
{
    public class HabitLog
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public Habit Habit { get; set; } = null!;
        public DateTime Date {  get; set; }
        public bool IsCompleted { get; set; }
    }
}
