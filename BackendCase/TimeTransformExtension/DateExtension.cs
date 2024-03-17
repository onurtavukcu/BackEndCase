using System.Globalization;

namespace BackendCase.TimeTransformExtension
{
    public static class DateExtension
    {
        public static string Transform(DateTime date)
        {
            CultureInfo culture = new CultureInfo("en-US");

            culture.DateTimeFormat.DateSeparator = "/";

            return date.ToString("dd/MM/yyyy", culture);
        }
    }
}
