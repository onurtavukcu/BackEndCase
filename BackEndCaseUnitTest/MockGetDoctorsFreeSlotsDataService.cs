using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.GetDataOperation;

namespace BackEndCaseUnitTest
{
    public class MockGetDoctorsFreeSlotsDataService : MockBookingService, IGetDoctorsFreeSlotsDataService
    {
        public Task<DoctorFreeSlotsWrapper> Handle(int input)
        {
            DoctorFreeSlotsWrapper wrapper = new DoctorFreeSlotsWrapper();

            DoctorFreeSlots doctorFreeSlots1 = new DoctorFreeSlots()
            {
                id = "1",
                doctorId = 3,
                VisitId = 551231,
                startTime = new DateTime(2022, 05, 31, 10, 30, 00, 000),
                endTime = new DateTime(2022, 05, 31, 10, 45, 00, 000)
            };

            DoctorFreeSlots doctorFreeSlots2 = new DoctorFreeSlots()
            {
                id = "2",
                doctorId = 3,
                VisitId = 252312,
                startTime = new DateTime(2022, 06, 01, 10, 30, 00, 000),
                endTime = new DateTime(2022, 06, 01, 10, 45, 00, 000)
            };

            DoctorFreeSlots doctorFreeSlots3 = new DoctorFreeSlots()
            {
                id = "3",
                doctorId = 3,
                VisitId = 652123,
                startTime = new DateTime(2022, 06, 01, 10, 45, 00, 000),
                endTime = new DateTime(2022, 06, 01, 10, 55, 00, 000)
            };

            DoctorFreeSlots doctorFreeSlots4 = new DoctorFreeSlots()
            {
                id = "4",
                doctorId = 3,
                VisitId = 923112,
                startTime = new DateTime(2022, 06, 01, 16, 30, 00, 000),
                endTime = new DateTime(2022, 06, 01, 16, 50, 00, 000)
            };

            wrapper.data.Add(doctorFreeSlots1);
            wrapper.data.Add(doctorFreeSlots2);
            wrapper.data.Add(doctorFreeSlots3);
            wrapper.data.Add(doctorFreeSlots4);

            if (input == 3)
            {
                return Task.FromResult(wrapper);
            }
            else
            {
                return null;
            }

        }

        public Task<DoctorFreeSlotsWrapper> Handle()
        {
            throw new NotImplementedException();
        }
    }
}
