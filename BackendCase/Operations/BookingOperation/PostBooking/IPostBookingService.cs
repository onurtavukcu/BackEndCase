using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.BookingOperation.PostBooking
{
    public interface IPostBookingService: IBookingService<BookingDetails, BookingResult>
    {

    }
}