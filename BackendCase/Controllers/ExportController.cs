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
                var doctor = new GetDoctorsData(_client);

                var doctors = await doctor.GetDoctorsAsync();

                ExportCSV<DoctorList> exportDoctors = new ExportCSV<DoctorList>(doctors);

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
                var doctor = new GetDoctorsData(_client);

                var doctors = await doctor.GetDoctorsAsync();

                ExportCSV<DoctorList> exportDoctors = new ExportCSV<DoctorList>(doctors, columnName, filter);

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
                var doctors = new GetDoctorsFreeSlotsData(_client);

                var freeSlots = await doctors.GetDoctorsFreeSlotsAsync(doctorId);

                ExportCSV<DoctorFreeSlots> exportDoctors = new ExportCSV<DoctorFreeSlots>(freeSlots);

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
