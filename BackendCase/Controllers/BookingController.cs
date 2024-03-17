using BackendCase.Models.Input;
using BackendCase.Operations.BookingOperation.CancelBooking;
using BackendCase.Operations.BookingOperation.PostBooking;
using BackendCase.Operations.GetDataOperation;
using Microsoft.AspNetCore.Mvc;

namespace BackendCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly HttpClient _client;

        public BookingController(HttpClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("GetDoctors")]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            try
            {
                var doctors = new GetDoctorsData(_client);

                var result = await doctors.GetDoctorsAsync();

                return await Task.FromResult<IActionResult>(Ok(result));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetDoctorsFreeSlots/{doctorId:int}")]
        public async Task<IActionResult> GetDoctorsFreeSlotsAsync(int doctorId)
        {
            try
            {
                var doctors = new GetDoctorsFreeSlotsData(_client);

                var result = await doctors.GetDoctorsFreeSlotsAsync(doctorId);

                return await Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Book")]
        public async Task<IActionResult> PostBooking(BookingDetails booking)
        {
            try
            {
                var book = new PostBooking(_client);

                var result = await book.BookAppointmentAsync(booking);

                return await Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CancelBook")]
        public async Task<IActionResult> CancelBooking(int bookId)
        {
            try
            {
                var book = new CancelBooking(_client);

                var result = await book.CancelAppointmentAsync(bookId);

                return await Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
