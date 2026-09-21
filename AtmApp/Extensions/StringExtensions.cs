namespace AtmApp.Extensions;

public static class StringExtensions
{
    public static bool IsValidAmount(this string input, out double amount)
    {
        bool isNumber = double.TryParse(input, out amount);
        return isNumber && amount > 0;
    }
}
