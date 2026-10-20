namespace StudentManagerApp.Extensions;

// სტრინგის შემოწმების extension მეთოდები
public static class StringExtensions
{
    // დასაშვები ნიშნები, readonly რადგან არ უნდა შეიცვალოს
    private static readonly char[] ValidGrades = { 'A', 'B', 'C', 'D', 'F' };

    // ტექსტი ცარიელი არ უნდა იყოს
    public static bool IsValidText(this string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    // სიის ნომერი დადებითი მთელი რიცხვი უნდა იყოს
    public static bool IsValidRollNumber(this string input, out int rollNumber)
    {
        bool isNumber = int.TryParse(input, out rollNumber);
        return isNumber && rollNumber > 0;
    }

    // ნიშნის შემოწმება
    public static bool IsValidGrade(this string input, out char grade)
    {
        // out ცვლადს აუცილებლად უნდა მივანიჭო რამე, ამიტომ თავიდან ცარიელ სიმბოლოს ვაძლევ
        grade = '\0';

        // ნიშანი მხოლოდ ერთი ასო უნდა იყოს
        if (input.Length != 1)
        {
            return false;
        }

        // ToUpper რომ პატარა ასოთი ჩაწერილიც მიიღოს, მაგალითად a
        char candidate = char.ToUpper(input[0]);
        // IndexOf -1-ს აბრუნებს თუ მასივში ვერ იპოვა
        if (Array.IndexOf(ValidGrades, candidate) == -1)
        {
            return false;
        }

        grade = candidate;
        return true;
    }
}
