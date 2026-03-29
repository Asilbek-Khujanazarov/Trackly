using Microsoft.EntityFrameworkCore;
using Trackly.Domain.Entities;
using Trackly.Domain.Entities.Habits;

namespace Trackly.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitSchedule> HabitSchedules { get; set; }

    }
}
