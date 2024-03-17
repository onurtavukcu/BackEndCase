using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.BookingOperation.CancelBooking;
using BackendCase.Operations.BookingOperation.PostBooking;
using BackendCase.Operations.GetDataOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BackEndCaseUnitTest
{
    public class BookingTest
    {
        private readonly HttpClient _client;
        private PostBooking _postBooking;
        private BookingResult _bookingResult;
        private BookingDetails _successBookingDetails;
        private BookingDetails _failBookingDetails;

        private CancelBooking _cancelBooking;
        private CancellingResult _cancellingResult;

        protected readonly HttpClient _httpClient;


        [SetUp]
        public void Setup()
        {
            _postBooking = new PostBooking(_client);

            _successBookingDetails = new BookingDetails
            {
                VisitId = 55123,
                startTime = new DateTime(2022, 05, 31, 10, 30, 16, 160),
                endTime = new DateTime(2022, 05, 31, 10, 45, 16, 160),
                patient = new Patient { PatientName = "Kamil", PatientSurname = "Oz" },
                hospitalId = 160,
                doctorId = 3,
                branchId = 45145
            };

            _failBookingDetails = new BookingDetails
            {
                VisitId = 11111,
                startTime = new DateTime(2022, 05, 31, 10, 30, 16, 160),
                endTime = new DateTime(2022, 05, 31, 10, 45, 16, 160),
                patient = new Patient { PatientName = "Kamil", PatientSurname = "Oz" },
                hospitalId = 160,
                doctorId = 3,
                branchId = 45145
            };

            _bookingResult = new BookingResult
            {
                BookingID = 133213,
                status = true
            };


            _cancelBooking = new CancelBooking(_client);

            _cancellingResult = new CancellingResult
            {
                status = true
            };
        }


        [Test]
        public void SuccessBook()
        {
            var result = _postBooking.BookAppointmentAsync(_successBookingDetails);

            Assert.AreEqual(result.Result, _bookingResult);
        }

        [Test]
        public void FailBook()
        {
            var result = _postBooking.BookAppointmentAsync(_failBookingDetails);

            Assert.AreNotEqual(result.Result, _bookingResult);
        }

        [Test]
        public void SuccesCancelBook()
        {
            var result = _cancelBooking.CancelAppointmentAsync(133213);

            Assert.AreEqual(result.Result, _cancellingResult);
        }


        [Test]
        public void FailCancelBook()
        {
            var result = _cancelBooking.CancelAppointmentAsync(111111);

            Assert.AreNotEqual(result.Result, _cancellingResult);
        }

        [Test]
        public void FailCancelBookWithWrongParameters()
        {
            var result = _cancelBooking.WrongUrlTest();

            Assert.AreNotEqual(result.Result ,_cancellingResult);
        }
    }
}
