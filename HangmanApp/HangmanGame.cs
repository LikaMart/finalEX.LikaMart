namespace HangmanApp;

public class HangmanGame
{
    private string[] words = { "apple", "banana", "orange", "computer", "programming" };
    private string wordToGuess;
    private char[] revealedLetters;
    private int remainingAttempts;
    private List<char> guessedLetters;

    public HangmanGame()
    {
        Random random = new Random();
        wordToGuess = words[random.Next(words.Length)];
        revealedLetters = new char[wordToGuess.Length];
        for (int i = 0; i < revealedLetters.Length; i++)
        {
            revealedLetters[i] = '_';
        }
        remainingAttempts = 6;
        guessedLetters = new List<char>();
    }

    public void Play()
    {
        bool wordGuessed = false;

        while (remainingAttempts > 0 && !wordGuessed)
        {
            Console.WriteLine(new string(revealedLetters));
            Console.WriteLine($"Remaining attempts: {remainingAttempts}");
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Please enter a single letter");
                continue;
            }

            char guessedLetter = char.ToLower(input[0]);

            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("You already guessed this letter");
                continue;
            }

            guessedLetters.Add(guessedLetter);

            bool letterFound = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guessedLetter)
                {
                    revealedLetters[i] = guessedLetter;
                    letterFound = true;
                }
            }

            if (!letterFound)
            {
                remainingAttempts--;
                Console.WriteLine("Wrong letter");
            }

            wordGuessed = new string(revealedLetters) == wordToGuess;
        }

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