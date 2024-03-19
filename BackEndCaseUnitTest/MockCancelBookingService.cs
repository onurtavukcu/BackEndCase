using BackendCase.Models.Output;
using BackendCase.Operations.BookingOperation.CancelBooking;

namespace BackEndCaseUnitTest
{
    public class MockCancelBookingService : MockBookingService, ICancelBookingService
    {
        public async Task<CancellingResult> Handle(int input)
        {
            return new CancellingResult()
            {
                status = input == 133213
            };
        }

        public async Task<CancellingResult> Handle()
        {
            return new CancellingResult()
            {
                status = false
            };
        }
    }
}