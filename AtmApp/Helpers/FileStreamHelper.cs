namespace AtmApp.Helpers;

// ფაილთან მუშაობა ცალკე კლასში გავიტანე რომ სერვისებში არ გამეორდეს
public static class FileStreamHelper
{
    // ფაილიდან ყველა ხაზს ვკითხულობ
    public static List<string> ReadLines(string filePath)
    {
        // თუ ფაილი ჯერ არ არსებობს ვქმნი, თორემ ერორს ამოაგდებს
        // Close() აუცილებელია რადგან Create ფაილს ღიად ტოვებს
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        // ToList იმიტომ რომ ReadAllLines მასივს აბრუნებს, მე კი List მჭირდება
        return File.ReadAllLines(filePath).ToList();
    }

    // ფაილში ვწერ ყველა ხაზს, ძველი შიგთავსი იშლება და ახლით იცვლება
    public static void WriteLines(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}
