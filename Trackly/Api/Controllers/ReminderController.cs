using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackly.Application.DTOs.Habits;
using Trackly.Application.Interfaces;

namespace Trackly.Api.Controllers
{
    [ApiController]
    [Route("api/reminder")]
    public class ReminderController : ControllerBase
    {
        private readonly IHabitReminderService reminderService;

        public ReminderController(IHabitReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Add (HabitReminderDto dto , Guid scheduleId)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            var id = await reminderService.AddReminderAsync(dto, scheduleId, userId);

            return Ok(id);
        }

        [Authorize]
        [HttpGet("{scheduleId}")]
        public async Task<IActionResult> GetByReminders(Guid scheduleId)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);
            
            var result = await reminderService.GetByRemindersAsync(scheduleId, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("schedules{scheduleId}/reminders/{reminderId}")]
        public async Task<IActionResult> UpdateByReminder(Guid scheduleId, HabitReminderDto dto, Guid reminderId)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            await reminderService.UpdateByReminderAsync(scheduleId, reminderId, dto, userId);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("schedules{scheduleId}/reminders/{reminderId}")]
        public async Task<IActionResult> DeleteByReminder(Guid scheduleId, Guid reminderId)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            await reminderService.DeleteByReminderAsync(scheduleId, reminderId, userId);

            return NoContent();
        }
    }
}
