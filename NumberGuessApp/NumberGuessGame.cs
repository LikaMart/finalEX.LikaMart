namespace NumberGuessApp;

public class NumberGuessGame
{
    private int minValue;
    private int maxValue;
    private int targetNumber;
    private int attempts;

    public NumberGuessGame(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        Random random = new Random();
        targetNumber = random.Next(minValue, maxValue + 1);
        attempts = 0;
    }

    public void Play()
    {
        bool guessedCorrectly = false;
        int[] previousGuesses = new int[20];
        int guessCount = 0;

        Console.WriteLine($"Guess a number between {minValue} and {maxValue}");

        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess: ");
            string? input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int guess);

            if (!isValid)
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            attempts++;

            if (guessCount < previousGuesses.Length)
            {
                previousGuesses[guessCount] = guess;
                guessCount++;
            }

            if (guess < targetNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > targetNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                guessedCorrectly = true;
                Console.WriteLine($"Correct! You guessed it in {attempts} attempts");
            }
        }

        Console.Write("Your guesses were: ");
        for (int i = 0; i < guessCount; i++)
        {
            Console.Write(previousGuesses[i] + " ");
        }
        Console.WriteLine();
    }
}