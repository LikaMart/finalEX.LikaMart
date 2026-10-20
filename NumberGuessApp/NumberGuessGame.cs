namespace NumberGuessApp;

// რიცხვის გამოცნობის თამაში
// კომპიუტერი ირჩევს შემთხვევით რიცხვს და მომხმარებელი ცდილობს გამოიცნოს
// ყოველ ცდაზე ვეუბნები მეტია თუ ნაკლები, ბოლოს ვაჩვენებ რამდენ ცდაში გამოიცნო და რა რიცხვები სცადა
public class NumberGuessGame
{
    // დიაპაზონის საზღვრები
    private int minValue;
    private int maxValue;
    // ჩაფიქრებული რიცხვი
    private int targetNumber;
    // ცდების რაოდენობა
    private int attempts;

    // დიაპაზონს გარედან ვიღებ რომ სხვადასხვა საზღვრით შეიძლებოდეს თამაში
    public NumberGuessGame(int minValue, int maxValue)
    {
        // this იმიტომ რომ პარამეტრს და ველს ერთი სახელი აქვთ
        this.minValue = minValue;
        this.maxValue = maxValue;
        Random random = new Random();
        // maxValue + 1 იმიტომ რომ Next ზედა საზღვარს არ ითვლის
        targetNumber = random.Next(minValue, maxValue + 1);
        attempts = 0;
    }

    public void Play()
    {
        bool guessedCorrectly = false;
        // წინა ცდებს ვინახავ, მაქსიმუმ 20
        int[] previousGuesses = new int[20];
        // რამდენი ჩავწერე მასივში
        int guessCount = 0;

        Console.WriteLine($"Guess a number between {minValue} and {maxValue}");

        // სანამ არ გამოიცნობს
        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess: ");
            string? input = Console.ReadLine();
            // TryParse რომ ასოზე პროგრამა არ გაითიშოს
            bool isValid = int.TryParse(input, out int guess);

            if (!isValid)
            {
                // არასწორ შეყვანას ცდად არ ვთვლი
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            attempts++;

            // ეს შემოწმება საჭიროა რომ 20-ზე მეტ ცდაზე მასივს არ გასცდეს და ერორი არ ამოაგდოს
            if (guessCount < previousGuesses.Length)
            {
                previousGuesses[guessCount] = guess;
                guessCount++;
            }

            if (guess < targetNumber)
            {
                // ჩაფიქრებული უფრო დიდია
                Console.WriteLine("Higher");
            }
            else if (guess > targetNumber)
            {
                // ჩაფიქრებული უფრო პატარაა
                Console.WriteLine("Lower");
            }
            else
            {
                // გამოიცნო
                guessedCorrectly = true;
                Console.WriteLine($"Correct! You guessed it in {attempts} attempts");
            }
        }

        // ბოლოს ყველა ცდას ვბეჭდავ
        Console.Write("Your guesses were: ");
        // guessCount-მდე ვატრიალებ და არა Length-მდე, რომ ცარიელი ნულები არ დაიბეჭდოს
        for (int i = 0; i < guessCount; i++)
        {
            Console.Write(previousGuesses[i] + " ");
        }
        Console.WriteLine();
    }
}
