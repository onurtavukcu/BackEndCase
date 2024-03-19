using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.BookingOperation.PostBooking;

namespace BackEndCaseUnitTest
{
    public class MockPostBookingService : MockBookingService, IPostBookingService
    {
        public async Task<BookingResult> Handle(BookingDetails input)
        {
            var result = new BookingResult()
            {
                status = false
            };

            var successBookingDetails = new BookingDetails
            {
                VisitId = 551231,
                startTime = new DateTime(2022, 05, 31, 10, 30, 00, 000),
                endTime = new DateTime(2022, 05, 31, 10, 45, 00, 000),
                patient = new Patient { PatientName = "Kamil", PatientSurname = "Oz" },
                hospitalId = 160,
                doctorId = 3,
                branchId = 45145
            };

            if 
            (
                input.VisitId == successBookingDetails.VisitId &&
                input.startTime ==  successBookingDetails.startTime &&
                input.endTime ==  successBookingDetails.endTime &&
                input.patient.PatientName == successBookingDetails.patient.PatientName &&
                input.patient.PatientSurname == successBookingDetails.patient.PatientSurname &&
                input.hospitalId == successBookingDetails.hospitalId &&
                input.doctorId == successBookingDetails.doctorId &&
                input.branchId == successBookingDetails.branchId
            )
            {
                result = new BookingResult
                {
                    BookingID = 133213,
                    status = true
                };
            }

            return result;
        }

        public Task<BookingResult> Handle()
        {
            throw new NotImplementedException();
        }
    }
}