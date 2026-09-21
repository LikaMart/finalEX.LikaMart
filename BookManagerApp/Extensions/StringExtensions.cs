namespace BookManagerApp.Extensions;

public static class StringExtensions
{
    public static bool IsValidYear(this string input, out int year)
    {
        bool isNumber = int.TryParse(input, out year);
        return isNumber && year > 0 && year <= DateTime.Now.Year;
    }

    public static bool IsValidText(this string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }
}
