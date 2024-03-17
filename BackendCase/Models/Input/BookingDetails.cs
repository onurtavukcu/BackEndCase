using System.ComponentModel.DataAnnotations;
namespace BackendCase.Models.Input
{
    public class BookingDetails
    {
        public int VisitId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Patient patient { get; set; }
        public int hospitalId { get; set; }
        public int doctorId { get; set; }
        public float branchId { get; set; }
    }
}