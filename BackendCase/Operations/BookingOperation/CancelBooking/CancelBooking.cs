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
            return await PostAsync<CancellingResult, object>(relativeUrl + "BookingID=" + bookingId);
        }

        public async Task<CancellingResult> WrongUrlTest()
        {
            string url = "https://3aff8cc7-91f8-4577-bef3-e566d6c41d74.mock.pstmn.io/cancelVisit";

            var responseData = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<CancellingResult>(responseData);
        }
    }
}
