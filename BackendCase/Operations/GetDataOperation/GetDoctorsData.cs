using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;
namespace BackendCase.Operations.GetDataOperation
{
    public class GetDoctorsData : AbstractClientService
    {
        private readonly string relativeUrl = "fetchDoctors";

        public GetDoctorsData(HttpClient client) :base(client) { }

        public async Task<List<DoctorList>> GetDoctorsAsync()
        {
            var response = await GetAsync<DoctorListWrapper>(relativeUrl);
            // call abstract Client with return type.
            return response.data;
        }
    }
}
