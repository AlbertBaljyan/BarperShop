using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/admin/schedules")]
    [ApiController]
    public class AdminScheduleController : ControllerBase
    {
        private readonly IBarberScheduleService _scheduleService;

        public AdminScheduleController(IBarberScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BarberSchedule schedule)
        {
            await _scheduleService.CreateAsync(schedule);
            return Ok(schedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BarberSchedule schedule)
        {
            schedule.Id = id;
            await _scheduleService.UpdateAsync(schedule);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _scheduleService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("barber/{barberId}")]
        public async Task<IActionResult> GetByBarber(int barberId)
        {
            var schedules = await _scheduleService.GetByIdAsync(barberId);
            return Ok(schedules);
        }
    }

}
