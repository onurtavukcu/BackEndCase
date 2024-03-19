using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.BookingOperation.CancelBooking
{
    public interface ICancelBookingService: IBookingService<int, CancellingResult>
    {

    }
}
