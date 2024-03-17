using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendCase.Models.Input
{
    public class DoctorList
    {
        public string doctorId { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string hospitalName { get; set; }
        public int hospitalId { get; set; }
        public int specialtyId { get; set; }
        public float branchId { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class DoctorListWrapper
    {
        public List<DoctorList> data { get; set; }
    }
}
