namespace TranslatorApp;

// მთარგმნელის კლასი, ლექსიკონი ტექსტურ ფაილში ინახება
// ყოველი ხაზი ასეთია: სიტყვა,თარგმანი,საიდან,სად
public class Translator
{
    private string dictionaryFilePath;

    public Translator(string dictionaryFilePath)
    {
        this.dictionaryFilePath = dictionaryFilePath;
        // თუ ლექსიკონის ფაილი არ არსებობს ცარიელს ვქმნი
        if (!File.Exists(dictionaryFilePath))
        {
            File.Create(dictionaryFilePath).Close();
        }
    }

    // თარგმანს ვეძებ, თუ ვერ ვიპოვე null ბრუნდება
    public string? TranslateWord(string word, string fromLanguage, string toLanguage)
    {
        string[] lines = File.ReadAllLines(dictionaryFilePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            // მხოლოდ სწორ ხაზებს ვამოწმებ, 4 ნაწილი უნდა ჰქონდეს
            if (parts.Length == 4)
            {
                // Trim ზედმეტ სფეისებს აშორებს, ToLower რომ დიდი ასოები ხელს არ შეუშლის
                string sourceWord = parts[0].Trim().ToLower();
                // თარგმანს ToLower-ს არ ვუკეთებ რომ ისე დაბრუნდეს როგორც ჩაწერილია
                string translatedWord = parts[1].Trim();
                string lineFrom = parts[2].Trim().ToLower();
                string lineTo = parts[3].Trim().ToLower();

                // სიტყვაც და ორივე ენაც უნდა დაემთხვეს
                if (sourceWord == word.ToLower() && lineFrom == fromLanguage.ToLower() && lineTo == toLanguage.ToLower())
                {
                    return translatedWord;
                }
            }
        }
        return null;
    }

    // ახალი თარგმანის დამატება
    public void AddTranslation(string word, string translation, string fromLanguage, string toLanguage)
    {
        string newLine = $"{word},{translation},{fromLanguage},{toLanguage}";
        // AppendAllLines ფაილის ბოლოში ამატებს და ძველს არ შლის
        File.AppendAllLines(dictionaryFilePath, new string[] { newLine });
    }

    // თარგმანის წაშლა
    public bool DeleteTranslation(string word, string fromLanguage, string toLanguage)
    {
        string[] lines = File.ReadAllLines(dictionaryFilePath);
        // აქ ვაგროვებ ყველა ხაზს გარდა წასაშლელისა
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

                // თუ ეს არის წასაშლელი ხაზი continue-თი გამოვტოვებ და სიაში არ ჩაემატება
                if (sourceWord == word.ToLower() && lineFrom == fromLanguage.ToLower() && lineTo == toLanguage.ToLower())
                {
                    deleted = true;
                    continue;
                }
            }
            remainingLines.Add(line);
        }

        // დარჩენილ ხაზებს ვწერ ფაილში, ასე წასაშლელი აღარ იქნება
        File.WriteAllLines(dictionaryFilePath, remainingLines);
        return deleted;
    }
}
