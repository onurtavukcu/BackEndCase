namespace BackendCase.TimeTransformExtension
{
    public static class MinHourExtension
    {
        public static string Transform(DateTime date)
        {
            return date.ToString("HH:mm");
        }
    }
}
