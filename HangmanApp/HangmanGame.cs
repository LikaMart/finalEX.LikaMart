namespace HangmanApp;

// ჯალათის თამაშის კლასი
public class HangmanGame
{
    // სიტყვები საიდანაც შემთხვევით ავირჩევ
    private string[] words = { "apple", "banana", "orange", "computer", "programming" };
    // სიტყვა რომელიც უნდა გამოიცნოს
    private string wordToGuess;
    // აქ ინახება რაც უკვე გამოცნობილია, დანარჩენი _ არის
    // char მასივი ავიღე რადგან სტრინგს ცალკე სიმბოლოს ვერ შევუცვლი
    private char[] revealedLetters;
    // დარჩენილი ცდები
    private int remainingAttempts;
    // ასოები რომლებიც უკვე სცადა, რომ ერთი და იგივე ორჯერ არ ჩაეთვალოს
    private List<char> guessedLetters;

    // კონსტრუქტორში ვამზადებ ახალ თამაშს
    public HangmanGame()
    {
        Random random = new Random();
        // Next(words.Length) აბრუნებს რიცხვს 0-დან სიგრძემდე, ანუ შემთხვევით ინდექსს
        wordToGuess = words[random.Next(words.Length)];
        // მასივი იგივე ზომისაა რაც სიტყვა
        revealedLetters = new char[wordToGuess.Length];
        // თავიდან ყველა ასო დამალულია
        for (int i = 0; i < revealedLetters.Length; i++)
        {
            revealedLetters[i] = '_';
        }
        // 6 ცდა აქვს
        remainingAttempts = 6;
        guessedLetters = new List<char>();
    }

    public void Play()
    {
        bool wordGuessed = false;

        // თამაში გრძელდება სანამ ცდები აქვს და სიტყვა ჯერ არ გამოუცნია
        while (remainingAttempts > 0 && !wordGuessed)
        {
            // char მასივიდან სტრინგს ვაკეთებ რომ დავბეჭდო
            Console.WriteLine(new string(revealedLetters));
            Console.WriteLine($"Remaining attempts: {remainingAttempts}");
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            // ზუსტად ერთი ასო უნდა ჩაწეროს
            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Please enter a single letter");
                continue;
            }

            // პატარა ასოდ ვაქცევ რადგან სიტყვები პატარა ასოებითაა
            char guessedLetter = char.ToLower(input[0]);

            // თუ უკვე სცადა ცდას არ ვაკლებ, უბრალოდ ვეუბნები
            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("You already guessed this letter");
                continue;
            }

            guessedLetters.Add(guessedLetter);

            bool letterFound = false;
            // მთელ სიტყვას ვამოწმებ რადგან ერთი ასო შეიძლება რამდენჯერმე იყოს, მაგალითად banana-ში a
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guessedLetter)
                {
                    revealedLetters[i] = guessedLetter;
                    letterFound = true;
                }
            }

            // თუ ასო არ იყო სიტყვაში ცდა აკლდება
            if (!letterFound)
            {
                remainingAttempts--;
                Console.WriteLine("Wrong letter");
            }

            // თუ გახსნილი ასოები მთლიან სიტყვას დაემთხვა ესე იგი გამოიცნო
            wordGuessed = new string(revealedLetters) == wordToGuess;
        }

        // ციკლის მერე ვამოწმებ მოიგო თუ წააგო
        if (wordGuessed)
        {
            Console.WriteLine($"Congratulations! The word was {wordToGuess}");
        }
        else
        {
            Console.WriteLine($"You lost. The word was {wordToGuess}");
        }
    }
}
