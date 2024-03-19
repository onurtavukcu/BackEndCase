﻿using BackendCase.Models.Input;
using BackendCase.Operations.BookingOperation.CancelBooking;
using BackendCase.Operations.GetDataOperation;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace BackEndCaseUnitTest
{
    public class GetDataTest
    {
        private readonly HttpClient _client;
        private IGetDoctorsDataService _doctorsData { get; set; } = null!;
        private IGetDoctorsFreeSlotsDataService _doctorsFreeSlots { get; set; } = null!;
        private IGetDoctorsFreeSlotsDataService getDoctorsFreeSlotsDataService{ get; set; }
        private DoctorListWrapper _doctorListWrapper { get; set; }
        private DoctorFreeSlotsWrapper _doctorListFreeSlot { get; set; }

        [SetUp]
        public void Setup()
        {
            _doctorsData = new MockGetDoctorsDataService();
            _doctorsFreeSlots = new MockGetDoctorsFreeSlotsDataService();

            #region doctorList
            _doctorListWrapper = new DoctorListWrapper();

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

            _doctorListWrapper.data.Add(doctor1);
            _doctorListWrapper.data.Add(doctor2);
            _doctorListWrapper.data.Add(doctor3);
            _doctorListWrapper.data.Add(doctor4);
            _doctorListWrapper.data.Add(doctor5);
            _doctorListWrapper.data.Add(doctor6);
            _doctorListWrapper.data.Add(doctor7);
            _doctorListWrapper.data.Add(doctor8);
            _doctorListWrapper.data.Add(doctor9);
            _doctorListWrapper.data.Add(doctor10);
            #endregion

            #region doctorlistFreeSlot
            _doctorListFreeSlot = new DoctorFreeSlotsWrapper();

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

            _doctorListFreeSlot.data.Add(doctorFreeSlots1);
            _doctorListFreeSlot.data.Add(doctorFreeSlots2);
            _doctorListFreeSlot.data.Add(doctorFreeSlots3);
            _doctorListFreeSlot.data.Add(doctorFreeSlots4);
        }
# endregion

        [Test]
        public void GetDoctorsData_Test()
        {
            var doctorList = _doctorsData.Handle();

            Assert.AreEqual(doctorList.Result, _doctorListWrapper);
        }

        [Test]
        public void GetDoctorsFreeSlotSuccess_Test()
        {
            var freeSlots = _doctorsFreeSlots.Handle(3);

            Assert.AreNotEqual(freeSlots.Result, _doctorListFreeSlot);
        }

        [Test]
        public void GetDoctorsFreeSlotFail_Test()
        {
            var freeSlots = _doctorsFreeSlots.Handle(2);

            Assert.AreNotEqual(freeSlots.Result, _doctorListFreeSlot);
        }

    }
}