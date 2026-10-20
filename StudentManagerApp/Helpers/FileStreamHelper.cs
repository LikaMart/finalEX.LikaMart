namespace StudentManagerApp.Helpers;

// ფაილთან სამუშაო დამხმარე კლასი
public static class FileStreamHelper
{
    public static List<string> ReadLines(string filePath)
    {
        // თუ ფაილი არ არის ვქმნი და მაშინვე ვხურავ
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        return File.ReadAllLines(filePath).ToList();
    }

    // ყველა ხაზს ვწერ ფაილში, ძველს გადააწერს
    public static void WriteLines(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}
