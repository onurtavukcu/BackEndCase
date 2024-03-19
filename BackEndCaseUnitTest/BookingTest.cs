using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.BookingOperation.CancelBooking;
using BackendCase.Operations.BookingOperation.PostBooking;
using BackendCase.Operations.GetDataOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BackEndCaseUnitTest
{
    public class BookingTest
    {
        private readonly HttpClient _client;
        private IPostBookingService _postBooking;
        private BookingResult _bookingResult;
        private BookingDetails _successBookingDetails;
        private BookingDetails _failBookingDetails;

        private ICancelBookingService _cancelBooking;
        private CancellingResult _cancellingResult;

        protected readonly HttpClient _httpClient;


        [SetUp]
        public void Setup()
        {
            _postBooking = new MockPostBookingService();

            _bookingResult = new BookingResult
            {
                BookingID = 133213,
                status = true
            };

            _cancelBooking = new MockCancelBookingService();

            _cancellingResult = new CancellingResult
            {
                status = true
            };
        }


        [Test]
        public async Task SuccessBook()
        {
            var result = await _postBooking.Handle();

            Assert.AreEqual(result, _bookingResult);
        }

        [Test]
        public void FailBook()
        {
            var result = _postBooking.Handle(_failBookingDetails);

            Assert.AreNotEqual(result.Result, _bookingResult);
        }

        [Test]
        public void SuccesCancelBook()
        {
            var result = _cancelBooking.Handle(133213);

            Assert.AreEqual(result.Result, _cancellingResult);
        }


        [Test]
        public void FailCancelBook()
        {
            var result = _cancelBooking.Handle(1321321313);

            Assert.AreNotEqual(result.Result, _cancellingResult);
        }

        [Test]
        public async Task FailCancelBookWithWrongParameters()
        {
            var result = await new MockCancelBookingService().Handle();

            Assert.AreNotEqual(result,_cancellingResult);
        }
    }
}
