namespace BackendCase.Models.Output
{
    public class BookingResult
    {
        public bool status { get; set; }
        public int? BookingID { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is not null &&
                obj is BookingResult other &&
                BookingID == other.BookingID &&
                status == other.status;
        }
    }
}
