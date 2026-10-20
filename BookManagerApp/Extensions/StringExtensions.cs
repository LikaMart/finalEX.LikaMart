namespace BookManagerApp.Extensions;

// შემოწმების მეთოდები სტრინგისთვის, extension-ად დავწერე რომ პირდაპირ input.IsValidYear() დავწერო
public static class StringExtensions
{
    // წლის შემოწმება
    public static bool IsValidYear(this string input, out int year)
    {
        bool isNumber = int.TryParse(input, out year);
        // წელი 0-ზე მეტი უნდა იყოს და მიმდინარე წელს არ უნდა აღემატებოდეს, მომავლის წიგნი არ არსებობს
        return isNumber && year > 0 && year <= DateTime.Now.Year;
    }

    // ვამოწმებ რომ ტექსტი ცარიელი ან მხოლოდ სფეისები არ იყოს
    public static bool IsValidText(this string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }
}
