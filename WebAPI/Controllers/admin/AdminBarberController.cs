using BLL.Dto;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/admin/barbers")]
    [ApiController]
    public class AdminBarberController : ControllerBase
    {
        private readonly IBarberService _barberService;

        public AdminBarberController(IBarberService barberService)
        {
            _barberService = barberService;
        }

        // 📥 Добавить барбера
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBarberDto barber)
        {
            await _barberService.CreateAsync(barber);
            return Ok(barber);
        }

        // 🔄 Обновить барбера
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateBarberDto barber)
        {
            barber.Id = id;
            await _barberService.UpdateAsync(barber);
            return Ok();
        }

        // ❌ Удалить барбера
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _barberService.DeleteAsync(id);
            return Ok();
        }

        // 📋 Получить всех барберов
        [HttpGet]
        public async Task<IActionResult> GetAllBarbers()
        {
            var barbers = await _barberService.GetAllBarbersAsync();
            return Ok(barbers);
        }

        // 🔍 Получить барбера по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var barber = await _barberService.GetByBarberIdAsync(id);
            return barber == null ? NotFound() : Ok(barber);
        }
    }
}
