using TranslatorApp;

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

    string fromLanguage;
    string toLanguage;

    if (choice == "6")
    {
        running = false;
        continue;
    }

    if (choice == "5")
    {
        Console.Write("Enter word to delete: ");
        string? wordToDelete = Console.ReadLine();
        Console.Write("From language: ");
        string? deleteFrom = Console.ReadLine();
        Console.Write("To language: ");
        string? deleteTo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(wordToDelete) || string.IsNullOrWhiteSpace(deleteFrom) || string.IsNullOrWhiteSpace(deleteTo))
        {
            Console.WriteLine("All fields are required");
            continue;
        }

        bool deleted = translator.DeleteTranslation(wordToDelete, deleteFrom, deleteTo);
        Console.WriteLine(deleted ? "Translation deleted" : "Translation not found");
        continue;
    }

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

    string? translation = translator.TranslateWord(inputWord, fromLanguage, toLanguage);

    if (translation != null)
    {
        Console.WriteLine($"Translation: {translation}");
    }
    else
    {
        Console.WriteLine("Word not found in dictionary");
        Console.Write("Would you like to add a translation? (y/n): ");
        string? answer = Console.ReadLine();

        if (answer != null && answer.ToLower() == "y")
        {
            Console.Write("Enter translation: ");
            string? newTranslation = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTranslation))
            {
                translator.AddTranslation(inputWord, newTranslation, fromLanguage, toLanguage);
                Console.WriteLine("Translation added to dictionary");
            }
        }
    }
}

Console.WriteLine("Program finished");