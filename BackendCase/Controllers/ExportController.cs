using BackendCase.Models.Input;
using BackendCase.Operations.CSVOperations;
using BackendCase.Operations.GetDataOperation;
using Microsoft.AspNetCore.Mvc;

namespace BackendCase.Controllers
{
    public class ExportController : Controller
    {
        private readonly HttpClient _client;
        public ExportController(HttpClient client)
        {
            _client = client;
        }
        [HttpGet]
        [Route("ExportDoctersDataAsCSV")]
        public async Task<IActionResult> ExportDoctors()
        {
            try
            {
                var doctor = new GetDoctorsDataService(_client);

                var doctors = await doctor.Handle();

                ExportCSV<DoctorList> exportDoctors = new ExportCSV<DoctorList>(doctors.data);

                byte[] csvBytes = exportDoctors.ExportToCSV();

                return File(csvBytes, "text/csv", "doctors.csv");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("ExportDoctersDataAsCSVWithFilter")]
        public async Task<IActionResult> ExportDoctors(string columnName, string filter)
        {
            try
            {
                var doctor = new GetDoctorsDataService(_client);

                var doctors = await doctor.Handle();

                ExportCSV<DoctorList> exportDoctors = new ExportCSV<DoctorList>(doctors.data, columnName, filter);

                byte[] csvBytes = exportDoctors.ExportToCSV();

                return File(csvBytes, "text/csv", "doctors.csv");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("DoctorsFreeSlotsCSV/{doctorId:int}")]
        public async Task<IActionResult> ExportDoctorsSlots(int doctorId)
        {
            try
            {
                var doctors = new GetDoctorsFreeSlotsDataService(_client);

                var freeSlots = await doctors.Handle(doctorId);

                ExportCSV<DoctorFreeSlots> exportDoctors = new ExportCSV<DoctorFreeSlots>(freeSlots.data);

                byte[] csvBytes = exportDoctors.ExportToCSV();

                return File(csvBytes, "text/csv", "doctorsSlots.csv");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
