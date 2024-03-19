using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.GetDataOperation
{

    public class GetDoctorsFreeSlotsDataService : AbstractBookingService<int, DoctorFreeSlotsWrapper>, IGetDoctorsFreeSlotsDataService
    {
        private string relativeUrl = "fetchSchedules?doctorId=";
        public GetDoctorsFreeSlotsDataService(HttpClient client) : base(client) { }

        public override async Task<DoctorFreeSlotsWrapper> Handle(int input)
        {
            string parameteredUrl = relativeUrl + input.ToString();

            var response = await GetAsync(parameteredUrl);
            // call abstract Client with return type.
            return response;
        }

        public override Task<DoctorFreeSlotsWrapper> Handle()
        {
            throw new NotImplementedException();
        }

        /*
        public async Task<List<DoctorFreeSlots>> GetDoctorsFreeSlotsAsync(int doctorId)
        {
            string parameteredUrl = relativeUrl + doctorId.ToString();

            var response = await GetAsync<DoctorFreeSlotsWrapper>(parameteredUrl);
            // call abstract Client with return type.
            return response.data;

        }
        */
    }
}
