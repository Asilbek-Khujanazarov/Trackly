using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackly.Application.DTOs.Habits;
using Trackly.Application.Interfaces;

namespace Trackly.Api.Controllers
{
    [ApiController]
    [Route("api/habit")]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService habitService;

        public HabitController(IHabitService habitService)
        {
            this.habitService = habitService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateHabitDto dto)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            var id = await habitService.CreateAsync(dto, userId);

            return Ok(id);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateHabitDto dto)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            await habitService.UpdateAsync(id, dto, userId);

            return NoContent();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            var result = await habitService.GetByIdAsync(id, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("my-habit")]
        public async Task<IActionResult> GetMyHabits()
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            var result = await habitService.GetUserHabitsAsync(userId);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);

            await habitService.DeleteHabitAsync(id, userId);

            return NoContent();
        }
    }
}
