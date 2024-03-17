using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendCase.Models.Input
{
    public class Patient
    {
        public int Id { get; set; } 
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
    }
}
