using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;
using System.Text;
using System.Text.Json;

namespace BackendCase.Operations.BookingOperation.CancelBooking
{

    public class CancelBookingService : AbstractBookingService<int, CancellingResult>, ICancelBookingService
    {
        private readonly string relativeUrl = "CancelVisit?";
        public CancelBookingService(HttpClient client) : base(client) { }

        public async override Task<CancellingResult> Handle()
        {
            return await GetAsync(relativeUrl);
        }


        //public override async Task<CancellingResult> Handle(int input)  // Its POST Call Its not work!
        //{
        //    return await PostAsync(relativeUrl, new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        //    {
        //        new KeyValuePair<string, string>("BookingID", input.ToString())
        //    })); 
        //    // Cancel booking only need bookingId. we send the bookingId in url.
        //}

        public async override Task<CancellingResult> Handle(int input)
        {
            StringBuilder query = new StringBuilder();

            query.Append("BookingID=");
            query.Append(input.ToString());

            string fullUrl = relativeUrl + query.ToString();

            return await GetAsync(fullUrl);
        }
    }
}
