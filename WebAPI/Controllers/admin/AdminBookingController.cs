using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.admin
{
    [Route("api/admin/bookings")]
    [ApiController]
    public class AdminBookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public AdminBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync(id);
            return Ok();
        }
    }

}
