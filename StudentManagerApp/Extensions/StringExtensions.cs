namespace StudentManagerApp.Extensions;

public static class StringExtensions
{
    private static readonly char[] ValidGrades = { 'A', 'B', 'C', 'D', 'F' };

    public static bool IsValidText(this string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    public static bool IsValidRollNumber(this string input, out int rollNumber)
    {
        bool isNumber = int.TryParse(input, out rollNumber);
        return isNumber && rollNumber > 0;
    }

    public static bool IsValidGrade(this string input, out char grade)
    {
        grade = '\0';

        if (input.Length != 1)
        {
            return false;
        }

        char candidate = char.ToUpper(input[0]);
        if (Array.IndexOf(ValidGrades, candidate) == -1)
        {
            return false;
        }

        grade = candidate;
        return true;
    }
}
