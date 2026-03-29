using Trackly.Domain.Entities.Habits;
using Trackly.Domain.Enums;

namespace Trackly.Domain.Entities
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TargetCount { get; set; }
        public HabitCategory Category { get; set; }
        public ICollection<HabitSchedule> Schedules { get; set; } = new List<HabitSchedule>();
        public ICollection<HabitLog> HabitLogs { get; set; } = new List<HabitLog>();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!; 
    }
}
