namespace BackendCase.Models.Output
{
    public class CancellingResult
    {
        public bool status { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is not null &&
                obj is CancellingResult other &&
                status == other.status;
        }
    }   
}
