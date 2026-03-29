using Trackly.Domain.Enums;

namespace Trackly.Application.DTOs.Habits
{
    public class CreateHabitDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public HabitCategory Category { get; set; }

    }
}
