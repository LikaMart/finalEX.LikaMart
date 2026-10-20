using TranslatorApp;

// ლექსიკონის ფაილის სახელს ვაწვდი
Translator translator = new Translator("dictionary.txt");
bool running = true;

while (running)
{
    Console.WriteLine("1. Georgian to English");
    Console.WriteLine("2. Georgian to Russian");
    Console.WriteLine("3. English to Georgian");
    Console.WriteLine("4. Russian to Georgian");
    Console.WriteLine("5. Delete Translation");
    Console.WriteLine("6. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    // აქ ჩაიწერება რომელი ენიდან რომელზე ვთარგმნი
    string fromLanguage;
    string toLanguage;

    // გამოსვლა
    if (choice == "6")
    {
        running = false;
        continue;
    }

    // წაშლა ცალკე დავწერე რადგან სხვა ველებს ითხოვს
    if (choice == "5")
    {
        Console.Write("Enter word to delete: ");
        string? wordToDelete = Console.ReadLine();
        Console.Write("From language: ");
        string? deleteFrom = Console.ReadLine();
        Console.Write("To language: ");
        string? deleteTo = Console.ReadLine();

        // სამივე უნდა იყოს შევსებული
        if (string.IsNullOrWhiteSpace(wordToDelete) || string.IsNullOrWhiteSpace(deleteFrom) || string.IsNullOrWhiteSpace(deleteTo))
        {
            Console.WriteLine("All fields are required");
            continue;
        }

        bool deleted = translator.DeleteTranslation(wordToDelete, deleteFrom, deleteTo);
        Console.WriteLine(deleted ? "Translation deleted" : "Translation not found");
        continue;
    }

    // არჩევანის მიხედვით ენებს ვაყენებ
    switch (choice)
    {
        case "1":
            fromLanguage = "georgian";
            toLanguage = "english";
            break;
        case "2":
            fromLanguage = "georgian";
            toLanguage = "russian";
            break;
        case "3":
            fromLanguage = "english";
            toLanguage = "georgian";
            break;
        case "4":
            fromLanguage = "russian";
            toLanguage = "georgian";
            break;
        default:
            // აქ continue მჭირდება რადგან ენები არ არის მინიჭებული და ქვემოთ ვერ გავაგრძელებ
            Console.WriteLine("Invalid option");
            continue;
    }

    Console.Write("Enter word or phrase: ");
    string? inputWord = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(inputWord))
    {
        Console.WriteLine("Please enter a word");
        continue;
    }

    // თარგმანს ვეძებ ლექსიკონში
    string? translation = translator.TranslateWord(inputWord, fromLanguage, toLanguage);

    if (translation != null)
    {
        Console.WriteLine($"Translation: {translation}");
    }
    else
    {
        // თუ ვერ ვიპოვე ვთავაზობ რომ თვითონ დაამატოს, ასე ლექსიკონი თანდათან იზრდება
        Console.WriteLine("Word not found in dictionary");
        Console.Write("Would you like to add a translation? (y/n): ");
        string? answer = Console.ReadLine();

        if (answer != null && answer.ToLower() == "y")
        {
            Console.Write("Enter translation: ");
            string? newTranslation = Console.ReadLine();

            // ცარიელ თარგმანს არ ვინახავ
            if (!string.IsNullOrWhiteSpace(newTranslation))
            {
                translator.AddTranslation(inputWord, newTranslation, fromLanguage, toLanguage);
                Console.WriteLine("Translation added to dictionary");
            }
        }
    }
}

Console.WriteLine("Program finished");
