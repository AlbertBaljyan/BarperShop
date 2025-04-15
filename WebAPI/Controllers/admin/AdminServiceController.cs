using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/admin/services")]
    [ApiController]
    public class AdminServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public AdminServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // 📥 Добавить услугу
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Service service)
        {
            await _serviceService.CreateAsync(service);
            return Ok(service);
        }

        // 🔄 Обновить услугу
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Service service)
        {
            service.Id = id;
            await _serviceService.UpdateAsync(service);
            return Ok();
        }

        // ❌ Удалить услугу
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteAsync(id);
            return Ok();
        }

        // 📋 Получить все услуги
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceService.GetAllAsync();
            return Ok(services);
        }

        // 🔍 Получить услугу по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            return service == null ? NotFound() : Ok(service);
        }
    }
}
