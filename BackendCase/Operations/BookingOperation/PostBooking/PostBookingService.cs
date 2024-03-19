using BackendCase.Models.Input;
using BackendCase.Models.Output;
using System.Text;
using BackendCase.TimeTransformExtension;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.BookingOperation.PostBooking
{
    public class PostBookingService : AbstractBookingService<BookingDetails, BookingResult>, IPostBookingService
    {
        private readonly string relativeUrl = "BookVisit?";
        public PostBookingService(HttpClient client) : base(client) { }

        //public override async Task<BookingResult> Handle(BookingDetails input)  //Its POST Call Its not work!
        //{
        //    return await PostAsync(relativeUrl, new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
        //    {
        //        new KeyValuePair<string, string>("VisitId",         $"{input.VisitId}"),
        //        new KeyValuePair<string, string>("startTime",       $"{MinHourExtension.Transform(input.startTime)}"),
        //        new KeyValuePair<string, string>("endTime",         $"{MinHourExtension.Transform(input.endTime)}"),
        //        new KeyValuePair<string, string>("date",            $"{DateExtension.Transform(input.endTime)}"),
        //        new KeyValuePair<string, string>("PatientName",     $"{input.patient.PatientName}"),
        //        new KeyValuePair<string, string>("PatientSurname",  $"{input.patient.PatientSurname}"),
        //        new KeyValuePair<string, string>("hospitalId",      $"{input.hospitalId}"),
        //        new KeyValuePair<string, string>("doctorId",        $"{input.doctorId}"),
        //        new KeyValuePair<string, string>("branchId",        $"{input.branchId}"),
        //    }));
        //}

        public override Task<BookingResult> Handle()
        {
            throw new NotImplementedException();
        }

        public async override Task<BookingResult> Handle(BookingDetails booking)
        {
            StringBuilder query = new StringBuilder();

            query.Append($"VisitId={booking.VisitId}");
            query.Append($"&startTime={MinHourExtension.Transform(booking.startTime)}");
            query.Append($"&endTime={MinHourExtension.Transform(booking.endTime)}");
            query.Append($"&date={DateExtension.Transform(booking.endTime)}");
            query.Append($"&PatientName={booking.patient.PatientName}");
            query.Append($"&PatientSurname={booking.patient.PatientSurname}");
            query.Append($"&hospitalId={booking.hospitalId}");
            query.Append($"&doctorId={booking.doctorId}");
            query.Append($"&branchId={Convert.ToInt64(booking.branchId)}");

            string fullUrl = relativeUrl + query.ToString();

            return await GetAsync(fullUrl);
        }
    }
}