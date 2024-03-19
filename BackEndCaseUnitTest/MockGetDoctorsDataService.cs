using BackendCase.Models.Input;
using BackendCase.Operations.GetDataOperation;
using Microsoft.VisualBasic.FileIO;

namespace BackEndCaseUnitTest
{
    public class MockGetDoctorsDataService : MockBookingService, IGetDoctorsDataService
    {
        public Task<DoctorListWrapper> Handle()
        {
            DoctorListWrapper wrapper = new DoctorListWrapper();

            var doctor1 = new DoctorList()
            {
                doctorId = "1",
                name = "Ahmet Öz",
                gender = "Male",
                nationality = "TUR",
                hospitalName = "Medicana Avcilar",
                hospitalId = 150,
                specialtyId = 81036,
                branchId = 29532.99F,
                createdAt = new DateTime(2022, 01, 13, 01, 54, 46, 988)
            };

            var doctor2 = new DoctorList()
            {
                doctorId = "2",
                name = "Ahmet Pınar",
                gender = "Male",
                nationality = "TUR",
                hospitalName = "Medicana Avcilar",
                hospitalId = 150,
                specialtyId = 81036,
                branchId = 29532.99F,
                createdAt = new DateTime(2022, 04, 29, 02, 25, 53, 521)
            };

            var doctor3 = new DoctorList()
            {
                doctorId = "3",
                name = "Yasemin Öztürk",
                gender = "Female",
                nationality = "TUR",
                hospitalName = "MedicalPark İzmir",
                hospitalId = 160,
                specialtyId = 81036,
                branchId = 45145.08F,
                createdAt = new DateTime(2021, 12, 29, 20, 34, 25, 337)
            };

            var doctor4 = new DoctorList()
            {
                doctorId = "4",
                name = "Kübra Işık",
                gender = "Female",
                hospitalName = "MedicalPark Kadiköy",
                hospitalId = 160,
                specialtyId = 18741,
                branchId = 49875.59F,
                nationality = "TUR",
                createdAt = new DateTime(2022, 04, 30, 04, 05, 06, 158)
            };

            var doctor5 = new DoctorList()
            {
                doctorId = "5",
                name = "Aynur Aslan",
                gender = "Female",
                hospitalName = "Medicana Sisli",
                hospitalId = 150,
                specialtyId = 20746,
                branchId = 19747.48F,
                nationality = "TUR",
                createdAt = new DateTime(2021, 05, 27, 21, 24, 21, 743)
            };

            var doctor6 = new DoctorList()
            {
                doctorId = "6",
                name = "Elena Morissette",
                gender = "Female",
                hospitalName = "Memorial",
                hospitalId = 54892,
                specialtyId = 88071,
                branchId = 94982.39F,
                nationality = "DE",
                createdAt = new DateTime(2021, 07, 28, 13, 55, 08, 598)
            };

            var doctor7 = new DoctorList()
            {
                doctorId = "7",
                name = "Hamdi Öztürk",
                gender = "Male",
                hospitalName = "Medicana Sisli",
                hospitalId = 23701,
                specialtyId = 9090,
                branchId = 19747.48F,
                nationality = "TUR",
                createdAt = new DateTime(2021, 06, 14, 18, 01, 30, 325)
            };

            var doctor8 = new DoctorList()
            {
                doctorId = "8",
                name = "Craig O'Keefe",
                gender = "Male",
                hospitalName = "American Hospital",
                hospitalId = 58497,
                specialtyId = 39708,
                branchId = 46998.74F,
                nationality = "USA",
                createdAt = new DateTime(2022, 01, 13, 01, 54, 46)
            };

            var doctor9 = new DoctorList()
            {
                doctorId = "9",
                name = "Aysun Çoşkun",
                gender = "Female",
                hospitalName = "Ege Hastanesi",
                hospitalId = 1058,
                specialtyId = 82688,
                branchId = 5663.64F,
                nationality = "TUR",
                createdAt = new DateTime(2022, 03, 12, 15, 47, 42, 275)
            };

            var doctor10 = new DoctorList()
            {
                doctorId = "10",
                name = "Cesar Batz",
                gender = "Male",
                hospitalName = "Ege Hastanesi",
                hospitalId = 1058,
                specialtyId = 13798,
                branchId = 5663.64F,
                nationality = "ITA",
                createdAt = new DateTime(2022, 05, 19, 19, 12, 58, 359)
            };

            wrapper.data.Add(doctor1);
            wrapper.data.Add(doctor2);
            wrapper.data.Add(doctor3);
            wrapper.data.Add(doctor4);
            wrapper.data.Add(doctor5);
            wrapper.data.Add(doctor6);
            wrapper.data.Add(doctor7);
            wrapper.data.Add(doctor8);
            wrapper.data.Add(doctor9);
            wrapper.data.Add(doctor10);

            return Task.FromResult(wrapper);

        }
    }
}