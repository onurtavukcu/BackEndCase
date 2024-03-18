using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;


namespace BackendCase.Operations.GetDataOperation
{
    public class GetDoctorsFreeSlotsData : AbstractClientService
    {
        private string relativeUrl = "fetchSchedules?doctorId=";
        public GetDoctorsFreeSlotsData(HttpClient client) : base(client) { }

        public async Task<List<DoctorFreeSlots>> GetDoctorsFreeSlotsAsync(int doctorId)
        {
            string parameteredUrl = relativeUrl + doctorId.ToString();

            var response = await GetAsync<DoctorFreeSlotsWrapper>(parameteredUrl);
            // call abstract Client with return type.
            return response.data;

        }
    }
}
