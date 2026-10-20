namespace BookManagerApp.Helpers;

// ფაილის წაკითხვა და ჩაწერა ცალკე კლასში მაქვს
public static class FileStreamHelper
{
    public static List<string> ReadLines(string filePath)
    {
        // პირველ გაშვებაზე ფაილი არ იქნება ამიტომ ვქმნი, Close რომ ფაილი დაიხუროს
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        // მასივს List-ად ვაქცევ რადგან List-თან მუშაობა უფრო მოსახერხებელია
        return File.ReadAllLines(filePath).ToList();
    }

    // ფაილს მთლიანად თავიდან ვწერ
    public static void WriteLines(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}
