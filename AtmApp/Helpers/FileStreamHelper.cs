namespace AtmApp.Helpers;

public static class FileStreamHelper
{
    public static List<string> ReadLines(string filePath)
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        return File.ReadAllLines(filePath).ToList();
    }

    public static void WriteLines(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}
