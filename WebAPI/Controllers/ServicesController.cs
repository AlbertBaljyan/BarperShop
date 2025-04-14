using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;  // Сервис для работы с услугами

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;  // Инициализация сервиса через DI
        }

        // Получить все услуги
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            var services = await _serviceService.GetAllAsync();  // Получаем все услуги через сервис
            return Ok(services);  // Возвращаем успешный ответ с услугами
        }

        // Получить услугу по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);  // Получаем услугу по ID через сервис

            if (service == null)  // Если услуга не найдена
            {
                return NotFound();  // Возвращаем 404 NotFound
            }

            return Ok(service);  // Возвращаем найденную услугу
        }

        // Создать новую услугу
        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {
            await _serviceService.CreateAsync(service);  // Создаём услугу через сервис
            return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);  // Возвращаем созданную услугу с 201 статусом
        }

        // Обновить информацию об услуге
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service service)
        {
            if (id != service.Id)  // Если ID не совпадает с тем, что в теле запроса
            {
                return BadRequest();  // Возвращаем 400 BadRequest
            }

            await _serviceService.UpdateAsync(service);  // Обновляем услугу через сервис
            return NoContent();  // Возвращаем 204 No Content (успешно обновлено)
        }

        // Удалить услугу
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteAsync(id);  // Удаляем услугу через сервис
            return NoContent();  // Возвращаем 204 No Content (успешно удалено)
        }
    }

}
