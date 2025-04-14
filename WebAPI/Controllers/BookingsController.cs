using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;  // Сервис для работы с записями

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;  // Инициализация сервиса через DI
        }

        // Получить все записи
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllAsync();  // Получаем все записи через сервис
            return Ok(bookings);  // Возвращаем успешный ответ с записями
        }

        // Получить запись по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);  // Получаем запись по ID через сервис

            if (booking == null)  // Если запись не найдена
            {
                return NotFound();  // Возвращаем 404 NotFound
            }

            return Ok(booking);  // Возвращаем найденную запись
        }

        // Создать новую запись
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            await _bookingService.CreateAsync(booking);  // Создаём запись через сервис
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);  // Возвращаем созданную запись с 201 статусом
        }

        // Удалить запись
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteAsync(id);  // Удаляем запись через сервис
            return NoContent();  // Возвращаем 204 No Content (успешно удалено)
        }
    }

}
