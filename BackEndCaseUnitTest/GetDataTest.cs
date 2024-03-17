using BackendCase.Operations.GetDataOperation;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace BackEndCaseUnitTest
{
    public class GetDataTest
    {
        private readonly HttpClient _client;
        private GetDoctorsData _doctorsData { get; set; } = null!;
        private GetDoctorsFreeSlotsData _doctorsFreeSlots { get; set; } = null!;

        string noSlotMessage = "message\":\"NO_SLOT_FOUND";

        [SetUp]
        public void Setup()
        {
            _doctorsData = new GetDoctorsData(_client);
            _doctorsFreeSlots = new GetDoctorsFreeSlotsData(_client);
        }

        [Test]
        public void GetDoctorsData_Test()
        {
            //Assign
            bool dataExist = false;

            var doctorList = _doctorsData.GetDoctorsAsync();

            if (doctorList != null)
            {
                dataExist = true;
            }

            Assert.IsTrue(dataExist);
        }

        [Test]
        public void GetDoctorsFreeSlotSuccess_Test()
        {
            var freeSlots = _doctorsFreeSlots.GetDoctorsFreeSlotsAsync(3);

            Assert.AreNotEqual(freeSlots.ToString(), noSlotMessage);
        }

        [Test]
        public void GetDoctorsFreeSlotFail_Test()
        {
            string noSlotMessage = "message\":\"NO_SLOT_FOUND";

            var freeSlots = _doctorsFreeSlots.GetDoctorsFreeSlotsAsync(2);

            Assert.AreEqual(freeSlots.ToString(), noSlotMessage);
        }

    }
}