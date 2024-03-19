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
        [HttpGet]
        [Route("GetDoctors")]
        public async Task<IActionResult> GetDoctorsAsync([FromServices] IGetDoctorsDataService doctorsService)
        {
            try
            {
                var result = await doctorsService.Handle();

                return await Task.FromResult<IActionResult>(Ok(result.data));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetDoctorsFreeSlots/{doctorId:int}")]
        public async Task<IActionResult> GetDoctorsFreeSlotsAsync(int doctorId, [FromServices] IGetDoctorsFreeSlotsDataService doctorsService)
        {
            try
            {
                var result = await doctorsService.Handle(doctorId);

                return await Task.FromResult<IActionResult>(Ok(result.data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Book")]
        public async Task<IActionResult> PostBooking([FromBody] BookingDetails booking, [FromServices] IPostBookingService bookingService)
        {
            try
            {
                var result = await bookingService.Handle(booking);

                return await Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CancelBook")]
        public async Task<IActionResult> CancelBooking(int bookId, [FromServices] ICancelBookingService cancelBookingService)
        {
            try
            {
                //var result = await book.CancelAppointmentAsync(bookId);
                var result = await cancelBookingService.Handle(bookId);

                return await Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
