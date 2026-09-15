namespace TranslatorApp;

public class Translator
{
    private string dictionaryFilePath;

    public Translator(string dictionaryFilePath)
    {
        this.dictionaryFilePath = dictionaryFilePath;
        if (!File.Exists(dictionaryFilePath))
        {
            File.Create(dictionaryFilePath).Close();
        }
    }

    public string? TranslateWord(string word, string fromLanguage, string toLanguage)
    {
        string[] lines = File.ReadAllLines(dictionaryFilePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4)
            {
                string sourceWord = parts[0].Trim().ToLower();
                string translatedWord = parts[1].Trim();
                string lineFrom = parts[2].Trim().ToLower();
                string lineTo = parts[3].Trim().ToLower();

                if (sourceWord == word.ToLower() && lineFrom == fromLanguage.ToLower() && lineTo == toLanguage.ToLower())
                {
                    return translatedWord;
                }
            }
        }
        return null;
    }

    public void AddTranslation(string word, string translation, string fromLanguage, string toLanguage)
    {
        string newLine = $"{word},{translation},{fromLanguage},{toLanguage}";
        File.AppendAllLines(dictionaryFilePath, new string[] { newLine });
    }

    public bool DeleteTranslation(string word, string fromLanguage, string toLanguage)
    {
        string[] lines = File.ReadAllLines(dictionaryFilePath);
        List<string> remainingLines = new List<string>();
        bool deleted = false;

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4)
            {
                string sourceWord = parts[0].Trim().ToLower();
                string lineFrom = parts[2].Trim().ToLower();
                string lineTo = parts[3].Trim().ToLower();

                if (sourceWord == word.ToLower() && lineFrom == fromLanguage.ToLower() && lineTo == toLanguage.ToLower())
                {
                    deleted = true;
                    continue;
                }
            }
            remainingLines.Add(line);
        }

        File.WriteAllLines(dictionaryFilePath, remainingLines);
        return deleted;
    }
}