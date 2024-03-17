using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.BookingOperation.CancelBooking
{
    public class CancelBooking : AbstractClientService
    {
        private readonly string relativeUrl = "BookVisit?";
        public CancelBooking(HttpClient client) : base(client) { }

        public async Task<CancellingResult> CancelAppointmentAsync(int bookingId)
        {
            return await PostAsync<CancellingResult, object>(relativeUrl + "BookingID=" + bookingId);
        }
    }
}
