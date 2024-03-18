namespace BackendCase.TimeTransformExtension
{
    public static class MinHourExtension
    {
        public static string Transform(DateTime date)
        {
            return date.ToString("HH:mm");
            // we get to the only hours and minutes for url.
        }
    }
}
