using BLL.Dto;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly IBarberService _barberService;  // Сервис для работы с барберами

        public BarbersController(IBarberService barberService)
        {
            _barberService = barberService;  // Инициализация сервиса через DI
        }

        // Получить всех барберов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarbers()
        {
            var barbers = await _barberService.GetAllBarbersAsync();  // Получаем всех барберов через сервис
            return Ok(barbers);  // Возвращаем успешный ответ с барберами
        }

        // Получить барбера по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Barber>> GetBarber(int id)
        {
            var barber = await _barberService.GetByBarberIdAsync(id);  // Получаем барбера по ID через сервис

            if (barber == null)  // Если барбер не найден
            {
                return NotFound();  // Возвращаем 404 NotFound
            }

            return Ok(barber);  // Возвращаем найденного барбера
        }

        // Создать нового барбера
        [HttpPost]
        public async Task<ActionResult<Barber>> CreateBarber(CreateBarberDto barber)
        {
            await _barberService.CreateAsync(barber);  // Создаём барбера через сервис
            return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);  // Возвращаем созданного барбера с 201 статусом
        }

        // Обновить информацию о барбере
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarber(int id, CreateBarberDto barber)
        {
            if (id != barber.Id)  // Если ID не совпадает с тем, что в теле запроса
            {
                return BadRequest();  // Возвращаем 400 BadRequest
            }

            await _barberService.UpdateAsync(barber);  // Обновляем барбера через сервис
            return NoContent();  // Возвращаем 204 No Content (успешно обновлено)
        }

        // Удалить барбера
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            await _barberService.DeleteAsync(id);  // Удаляем барбера через сервис
            return NoContent();  // Возвращаем 204 No Content (успешно удалено)
        }
    }

}
