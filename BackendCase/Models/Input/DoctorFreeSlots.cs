using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendCase.Models.Input
{
    public class DoctorFreeSlots
    {
        [JsonPropertyName("id")]
        public string idString { get; set; }
        public int SlotId
        {
            get
            {
                return int.Parse(idString);
            }
            set
            {

            }
        }
        public DoctorList doctorId { get; set; }
        public int VisitId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }

    public class DoctorFreeSlotsWrapper
    {
        public List<DoctorFreeSlots> data { get; set; }
    }
}