namespace BackendCase.Models.Output
{
    public class FreeSlotResult
    {
        public string message { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is not null &&
                obj is FreeSlotResult other &&
                message == other.message;
        }
    }
}
