using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;
using System.Text.Json;

namespace BackendCase.Operations.BookingOperation.CancelBooking
{
    public class CancelBooking : AbstractClientService
    {
        private readonly string relativeUrl = "BookVisit?";
        public CancelBooking(HttpClient client) : base(client) { }

        public async Task<CancellingResult> CancelAppointmentAsync(int bookingId)
        {
            return await PostAsync<CancellingResult, object>(relativeUrl + "BookingID=" + bookingId); // Cancel booking only need bookingId. we send the bookingId in url.
        }

        public async Task<CancellingResult> WrongUrlTest()  // In test case we need to wrong url. But url form not fit in our url models so we add extra function for it.
        {
            string url = "https://fe8f4f5e-f5c2-48b6-974c-097f4cec3de0.mock.pstmn.io/cancelVisit";

            var responseData = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<CancellingResult>(responseData);
        }
    }
}
