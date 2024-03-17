﻿using BackendCase.Models.Input;
using BackendCase.Models.Output;
using System.Text;
using BackendCase.TimeTransformExtension;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.BookingOperation.PostBooking
{
    public class PostBooking : AbstractClientService
    {
        private readonly string relativeUrl = "BookVisit?";
        public PostBooking(HttpClient client) : base(client) { }

        public async Task<BookingResult> BookAppointmentAsync(BookingDetails booking)
        {
            StringBuilder query = new StringBuilder();

            query.Append($"VisitId={booking.VisitId}");
            query.Append($"&startTime={MinHourExtension.Transform(booking.startTime)}");
            query.Append($"&endTime={MinHourExtension.Transform(booking.endTime)}");
            query.Append($"&date={DateExtension.Transform(booking.endTime)}");
            query.Append($"&PatientName={booking.patient.PatientName}");
            query.Append($"&PatientSurname={booking.patient.PatientSurname}");
            query.Append($"&hospitalId={booking.hospitalId}");
            query.Append($"&doctorId={booking.doctorId}");
            query.Append($"&branchId={Convert.ToInt64(booking.branchId)}");

            string fullUrl = relativeUrl + query.ToString();

            return await PostAsync<BookingResult, object>(fullUrl);
        }

    }
}