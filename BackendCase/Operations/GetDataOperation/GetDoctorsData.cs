using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;
namespace BackendCase.Operations.GetDataOperation
{

    public class GetDoctorsDataService : AbstractBookingService<DoctorListWrapper>, IGetDoctorsDataService
    {
        private readonly string relativeUrl = "fetchDoctors";

        public GetDoctorsDataService(HttpClient client) :base(client) { }

        /*
        public async Task<List<DoctorList>> GetDoctorsAsync()
        {
            var response = await GetAsync<DoctorListWrapper>(relativeUrl);
            // call abstract Client with return type.
            return response.data;
        }
        */

        public override async Task<DoctorListWrapper> Handle()
        {
            var response = await GetAsync(relativeUrl);
            // call abstract Client with return type.
            return response;
        }
    }
}
